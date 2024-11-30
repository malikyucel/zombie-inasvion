using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
using UnityEditor;

public class GameManeger : MonoBehaviour
{
    public static GameManeger Instance;

    public string best_player_name;
    public int best_player_point;

    public InputField PlayerName;
    public string player_name;

    private void Awake()
    {
        LoadData();

        if (Instance != null)
        {
            Destroy(Instance);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        player_name = PlayerName.text;
        if (player_name != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                StartGame();
            }
        }
    }

    [SerializeField]
    class BestScore
    {
        public string BestPlayerName;
        public int BestPlayerPoint;
    }

    public void SaveData()
    {
        BestScore temp = new BestScore();
        temp.BestPlayerPoint = best_player_point;
        temp.BestPlayerName = best_player_name;

        string json = JsonUtility.ToJson(temp);
        File.WriteAllText(Application.dataPath + "/Save/BestScore.json",json);
    }

    public void LoadData() 
    {
        string peth = Application.dataPath + "/Save/BestScore.json";
        if (File.Exists(peth))
        {
            string json = File.ReadAllText(peth);
            BestScore bestScore = JsonUtility.FromJson<BestScore>(json);

            best_player_name = bestScore.BestPlayerName;
            best_player_point = bestScore.BestPlayerPoint;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}

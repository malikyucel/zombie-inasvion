using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI Best_Score_Text;

    public GameObject[] Health_Style;
    public GameObject[] Clip_Bullet_Style;
    public GameObject Menu_;
    private void Update()
    {
            Best_Score_Text.text = "Best Score \n" + GameManeger.Instance.best_player_name +
                                              ": " + GameManeger.Instance.best_player_point;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            MenuOn();
        }
    }
    public void SceneRefresh()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void MenuOn()
    {
        Menu_.SetActive(true);
    }
    public void MenuOf()
    {
        Menu_.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void HealthStyle1()
    {
        Health_Style[0].SetActive(true);
        Health_Style[1].SetActive(false);
    }
    public void HealthStyle2()
    {
        Health_Style[0].SetActive(false);
        Health_Style[1].SetActive(true);
    }
    public void BulletClip1()
    {
        Clip_Bullet_Style[0].SetActive(false);
        Clip_Bullet_Style[1].SetActive(true);
    }
    public void BulletClip2()
    {
        Clip_Bullet_Style[0].SetActive(true);
        Clip_Bullet_Style[1].SetActive(false);
    }

}

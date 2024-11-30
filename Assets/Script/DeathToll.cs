using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeathToll : MonoBehaviour
{
    public int Death_Toll = 0;
    public Text Death;
    private void Update()
    {
        Death.text = "Death Zom: " + Death_Toll;
        if(GameManeger.Instance.best_player_point < Death_Toll)
        {
            GameManeger.Instance.best_player_point = Death_Toll;
            GameManeger.Instance.best_player_name = GameManeger.Instance.player_name;
            GameManeger.Instance.SaveData();
        }
    }

}

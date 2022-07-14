using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public Text playerBestScoreText;
    private string playerNAME;
    private int playerSCORE;

    private void Awake()
    {
        MainManager2.Instance.LoadPlayerName();
        MainManager2.Instance.LoadScore();
        playerNAME = MainManager2.Instance.playerName;
        playerSCORE = MainManager2.Instance.bestScore;
        playerBestScoreText.text = "Best Score : " + playerNAME + " : " + playerSCORE;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUI : MonoBehaviour
{
    public TMP_InputField playerInput;
    public TextMeshProUGUI title;

    private string playerNAME;
    private int playerSCORE;

    private void Awake()
    {
        MainManager2.Instance.LoadPlayerName();
        MainManager2.Instance.LoadScore();
        playerNAME = MainManager2.Instance.playerName;
        playerSCORE = MainManager2.Instance.bestScore;

        title.text = "Best Score: " + playerNAME + " : " + playerSCORE;
        playerInput.text = playerNAME;
    }

    public void StartGame()
    {
        if (playerInput.text != MainManager2.Instance.playerName)
        {
            MainManager2.Instance.bestScore = 0;
            MainManager2.Instance.SaveScore();
            MainManager2.Instance.playerName = playerInput.text;
            MainManager2.Instance.SavePlayerName();
        }
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

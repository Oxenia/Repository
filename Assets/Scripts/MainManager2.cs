using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager2 : MonoBehaviour
{
    public static MainManager2 Instance;

    public string playerName;
    public int bestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // DATA STORING
    [System.Serializable]
    class DataPlayerName
    {
        public string playerName;
    }

    [System.Serializable]
    class DataScore
    {
        public int bestScore;
    }

    public void SavePlayerName()
    {
        DataPlayerName data = new DataPlayerName();
        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/saveplayer.json", json);
    }
    public void SaveScore()
    {
        DataScore data = new DataScore();
        data.bestScore = bestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savescore.json", json);
    }

    public void LoadPlayerName()
    {
        string path = Application.persistentDataPath + "/saveplayer.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            DataPlayerName data = JsonUtility.FromJson<DataPlayerName>(json);

            playerName = data.playerName;
        }
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savescore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            DataScore data = JsonUtility.FromJson<DataScore>(json);

            bestScore = data.bestScore;
        }
    }
}

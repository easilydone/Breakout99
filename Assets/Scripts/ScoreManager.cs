using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int highScore = 0;
    public string highScoreName ="Not Set";
    public string playerName = "";

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);
        LoadHighScore();
    }

    [System.Serializable]
    class HighScore
    {
        public int highScore;
        public string highScoreName;
    }

    public void SaveHighScore()
    {
        HighScore data = new HighScore();
        data.highScore = highScore;
        data.highScoreName = highScoreName;

        string json = JsonUtility.ToJson(data);

        string filePath = Application.persistentDataPath + "/savedata.json";

        File.WriteAllText(filePath, json);
    }

    public void LoadHighScore()
    {
        string filePath = Application.persistentDataPath + "/savedata.json";


        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            HighScore data = JsonUtility.FromJson<HighScore>(json);

            highScore = data.highScore;
            highScoreName = data.highScoreName;
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    // Singleton
    
    public static DataManager Instance;
    public string currentUserName;
    public string bestSocoreName;
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
        LoadScore();
    }

    public void SetUserName(string name)
    {
        this.currentUserName = name;
    }

    public void SetNewBestScore(int score)
    {
        bestScore = score;
        bestSocoreName = currentUserName;
        SaveScore();
    }


    [System.Serializable]
    class BestScore
    {
        public int score;
        public string name;
    }
    private void SaveScore()
    {
        BestScore bestScore = new BestScore();
        bestScore.score = this.bestScore;
        bestScore.name = this.bestSocoreName;

        string json = JsonUtility.ToJson(bestScore);
        File.WriteAllText(Application.persistentDataPath + "/bestScore.json", json);
    }

    private void LoadScore()
    {
        string path = Application.persistentDataPath + "/bestScore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestScore data = JsonUtility.FromJson<BestScore>(json);
            this.bestScore = data.score;
            this.bestSocoreName = data.name;
        }
    }
}

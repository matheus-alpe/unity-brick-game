using System;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameData currentData;

    private string _savePath;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        _savePath = Application.persistentDataPath + "/save.json";
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    public void SaveData(string name, int points)
    {
        currentData.bestScoreName = name;
        currentData.bestScore = points;
        var json = JsonUtility.ToJson(currentData);
        File.WriteAllText(_savePath, json);
    }

    private void LoadData()
    {
        if (!File.Exists(_savePath)) return;

        var json = File.ReadAllText(_savePath);
        var data = JsonUtility.FromJson<GameData>(json);
        currentData = data;
    }

    [Serializable]
    public class GameData
    {
        public string name;
        public string bestScoreName;
        public int bestScore;
    }
}
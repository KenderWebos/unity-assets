using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

[System.Serializable]
public class GameData
{
    public string playerName;
    public int playerLevel;
    public float playerHealth;
    public Vector3 playerPosition;
    public List<string> inventoryItems;
    public Dictionary<string, bool> completedQuests;
    public Dictionary<string, int> playerStats;
    public DateTime lastSaveTime;

    public GameData()
    {
        playerName = "Player";
        playerLevel = 1;
        playerHealth = 100f;
        playerPosition = Vector3.zero;
        inventoryItems = new List<string>();
        completedQuests = new Dictionary<string, bool>();
        playerStats = new Dictionary<string, int>();
        lastSaveTime = DateTime.Now;
    }
}

public class SaveSystem : MonoBehaviour
{
    private static SaveSystem instance;
    public static SaveSystem Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SaveSystem>();
                if (instance == null)
                {
                    GameObject go = new GameObject("SaveSystem");
                    instance = go.AddComponent<SaveSystem>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    private GameData currentGameData;
    private string savePath;
    private const string SAVE_FILE_NAME = "gameSave.dat";

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        savePath = Path.Combine(Application.persistentDataPath, SAVE_FILE_NAME);
    }

    public void SaveGame()
    {
        try
        {
            if (currentGameData == null)
            {
                currentGameData = new GameData();
            }

            currentGameData.lastSaveTime = DateTime.Now;

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(savePath, FileMode.Create);

            formatter.Serialize(stream, currentGameData);
            stream.Close();

            Debug.Log("Game saved successfully at: " + savePath);
        }
        catch (Exception e)
        {
            Debug.LogError("Error saving game: " + e.Message);
        }
    }

    public void LoadGame()
    {
        try
        {
            if (File.Exists(savePath))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(savePath, FileMode.Open);

                currentGameData = formatter.Deserialize(stream) as GameData;
                stream.Close();

                Debug.Log("Game loaded successfully from: " + savePath);
            }
            else
            {
                Debug.Log("No save file found. Creating new game data.");
                currentGameData = new GameData();
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error loading game: " + e.Message);
            currentGameData = new GameData();
        }
    }

    public void DeleteSave()
    {
        try
        {
            if (File.Exists(savePath))
            {
                File.Delete(savePath);
                currentGameData = new GameData();
                Debug.Log("Save file deleted successfully");
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error deleting save file: " + e.Message);
        }
    }

    public GameData GetCurrentGameData()
    {
        return currentGameData;
    }

    public void UpdateGameData(GameData newData)
    {
        currentGameData = newData;
    }

    public bool HasSaveFile()
    {
        return File.Exists(savePath);
    }

    public DateTime GetLastSaveTime()
    {
        if (currentGameData != null)
        {
            return currentGameData.lastSaveTime;
        }
        return DateTime.MinValue;
    }
} 
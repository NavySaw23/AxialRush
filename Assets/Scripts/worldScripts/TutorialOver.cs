using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TutorialOver : MonoBehaviour
{
    public Manager gm;
    public bool firstPlay;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            firstPlay = false;
            SaveFirstPlayToJson();
        }
    }

    void SaveFirstPlayToJson()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "gameData.json");

        // Check if the file exists
        if (!File.Exists(filePath))
        {
            // Create the file
            File.Create(filePath).Close();
        }

        // Serialize game data to JSON
        string jsonData = JsonUtility.ToJson(new GameData { firstPlay = firstPlay });

        // Write JSON data to the file
        File.WriteAllText(filePath, jsonData);
        Debug.Log("Successful write at " + filePath);
    }

    [System.Serializable]
    public class GameData
    {
        public bool firstPlay;
    }
}

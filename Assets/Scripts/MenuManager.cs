using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuManager : MonoBehaviour
{
    [System.Serializable]
    public class GameData
    {
        public bool firstPlay;
    }

    private bool firstPlay;

    void Start()
    {
        // Lock rotation to left landscape
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.orientation = ScreenOrientation.AutoRotation;

        // Keep screen on
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        // Load game data
        LoadGameData();
    }

    private void LoadGameData()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "gameData.json");
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            GameData gameData = JsonUtility.FromJson<GameData>(jsonData);
            firstPlay = gameData.firstPlay;
            Debug.Log(firstPlay);
            Debug.Log(filePath);
        }
        else
        {
            firstPlay = true; // Assume it's the first play if the file doesn't exist
        }
    }

    public void Game()
    {
        LoadGameData(); // Reload the game data in case it changed

        if (firstPlay)
        {
            SceneManager.LoadScene("tutorial");
        }
        else
        {
            SceneManager.LoadScene("game");
        }
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("tutorial");
    }

    public void Exit()
    {
        Application.Quit();
    }
}

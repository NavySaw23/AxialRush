using System.Collections;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public Rigidbody Player;
    public rotationMatrix position;
    public GameObject world;

    // Level Rotation
    public float rotationCooldownSec = 0.4f;
    public float rotationSpeed = 3f;

    // Camera Bobbing
    public float bobbingSpeed = 14.0f;
    public float bobbingAmount = 0.05f;

    // Points
    public TMP_Text scoreboard;
    public int points = 0;

    // Gameovers
    public bool gameover = false;
    public GameObject gameoverObject;
    public TMP_Text gameoverText;


    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        Physics.gravity = new Vector3(0f, -100f, 0f);
        gameover = false;
        points = 0;

        // Start the coroutine to increase points every second
        StartCoroutine(IncrementPoints());
    }

    private void Update()
    {
        scoreboard.text = points + " m";

        if (gameover)
        {
            gameoverObject.SetActive(true);
            GameObject.Destroy(world);
            Player.useGravity = false;
        }
    }

    private IEnumerator IncrementPoints()
    {
        while (!gameover)
        {
            yield return new WaitForSeconds(1f);
            points++;
        }
    }
}

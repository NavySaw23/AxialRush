using System.Collections;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    // basic
    [Header("Basic")]
    public Rigidbody Player;
    public rotationMatrix position;
    public GameObject world;
    public bool Paused = false;
    private static float currentSpeed = 0.6f;

    // Level Rotation
    [Header("Level Rotation")]
    public float rotationCooldownSec = 0.4f;
    public float rotationSpeed = 3f;

    // Camera Bobbing
    [Header("Camera Bobbing")]
    public float bobbingSpeed = 14.0f;
    public float bobbingAmount = 0.05f;

    // Points
    [Header("Points")]
    public TMP_Text scoreboard;
    public int points = 0;

    // attacks
    [Header("Attack")]
    public float attackDuration = 0.3f;
    public bool isAttacking = false;

    // Gameovers
    [Header("Gameovers")]
    public bool gameover = false;
    public GameObject gameoverObject;
    public GameObject restartButton;
    public TMP_Text gameoverText;
    public restart restart;


    private void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        currentSpeed = 0.6f;


        Physics.gravity = new Vector3(0f, -100f, 0f);
        gameover = false;
        points = 0;

    }

    private void Update()
    {
        // Debug.Log(currentSpeed);

        //pause play logic
        if (Input.GetKeyDown(KeyCode.Space) && !Paused)
        {
            Paused = true;
            // Debug.Log("pause");
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Paused)
        {
            Paused = false;
            // Debug.Log("play");
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            restart.restartGame();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            Attack();
        }

        if (Paused || gameover)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = currentSpeed;
        }




        // update scoreboard
        scoreboard.text = points + " m";

        if (gameover)
        {
            gameoverObject.SetActive(true);
            restartButton.SetActive(true);
            Player.useGravity = false;
        }
    }

    private IEnumerator speedUpdate()
    {
        while (!gameover)
        {
            yield return new WaitForSeconds(20f);
            if (currentSpeed < 2)
            {
                currentSpeed += 0.1f;
            }
        }
    }

    public void Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            Debug.Log("Attacking!");
            StartCoroutine(StopAfterDelay());
        }
    }

    IEnumerator StopAfterDelay()
    {
        yield return new WaitForSeconds(attackDuration); // Add a delay of 1 second
        isAttacking = false;
        Debug.Log("Stopped");
    }
}

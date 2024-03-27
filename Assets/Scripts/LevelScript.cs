using System.Collections;
using UnityEngine;

public class LevelScript : MonoBehaviour
{

    public Manager gm;
    private bool isRotating = false;
    private Quaternion targetRotation;

    private int lr = 0;
    private Vector2 touchStartPos;
    private bool isSwipe;

    private int i = 0;


    void Start()
    {
        targetRotation = gm.position.Current.DirQuat;
        // DEBUG("Initial Rotation ", transform.rotation );
    }

    void Update()
    {
        //gyro inputs
        Gyroscope gyro = Input.gyro;
        gyro.enabled = true;

        // default orientation of the device
        Vector3 tilt = Input.acceleration;
        tilt = Quaternion.Euler(90, 0, 0) * tilt;  
        
        // Debug.Log(tilt);

        // touch inputs (swipe)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
                isSwipe = true;
            }
            else if (touch.phase == TouchPhase.Moved && isSwipe)
            {
                float deltaX = touch.position.x - touchStartPos.x;
                float deltaY = touch.position.y - touchStartPos.y;

                if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
                {
                    if (deltaX < 0) // Left swipe detected
                    {
                        lr = -1;
                    }
                    else if (deltaX > 0) // Right swipe detected
                    {
                        lr = 1;
                    }
                }

                isSwipe = false;
            }
        }

        //rotation phyics

        if (!isRotating && !gm.Paused && !gm.gameover)
        {
            // turn left and right
            if (Input.GetKeyDown(KeyCode.Keypad4) || lr == -1)
            {
             gm.position.Current = gm.position.Current.Lturn;
                lr = 0;
            }
            if (Input.GetKeyDown(KeyCode.Keypad6) || lr == 1)
            {
             gm.position.Current = gm.position.Current.Rturn;
                lr = 0;
            }
            if (Input.GetKeyDown(KeyCode.Keypad7)||tilt.x < -0.5f)
            {
             gm.position.Current = gm.position.Current.Rroll;
            }
            if (Input.GetKeyDown(KeyCode.Keypad9)||tilt.x > 0.5f)
            {
             gm.position.Current = gm.position.Current.Lroll;
            }
            if (Input.GetKeyDown(KeyCode.Keypad0))
            {
             gm.position.Current = gm.position.RW;
            }

            if (targetRotation != gm.position.Current.DirQuat)
            {
                targetRotation = gm.position.Current.DirQuat;
                StartCoroutine(RotateToTarget());
            }
        }
    }

    IEnumerator RotateToTarget()
    {
        isRotating = true;
        Quaternion startRotation = transform.rotation;
        
        // DEBUG("Pre rotation", startRotation);
        // DEBUG("Target rotation", targetRotation);

        float t = 0f;

        while (t < gm.rotationCooldownSec)
        {
            t += Time.unscaledDeltaTime;
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, gm.rotationSpeed * t);
            yield return null;
        }

        transform.rotation = targetRotation; // Ensure the target rotation is exactly reached
        isRotating = false;

        // DEBUG("Post rotation (matrix)", gm.position.Current.DirQuat);
        // DEBUG("Post rotation (transform)", transform.rotation );
    }

    public void DEBUG(string name_, Quaternion quaternion_){
        Debug.Log(i++ + name_ + " | " + quaternion_.w + ", " + quaternion_.x + ", " + quaternion_.y + ", " + quaternion_.z);
        
        Debug.Log("Name - " + gm.position.Current.name);
    }
}

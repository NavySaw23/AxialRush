using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{

    public Manager gm;
    private float rotationAmount = 90f;
    private bool isRotating = false;
    private Quaternion targetRotation;
    private Vector3 currentEulerAngles;


    private int yawvar = 0;
    private int rollvar = 0;

    private int lr = 0;
    private Vector2 touchStartPos;
    private bool isSwipe;


    void Start()
    {
        targetRotation = transform.rotation;
        currentEulerAngles = transform.eulerAngles;
    }

    void Update()
    {


        //gyro inputs
        Gyroscope gyro = Input.gyro;
        gyro.enabled = true;

        // default orientation of the device
        Vector3 tilt = Input.acceleration;
        tilt = Quaternion.Euler(90, 0, 0) * tilt;  
        Debug.Log(tilt);

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

        if (!isRotating)
        {
            Vector3 rotationDelta = Vector3.zero;  //Initial rotation

            // turn left and right
            if (Input.GetKeyDown(KeyCode.Keypad4) || lr == -1)
            {
                rotationDelta += new Vector3(0, rotationAmount, 0);
                yawvar = (yawvar - 1 + 4) % 4;
                lr = 0;
            }
            else if (Input.GetKeyDown(KeyCode.Keypad6) || lr == 1)
            {
                rotationDelta += new Vector3(0, -rotationAmount, 0);
                yawvar = (yawvar + 1) % 4;
                lr = 0;
            }
            


            if (yawvar == 0)
            {
                // roll left and right
                if (Input.GetKeyDown(KeyCode.Keypad7)||tilt.x < -0.8f)
                {
                    rotationDelta += new Vector3(0, 0, rotationAmount);
                }
                else if (Input.GetKeyDown(KeyCode.Keypad9)||tilt.x > 0.8f)
                {
                    rotationDelta += new Vector3(0, 0, -rotationAmount);
                }
            }
            else if (yawvar == 1)
            {
                // roll left and right
                if (Input.GetKeyDown(KeyCode.Keypad7)||tilt.x < -0.8f)
                {
                    rotationDelta += new Vector3(rotationAmount, 0, 0);
                }
                else if (Input.GetKeyDown(KeyCode.Keypad9)||tilt.x > 0.8f)
                {
                    rotationDelta += new Vector3(-rotationAmount, 0, 0);
                }
            }
            else if (yawvar == 2)
            {
                // roll left and right
                if (Input.GetKeyDown(KeyCode.Keypad7)||tilt.x < -0.8f)
                {
                    rotationDelta += new Vector3(0, 0, -rotationAmount);
                }
                else if (Input.GetKeyDown(KeyCode.Keypad9)||tilt.x > 0.8f)
                {
                    rotationDelta += new Vector3(0, 0, rotationAmount);
                }
            }
            else if (yawvar == 3)
            {
                 // roll left and right
                if (Input.GetKeyDown(KeyCode.Keypad7)||tilt.x < -0.8f)
                {
                    rotationDelta += new Vector3(-rotationAmount, 0, 0);
                }
                else if (Input.GetKeyDown(KeyCode.Keypad9)||tilt.x > 0.8f)
                {
                    rotationDelta += new Vector3(rotationAmount, 0, 0);
                }
            }



            if (rotationDelta != Vector3.zero)
            {
                currentEulerAngles += rotationDelta;
                currentEulerAngles.x = Mathf.Repeat(currentEulerAngles.x, 360);
                currentEulerAngles.y = Mathf.Repeat(currentEulerAngles.y, 360);
                targetRotation = Quaternion.Euler(currentEulerAngles);
                StartCoroutine(RotateToTarget());
            }
        }
    }

    IEnumerator RotateToTarget()
    {
        isRotating = true;
        Quaternion startRotation = transform.rotation;
        float t = 0f;

        while (t < gm.rotationCooldownSec)
        {
            t += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, gm.rotationSpeed * t);
            yield return null;
        }

        transform.rotation = targetRotation; // Ensure the target rotation is exactly reached
        isRotating = false;

        Debug.Log(transform.rotation.eulerAngles);
        Debug.Log(yawvar);
    }
}
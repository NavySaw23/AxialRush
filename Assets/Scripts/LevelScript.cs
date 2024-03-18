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

    private int turnvar = 0;

    void Start()
    {
        targetRotation = transform.rotation;
        currentEulerAngles = transform.eulerAngles;
    }

    void Update()
    {
        if (!isRotating)
        {
            Vector3 rotationDelta = Vector3.zero;  //Initial rotation

            // turn left and right
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                rotationDelta += new Vector3(0, rotationAmount, 0);
                turnvar = (turnvar - 1 + 4) % 4;
            }
            else if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                rotationDelta += new Vector3(0, -rotationAmount, 0);
                turnvar = (turnvar + 1) % 4;
            }
            


            if (turnvar == 0)
            {
                // roll left and right
                if (Input.GetKeyDown(KeyCode.Keypad7))
                {
                    rotationDelta += new Vector3(0, 0, rotationAmount);
                }
                else if (Input.GetKeyDown(KeyCode.Keypad9))
                {
                    rotationDelta += new Vector3(0, 0, -rotationAmount);
                }
            }
            else if (turnvar == 1)
            {
                // roll left and right
                if (Input.GetKeyDown(KeyCode.Keypad7))
                {
                    rotationDelta += new Vector3(rotationAmount, 0, 0);
                }
                else if (Input.GetKeyDown(KeyCode.Keypad9))
                {
                    rotationDelta += new Vector3(-rotationAmount, 0, 0);
                }
            }
            else if (turnvar == 2)
            {
                // roll left and right
                if (Input.GetKeyDown(KeyCode.Keypad7))
                {
                    rotationDelta += new Vector3(0, 0, -rotationAmount);
                }
                else if (Input.GetKeyDown(KeyCode.Keypad9))
                {
                    rotationDelta += new Vector3(0, 0, rotationAmount);
                }
            }
            else if (turnvar == 3)
            {
                 // roll left and right
                if (Input.GetKeyDown(KeyCode.Keypad7))
                {
                    rotationDelta += new Vector3(-rotationAmount, 0, 0);
                }
                else if (Input.GetKeyDown(KeyCode.Keypad9))
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
        Debug.Log(turnvar);
    }
}
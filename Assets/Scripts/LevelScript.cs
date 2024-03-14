using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    public float rotationAmount = 90f; // Rotation amount in degrees
    public float duration = 1f; // Duration of the rotation 
    private bool isRotating = false;
    private Quaternion targetRotation;
    private Vector3 currentEulerAngles;

    void Start()
    {
        targetRotation = transform.rotation;
        currentEulerAngles = transform.eulerAngles;
    }

    void Update()
    {
        if (!isRotating)
        {
            Vector3 rotationDelta = Vector3.zero;

            if (Input.GetKeyDown(KeyCode.Keypad7))
            {
                rotationDelta += new Vector3(0, 0, rotationAmount);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad8))
            {
                rotationDelta += new Vector3(rotationAmount, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad9))
            {
                rotationDelta += new Vector3(0, 0, -rotationAmount);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                rotationDelta += new Vector3(-rotationAmount, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                rotationDelta += new Vector3(0, rotationAmount, 0);
            }
            else if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                rotationDelta += new Vector3(0, -rotationAmount, 0);
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

        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, t);
            yield return null;
        }

        transform.rotation = targetRotation; // Ensure the target rotation is exactly reached
        isRotating = false;
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class LevelScript : MonoBehaviour
// {
//     public float rotationAmount = 90f; // Rotation amount in degrees
//     public float duration = 1f; // Duration of the rotation 
//     private bool isRotating = false;
//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.Keypad7) && !isRotating)
//         {
//             StartCoroutine(Rotate(Vector3.forward));
//         }
//         if (Input.GetKeyDown(KeyCode.Keypad5) && !isRotating)
//         {
//             StartCoroutine(Rotate(Vector3.left));
//         }
//         if (Input.GetKeyDown(KeyCode.Keypad9) && !isRotating)
//         {
//             StartCoroutine(Rotate(Vector3.back));
//         }
//         if (Input.GetKeyDown(KeyCode.Keypad8) && !isRotating)
//         {
//             StartCoroutine(Rotate(Vector3.right));
//         }if (Input.GetKeyDown(KeyCode.Keypad4) && !isRotating)
//         {
//             StartCoroutine(Rotate(Vector3.up));
//         }if (Input.GetKeyDown(KeyCode.Keypad6) && !isRotating)
//         {
//             StartCoroutine(Rotate(Vector3.down));
//         }

//     }

//     IEnumerator Rotate(Vector3 axis)
//     {
//         isRotating = true;
//         Vector3 worldAxis = transform.TransformDirection(axis); // Convert local axis to world axis
//         float rotationProgress = 0f;
//         float rotationSpeed = rotationAmount / duration;

//         while (rotationProgress < rotationAmount)
//         {
//             float rotationStep = rotationSpeed * Time.deltaTime;
//             transform.Rotate(worldAxis, rotationStep, Space.World);
//             rotationProgress += rotationStep;
//             yield return null;
//         }

//         isRotating = false;
//     }
// }

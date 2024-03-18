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



//v2--------------

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class LevelScript : MonoBehaviour
// {
//     public Manager gm;
//     private float rotationAmount = 90f; // Rotation amount in degrees
//     private bool isRotating = false;
//     private Quaternion targetRotation;
//     private Vector3 currentEulerAngles;

//     void Start()
//     {
//         targetRotation = transform.rotation;
//         currentEulerAngles = transform.eulerAngles;
//     }

//     void Update()
//     {
//         if (!isRotating)
//         {
//             Vector3 rotationDelta = Vector3.zero;

//             if (Input.GetKeyDown(KeyCode.Backslash))
//             {
//                 rotationDelta += new Vector3(0, 0, rotationAmount);
//             }
//             else if (Input.GetKeyDown(KeyCode.Keypad8))
//             {
//                 rotationDelta += new Vector3(rotationAmount, 0, 0);
//             }
//             else if (Input.GetKeyDown(KeyCode.Keypad9))
//             {
//                 rotationDelta += new Vector3(0, 0, -rotationAmount);
//             }
//             else if (Input.GetKeyDown(KeyCode.Keypad5))
//             {
//                 rotationDelta += new Vector3(-rotationAmount, 0, 0);
//             }
//             else if (Input.GetKeyDown(KeyCode.Keypad4))
//             {
//                 rotationDelta += new Vector3(0, rotationAmount, 0);
//             }
//             else if (Input.GetKeyDown(KeyCode.Keypad6))
//             {
//                 rotationDelta += new Vector3(0, -rotationAmount, 0);
//             }

//             if (rotationDelta != Vector3.zero)
//             {
//                 currentEulerAngles += rotationDelta;
//                 currentEulerAngles.x = Mathf.Repeat(currentEulerAngles.x, 360);
//                 currentEulerAngles.y = Mathf.Repeat(currentEulerAngles.y, 360);
//                 targetRotation = Quaternion.Euler(currentEulerAngles);
//                 StartCoroutine(RotateToTarget());
//             }
//         }
//     }

//     IEnumerator RotateToTarget()
//     {
//         isRotating = true;
//         Quaternion startRotation = transform.rotation;
//         float t = 0f;

//         while (t < gm.rotationCooldownSec)
//         {
//             t += Time.deltaTime;
//             transform.rotation = Quaternion.Lerp(startRotation, targetRotation, gm.rotationSpeed*t);
//             yield return null;
//         }

//         transform.rotation = targetRotation; // Ensure the target rotation is exactly reached
//         isRotating = false;
//     }
// }


// ----------------------------------------------------------------------------------------------
// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class LevelScript : MonoBehaviour
// {
//     public Manager gm;
//     private float rotationAmount = 90f;
//     private bool isRotating = false;
//     private Quaternion targetRotation;
//     private Vector3 currentEulerAngles;

//     private int turnvar = 0;

//     void Start()
//     {
//         targetRotation = transform.rotation;
//         currentEulerAngles = transform.eulerAngles;
//     }

//     void Update()
//     {
//         if (!isRotating)
//         {
//             Vector3 rotationDelta = Vector3.zero;  //Initial rotation

//             // turn left and right
//             if (Input.GetKeyDown(KeyCode.Keypad4))
//             {
//                 rotationDelta += new Vector3(0, rotationAmount, 0);
//                 turnvar = (turnvar - 1 + 4) % 4;
//             }
//             else if (Input.GetKeyDown(KeyCode.Keypad6))
//             {
//                 rotationDelta += new Vector3(0, -rotationAmount, 0);
//                 turnvar = (turnvar + 1) % 4;
//             }
            


//             if (turnvar == 0)
//             {
//                 // roll left and right
//                 if (Input.GetKeyDown(KeyCode.Keypad7))
//                 {
//                     rotationDelta += new Vector3(0, 0, rotationAmount);
//                 }
//                 else if (Input.GetKeyDown(KeyCode.Keypad9))
//                 {
//                     rotationDelta += new Vector3(0, 0, -rotationAmount);
//                 }
//             }
//             else if (turnvar == 1)
//             {
//                 // roll left and right
//                 if (Input.GetKeyDown(KeyCode.Keypad7))
//                 {
//                     rotationDelta += new Vector3(rotationAmount, 0, 0);
//                 }
//                 else if (Input.GetKeyDown(KeyCode.Keypad9))
//                 {
//                     rotationDelta += new Vector3(-rotationAmount, 0, 0);
//                 }
//             }
//             else if (turnvar == 2)
//             {
//                 // roll left and right
//                 if (Input.GetKeyDown(KeyCode.Keypad7))
//                 {
//                     rotationDelta += new Vector3(0, 0, -rotationAmount);
//                 }
//                 else if (Input.GetKeyDown(KeyCode.Keypad9))
//                 {
//                     rotationDelta += new Vector3(0, 0, rotationAmount);
//                 }
//             }
//             else if (turnvar == 3)
//             {
//                  // roll left and right
//                 if (Input.GetKeyDown(KeyCode.Keypad7))
//                 {
//                     rotationDelta += new Vector3(-rotationAmount, 0, 0);
//                 }
//                 else if (Input.GetKeyDown(KeyCode.Keypad9))
//                 {
//                     rotationDelta += new Vector3(rotationAmount, 0, 0);
//                 }
//             }



//             if (rotationDelta != Vector3.zero)
//             {
//                 currentEulerAngles += rotationDelta;
//                 currentEulerAngles.x = Mathf.Repeat(currentEulerAngles.x, 360);
//                 currentEulerAngles.y = Mathf.Repeat(currentEulerAngles.y, 360);
//                 targetRotation = Quaternion.Euler(currentEulerAngles);
//                 StartCoroutine(RotateToTarget());
//             }
//         }
//     }

//     IEnumerator RotateToTarget()
//     {
//         isRotating = true;
//         Quaternion startRotation = transform.rotation;
//         float t = 0f;

//         while (t < gm.rotationCooldownSec)
//         {
//             t += Time.deltaTime;
//             transform.rotation = Quaternion.Lerp(startRotation, targetRotation, gm.rotationSpeed * t);
//             yield return null;
//         }

//         transform.rotation = targetRotation; // Ensure the target rotation is exactly reached
//         isRotating = false;

//         Debug.Log(transform.rotation.eulerAngles);
//         Debug.Log(turnvar);
//     }
// }
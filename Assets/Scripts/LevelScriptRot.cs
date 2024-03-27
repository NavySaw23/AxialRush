

// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UIElements;

// public class LevelScript : MonoBehaviour
// {

//     public Manager gm;
//     // private float rotationAmount = 90f;
//     private bool isRotating = false;
//     private Quaternion targetRotation;
//     // private Vector3 currentEulerAngles;


//     // private int yawvar = 0;
//     private int lr = 0;
//     private Vector2 touchStartPos;
//     private bool isSwipe;

//     public int i = 0;


//     void Start()
//     {
//         targetRotation = gm.position.Current.DirQuat;
//         // currentEulerAngles = transform.eulerAngles;
//     }

//     void Update()
//     {


//         //gyro inputs
//         Gyroscope gyro = Input.gyro;
//         gyro.enabled = true;

//         // default orientation of the device
//         Vector3 tilt = Input.acceleration;
//         tilt = Quaternion.Euler(90, 0, 0) * tilt;  
//         Debug.Log(tilt);

//         // touch inputs (swipe)
//         if (Input.touchCount > 0)
//         {
//             Touch touch = Input.GetTouch(0);

//             if (touch.phase == TouchPhase.Began)
//             {
//                 touchStartPos = touch.position;
//                 isSwipe = true;
//             }
//             else if (touch.phase == TouchPhase.Moved && isSwipe)
//             {
//                 float deltaX = touch.position.x - touchStartPos.x;
//                 float deltaY = touch.position.y - touchStartPos.y;

//                 if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
//                 {
//                     if (deltaX < 0) // Left swipe detected
//                     {
//                         lr = -1;
//                     }
//                     else if (deltaX > 0) // Right swipe detected
//                     {
//                         lr = 1;
//                     }
//                 }

//                 isSwipe = false;
//             }
//         }



//         //rotation phyics

//         if (!isRotating)
//         {
//             // turn left and right
//             if (Input.GetKeyDown(KeyCode.Keypad4))
//             {
//                 gm.position.Current = gm.position.Current.Lturn;
//             }
//             if (Input.GetKeyDown(KeyCode.Keypad6))
//             {
//                 gm.position.Current = gm.position.Current.Rturn;
//             }
//             if (Input.GetKeyDown(KeyCode.Keypad7))
//             {
//                 gm.position.Current = gm.position.Current.Lroll;
//             }
//             if (Input.GetKeyDown(KeyCode.Keypad9))
//             {
//                 gm.position.Current = gm.position.Current.Rroll;
//             }
//             if (Input.GetKeyDown(KeyCode.Keypad0))
//             {
//                 gm.position.Current = gm.position.RW;
//             }

//             if (targetRotation != gm.position.Current.DirQuat)
//             {
//                 targetRotation = gm.position.Current.DirQuat;
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

//         Debug.Log(i++ + " current " + gm.position.Current.name + " | " + gm.position.Current.DirQuat.x + ", " + gm.position.Current.DirQuat.y + ", " + gm.position.Current.DirQuat.z + ", " + gm.position.Current.DirQuat.w + ", ");
//     }
// }
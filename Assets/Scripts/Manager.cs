using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Rigidbody Player;
    public rotationMatrix position;

    public float rotationCooldownSec = 0.4f;
    public float rotationSpeed = 3f;

    //camera bobbing
    public float bobbingSpeed = 14.0f;
    public float bobbingAmount = 0.05f;


    void Start()
    {
        Physics.gravity = new Vector3(0f, -100f, 0f);
    }

    // void Update(){
    //     if(Input.GetKeyDown(KeyCode.Keypad0)){
    //         position.Current = position.Current.Lturn;
    //         Debug.Log(position.Current.DirQuat);
    //     }
    // }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Rigidbody Player;



    public float rotationCooldownSec = 0.4f;
    public float rotationSpeed = 3f;


    void Start()
    {
        Physics.gravity = new Vector3(0f, -100f, 0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crash : MonoBehaviour
{
    public Manager gm;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("crash"))
        {
            Debug.Log("crash");
        }
    }
}

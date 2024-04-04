using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crash : MonoBehaviour
{
    public Manager gm;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("crash") || collision.gameObject.CompareTag("crash_"))
        {
            // Debug.Log("crash");
            gm.gameoverText.text = "Should have worn a helmet";
            gm.gameover = true;

        }
    }
}

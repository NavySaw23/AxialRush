using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burn : MonoBehaviour
{
    public Manager gm;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("burn"))
        {
            // Debug.Log("burn");
            gm.gameoverText.text = "THE FLOOR IS LAVA!";
            gm.gameover = true;
        }
    }
}

using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Manager gm;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("crash"))
        {
            gm.points++;
        }
    }

}

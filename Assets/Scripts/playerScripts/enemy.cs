using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Manager gm;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            
            if(gm.isAttacking){
                Destroy(collision.gameObject);
                gm.points += 5;
                Debug.Log("Hit");
            }
            else{
                gm.gameoverText.text = "That stings....";
                gm.gameover = true;
            }

        }
    }
}

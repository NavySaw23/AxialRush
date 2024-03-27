using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameovers : MonoBehaviour
{
    public Manager gm;
    
    void Update()
    {
        if(gm.Player.velocity.y < -10){
            // Debug.Log("Fall");
            gm.gameoverText.text = "Player fell down";
            gm.gameover = true;

        }
    }
}

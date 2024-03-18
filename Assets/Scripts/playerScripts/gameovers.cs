using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameovers : MonoBehaviour
{
    public Manager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.Player.velocity.y < -5){
            Debug.Log("Falllll");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class segmentScript : MonoBehaviour
{
    public float speed = 5.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.parent.parent.forward * speed * Time.deltaTime;

        if(transform.position.z < -100){
            GameObject.Destroy(transform.gameObject);
        }
    }
}

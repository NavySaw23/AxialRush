using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobscript : MonoBehaviour
{
    public Manager gm;

    private float defaultPosY = 0;
    private float timer = 0;

    void Start()
    {
        defaultPosY = transform.localPosition.y;
    }

    void Update()
    {
        float waveslice = Mathf.Sin(timer);
        timer += gm.bobbingSpeed * Time.deltaTime;
        if (timer > Mathf.PI * 2)
        {
            timer -= (Mathf.PI * 2);
        }
        transform.localPosition = new Vector3(transform.localPosition.x,
                                              defaultPosY + waveslice * gm.bobbingAmount,
                                              transform.localPosition.z);
    }
}



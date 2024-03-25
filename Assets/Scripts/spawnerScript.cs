using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    public GameObject prefabToSpawn; // Assign your prefab in the inspector
    Vector3 pos;

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        transform.position = pos;
    }

    // This method is called when the trigger collides with another object
    void OnTriggerEnter(Collider other)
    {
        // Check if the object has the tag 'segment'
        if (other.gameObject.CompareTag("segment"))
        {
            // Instantiate the prefab at the position you want
            Instantiate(prefabToSpawn, pos, Quaternion.identity);
        }
    }
}

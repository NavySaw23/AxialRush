using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public GameObject parentObject;
    Vector3 pos;

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        transform.position = pos;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("segment"))
        {
            Debug.Log("spawn");
            GameObject instantiatedObject = Instantiate(prefabToSpawn, pos, Quaternion.identity);
            instantiatedObject.transform.parent = parentObject.transform;
        }
    }
}

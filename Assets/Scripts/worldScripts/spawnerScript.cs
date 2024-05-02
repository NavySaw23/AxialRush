using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] prefabsToSpawn; // Array of prefabs
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
            // Debug.Log("spawn");
            int randomIndex = Random.Range(0, prefabsToSpawn.Length); // Get a random index
            GameObject instantiatedObject = Instantiate(prefabsToSpawn[randomIndex], pos, Quaternion.identity);
            instantiatedObject.transform.parent = parentObject.transform;
        }
    }
}

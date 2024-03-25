using UnityEngine;

public class keybreak : MonoBehaviour
{
    public Manager gm;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("key"))
        {
            Destroy(collision.gameObject.transform.parent.gameObject);
            Debug.Log("key");
        }
    }
}
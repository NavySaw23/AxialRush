using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Include this namespace if your image component is from Unity UI

public class blink : MonoBehaviour
{
    public float minTime = 2f; // Minimum time for blinking
    public float maxTime = 2f; // Maximum time for blinking

    private Image imageComponent; // Reference to the Image component

    // Start is called before the first frame update
    void Start()
    {
        // Get the Image component attached to this GameObject
        imageComponent = GetComponent<Image>();

        // Start the coroutine for blinking
        StartCoroutine(BlinkRoutine());
    }

    // Coroutine for blinking
    IEnumerator BlinkRoutine()
    {
        while (true)
        {
            // Randomly choose a time to wait before toggling the image
            float waitTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);

            // Toggle the visibility of the image component
            imageComponent.enabled = !imageComponent.enabled;
        }
    }
}

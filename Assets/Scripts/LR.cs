using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LR : MonoBehaviour
{
    RectTransform imageTransform; // Reference to the RectTransform of your UI image
    public Vector2 pointA; // Starting position
    public Vector2 pointB; // Ending position
    public float speed = 1f; // Movement speed

    private bool movingToB = true; // Flag to track direction of movement

    void Start()
    {
        imageTransform = GetComponent<RectTransform>();
        imageTransform.anchoredPosition = pointA;
    }

    void Update()
    {

        if (movingToB)
        {
            imageTransform.anchoredPosition = Vector2.MoveTowards(imageTransform.anchoredPosition, pointB, speed * Time.deltaTime);
            if (imageTransform.anchoredPosition == pointB)
            {
                movingToB = false; // Change direction
            }
        }
        else
        {
            imageTransform.anchoredPosition = pointA;
            movingToB = true; // Change direction
        }
    }
}

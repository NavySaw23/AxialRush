using UnityEngine;
using UnityEngine.UI;

public class StartSign : MonoBehaviour
{
    private Button button;
    private bool isBlinking = false;
    private float blinkTimer = 0f;

    void Start()
    {
        button = GetComponent<Button>();
        blinkTimer = 0.5f; // Start with blue color for 0.5 seconds
    }

    void Update()
    {
        blinkTimer -= Time.deltaTime;

        if (blinkTimer <= 0f)
        {
            if (isBlinking)
            {
                button.image.color = Color.white;
                isBlinking = false;
                blinkTimer = 4f;
            }
            else
            {
                button.image.color = new Color(1f, 1f, 1f, 0.7f); // White with 70% transparency
                isBlinking = true;
                blinkTimer = 0.3f; 
            }
        }
    }
}

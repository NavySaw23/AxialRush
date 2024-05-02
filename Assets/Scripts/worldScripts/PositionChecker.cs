using UnityEngine;
using System.Collections;

public class PositionChecker : MonoBehaviour
{
    public float checkInterval = 2.0f; // Time in seconds to wait before checking position
    public float tolerance = 0.1f; // Tolerance for position change
    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
        StartCoroutine(PositionCheckRoutine());
    }

    IEnumerator PositionCheckRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkInterval);
            CheckAndAdjustPosition();
        }
    }

    void CheckAndAdjustPosition()
    {
        Vector3 newPosition = transform.position;

        if (Mathf.Abs(newPosition.x - lastPosition.x) < tolerance)
        {
            newPosition.x = AdjustToMultipleOfFive(newPosition.x);
        }
        if (Mathf.Abs(newPosition.y - lastPosition.y) < tolerance)
        {
            newPosition.y = AdjustToMultipleOfFive(newPosition.y);
        }
        if (Mathf.Abs(newPosition.z - lastPosition.z) < tolerance)
        {
            newPosition.z = AdjustToMultipleOfFive(newPosition.z);
        }

        transform.position = newPosition;
        lastPosition = transform.position;
    }

    float AdjustToMultipleOfFive(float value)
    {
        return Mathf.Round(value / 5) * 5;
    }
}

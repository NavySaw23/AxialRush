using UnityEngine;

public class FreeCamScript : MonoBehaviour
{
    public bool Freecam = true;
    public float speed = 5.0f;
    public float sensitivity = 2.0f;
    private Camera playerCamera;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
    }

    void Update()
    {
        if(Freecam){
            // Player movement - WASD
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(x, 0, z);

        // Camera rotation - Mouse
        yaw += sensitivity * Input.GetAxis("Mouse X");
        pitch -= sensitivity * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -90f, 90f); // Limit the pitch so the camera doesn't flip

        playerCamera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }   
    }
}

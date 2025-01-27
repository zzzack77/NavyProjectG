using System.Collections;
using UnityEngine;

public class SimpleCameraMovement : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float moveSpeed = 5f; // Speed of movement

    private float xRotation = 0f;
    private float yRotation = 0f;

    private bool cameraCanMove = false;

    // Start is called before the first frame update
    void Start()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        StartCoroutine(CameraWait());
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraCanMove)
        {
            // Get mouse input
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            // Adjust the camera's rotation for looking up and down
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Prevent the camera from flipping over

            yRotation += mouseX;

            // Rotate the camera horizontally (around the Y-axis)
            transform.Rotate(Vector3.up * mouseX);

            // Apply vertical rotation by adjusting the camera's local rotation around the X-axis
            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        }
     

        


    }
    IEnumerator CameraWait()
    {
        yield return new WaitForSeconds(0.1f);
        cameraCanMove = true;
    }
}

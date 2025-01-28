using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement

    private float xRotation = 0f;
    private float yRotation = 0f;

    private float mouseX;
    private float mouseY;


    [SerializeField] private float floatX;
    [SerializeField] private float floatY;

    [SerializeField] private float maxX;
    [SerializeField] private float minX;
    [SerializeField] private float maxY;
    [SerializeField] private float minY;
    Vector3 mousePos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        Debug.Log(mousePos);

        if (mousePos.x >= maxX)
        {
            mouseX = 1f * moveSpeed * Time.deltaTime;
        }
        else if (mousePos.x <= minX)
        {
            mouseX = -1f * moveSpeed * Time.deltaTime;
        }
        else
        {
            mouseX = 0f;
        }

        if (mousePos.y >= maxY)
        {
            mouseY = 1f * moveSpeed * Time.deltaTime;
        }
        else if (mousePos.y <= minY)
        {
            mouseY = -1f * moveSpeed * Time.deltaTime;
        }
        else
        {
            mouseY = 0f;
        }

        

        // Adjust the camera's rotation for looking up and down
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Prevent the camera from flipping over

        yRotation += mouseX;


        // Apply vertical rotation by adjusting the camera's local rotation around the X-axis
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

    }
}

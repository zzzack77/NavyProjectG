using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseMovement : MonoBehaviour
{
    public float moveSpeed; // Speed of movement

    private float xRotation = 12f;
    private float yRotation = 0f;

    private float mouseX;
    private float mouseY;

    [SerializeField] private float maxX = 2050;
    [SerializeField] private float minX = -150;
    [SerializeField] private float maxY = 1050;
    [SerializeField] private float minY = 50;

    Vector3 mousePos;

    // Update is called once per frame
    void Update()
    {
        // Get the mouse position
        mousePos = Input.mousePosition;

        // Horizontal movement logic (X-Axis)
        if (mousePos.x >= maxX) // Moving to the right
        {
            mouseX = 1f * moveSpeed * Time.deltaTime;
        }
        else if (mousePos.x <= minX) // Moving to the left
        {
            mouseX = -1f * moveSpeed * Time.deltaTime;
        }
        else
        {
            mouseX = 0f;
        }

        // Vertical movement logic (Y-Axis)
        if (mousePos.y >= maxY) // Moving up
        {
            mouseY = 1f * moveSpeed * Time.deltaTime;
        }
        else if (mousePos.y <= minY) // Moving down
        {
            mouseY = -1f * moveSpeed * Time.deltaTime;
        }
        else
        {
            mouseY = 0f;
        }

        // Adjust the camera's rotation for looking up and down (X axis)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Prevent the camera from flipping over

        // Adjust the camera's rotation for left and right (Y axis)
        yRotation += mouseX;

        // Apply the rotations to the camera
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBoatMovement : MonoBehaviour
{
    public float moveSpeed = 5f;   // Speed of movement
    public float rotateSpeed = 100f; // Speed of rotation

    private void Update()
    {
        // Get input for movement (W/S or up/down arrow)
        float moveInput = Input.GetAxis("Vertical"); // Forward = 1, Backward = -1

        // Get input for rotation (A/D or left/right arrow)
        float rotateInput = Input.GetAxis("Horizontal"); // Left = -1, Right = 1

        // Move the player forward or backward based on input
        Vector3 moveDirection = transform.forward * moveInput * moveSpeed * Time.deltaTime;
        transform.Translate(moveDirection, Space.World);

        // Rotate the player based on horizontal input
        transform.Rotate(0f, rotateInput * rotateSpeed * Time.deltaTime, 0f);
    }
}

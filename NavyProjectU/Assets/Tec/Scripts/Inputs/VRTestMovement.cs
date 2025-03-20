using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class VRTestMovement : MonoBehaviour
{
    private float speed = 0.2f;
    int y = 0;
    Vector3 offset;

    float horizontal;
    float vertical;

    void Update()
    {
        Vector3 direction = new Vector3(horizontal, (float)y, vertical).normalized;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = -1;
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 1;
        }
        else
        {
            horizontal = 0;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            vertical = 1;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            vertical = -1;
        }

        else
        {
            vertical = 0;   
        }

        if (Input.GetKey(KeyCode.Space))
        {
            y = 1;
            Debug.Log("Space");
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            y = 0;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            y = -1;
            Debug.Log("Shift");
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            y = 0;
        }

        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}

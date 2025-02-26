using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SteeringWheelDebug : MonoBehaviour
{
    


    void Start()
    {
        
    }

    
    void Update()
    {
        Debug.Log("Fire1: " + Input.GetAxis("Fire1"));
        Debug.Log("Fire2: " + Input.GetAxis("Fire2"));
        Debug.Log("Fire3: " + Input.GetAxis("Fire3"));
        Debug.Log("Jump: " + Input.GetAxis("Jump"));
    }
}

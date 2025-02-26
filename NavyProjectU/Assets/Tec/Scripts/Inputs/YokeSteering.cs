using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class YokeSteering : MonoBehaviour
{
    //InputAction Turning;
    public float steeringInput;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        steeringInput = Input.GetAxis("Horizontal");
    }
}

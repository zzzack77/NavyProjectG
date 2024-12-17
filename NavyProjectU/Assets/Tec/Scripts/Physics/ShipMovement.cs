using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;

public class ShipMovement : MonoBehaviour
{

    public Rigidbody rb;
    
    public float accelInput = 0.0f;
    public float steeringInput = 0.0f;
    public float shipPower = 5.0f;

    public float suspensionRestDist;
    public float springStrength;
    public float springDamper;

    public float dragFactor;
    public float boatWeight;
    public float boatTopSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       

        Vector3 forwardDirection = transform.forward;

        
        // Throttle code slowly ups the throttle the longer you press the forward and backward keys.
        // This will need to be mapped to the throttle axis once we connect it all up.

        if (Input.GetKey(KeyCode.W))
        {
            
            accelInput = accelInput + 0.001f;
            
            if(accelInput > 1.0f)
            {
                accelInput = 1.0f;
            }
        }
        else if(Input.GetKey(KeyCode.S))
        {
            accelInput = accelInput - 0.001f;

            if (accelInput < -1.0f)
            {
                accelInput = -1.0f;
            }
        }

        // Steering code turns the rudder when the A and D keys are pressed.
        // Once the steering wheel is connected to the project, this will need to be mapped to its axis.

        if (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.D))
        {
            steeringInput = 0.0f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            steeringInput = 1.0f;

        }
        else if (Input.GetKey(KeyCode.D))
        {
            steeringInput = -1.0f;
        }
        else
        {
            steeringInput = 0.0f;
        }
    }
}

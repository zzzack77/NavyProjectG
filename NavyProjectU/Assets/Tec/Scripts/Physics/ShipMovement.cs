using System.Collections;
using System.Collections.Generic;


//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;

public class ShipMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float accelInput = 0.0f;
    public float steeringInput = 0.0f;
    public float shipPower = 4000000.0f;

    public float suspensionRestDist = 5;
    public float springStrength = 20000000.0f;
    public float springDamper = 2000.0f;

    public float dragFactor = 1000.0f;
    public float dragCoefficient = 350000.0f;
    public float heelMultiplier = 1000.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {       

        Vector3 forwardDirection = transform.forward;

        var localV = transform.InverseTransformDirection(rb.velocity);

        float boatSpeedkph = localV.z * 3.6f;
        float boatSpeedkn = localV.z * 1.944f;

        UnityEngine.Debug.Log("Velocity: " + boatSpeedkph + "km/h");
        UnityEngine.Debug.Log("Velocity: " + boatSpeedkn + "knots");


        // Throttle code slowly ups the throttle the longer you press the forward and backward keys.
        // This will need to be mapped to the throttle axis once we connect it all up.

        if (Input.GetKey(KeyCode.W))
        {
            
            accelInput = accelInput + 0.01f;
            
            if(accelInput > 1.0f)
            {
                accelInput = 1.0f;
            }
        }
        else if(Input.GetKey(KeyCode.S))
        {
            accelInput = accelInput - 0.01f;

            if (accelInput < -1.0f)
            {
                accelInput = -1.0f;
            }
        }

        // Steering code turns the rudder when the A and D keys are pressed.
        // Once the steering wheel is connected to the project, this will need to be mapped to its axis.

        if (Input.GetKey(KeyCode.A))
        {
            steeringInput = steeringInput + 1f;

            if(steeringInput > 35.0f)
            {
                steeringInput = 35.0f;
            }

        }
        else if (Input.GetKey(KeyCode.D))
        {
            steeringInput = steeringInput - 1f;

            if(steeringInput < -35.0f)
            {
                steeringInput = -35.0f;
            }
        }
    }
}

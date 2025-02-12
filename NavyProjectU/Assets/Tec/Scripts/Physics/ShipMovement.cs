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
    public float shipPower = 3500000.0f;

    public float suspensionRestDist = 5.0f;
    public float springStrength = 15000000.0f;
    public float springDamper = 40.0f;

    public float dragFactor = 0.5f;
    public float dragCoefficient = 425000.0f;
    public float boatWeight = 1.0f;

    private float rpmEngineMax = 3000.0f;
    private float rpmEngineStarboard = 0.0f;
    private float rpmEnginePort = 0.0f;

    public float rpmPropMax = 250.0f;
    public float rpmPropStarboard = 0.0f;
    public float rpmPropPort = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {       

        Vector3 forwardDirection = transform.forward;

        var LocalV = transform.InverseTransformDirection(rb.velocity);

        float boatSpeedkph = LocalV.z * 3.6f;
        float boatSpeedkn = LocalV.z * 1.944f;

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


        // RPM code

        float rpmInput = accelInput * rpmPropMax;

        // Starborad Propeller

        if (rpmInput > rpmPropStarboard)
        {
            rpmPropStarboard = rpmPropStarboard + 1.0f;
            if(rpmPropStarboard > rpmInput)
            {
                rpmPropStarboard = rpmInput;
            }

        }
        else if(rpmInput < rpmPropStarboard)
        {
            rpmPropStarboard = rpmPropStarboard - 1.0f;
            if (rpmPropStarboard < rpmInput)
            {
                rpmPropStarboard = rpmInput;
            }
        }

        // Port Propeller

        if (rpmInput > rpmPropPort)
        {
            rpmPropPort = rpmPropPort + 1.0f;
            if (rpmPropPort > rpmInput)
            {
                rpmPropPort = rpmInput;
            }

        }
        else if (rpmInput < rpmPropPort)
        {
            rpmPropPort = rpmPropPort - 1.0f;
            if (rpmPropPort < rpmInput)
            {
                rpmPropPort = rpmInput;
            }
        }

        //UnityEngine.Debug.Log("Input RPM: " + rpmInput);
        //UnityEngine.Debug.Log("Starboard Prop RPM: " + rpmPropStarboard);
        //UnityEngine.Debug.Log("Port Prop RPM: " + rpmPropPort);


        // Steering code turns the rudder when the A and D keys are pressed.
        // Once the steering wheel is connected to the project, this will need to be mapped to its axis.

        if (Input.GetKey(KeyCode.A))
        {
            steeringInput = steeringInput + 0.5f;

            if(steeringInput > 35.0f)
            {
                steeringInput = 35.0f;
            }

        }
        else if (Input.GetKey(KeyCode.D))
        {
            steeringInput = steeringInput - 0.5f;

            if(steeringInput < -35.0f)
            {
                steeringInput = -35.0f;
            }
        }
    }
}

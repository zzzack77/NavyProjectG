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
        //Ray ray;

        //ray = new Ray(transform.position, transform.forward);
        //if(Physics.Raycast(ray, out RaycastHit hit))
        //{
        //    Debug.Log("HitTest");
        //    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

        //}

        Vector3 forwardDirection = transform.forward;

        if (Input.GetKey(KeyCode.W))
        {
            //Debug.Log("Hello");
            accelInput = accelInput + 0.001f;
            //rb.AddForceAtPosition(forwardDirection * 200.0f, transform.position);

            if(accelInput > 1.0f)
            {
                accelInput = 1.0f;
            }

            //UnityEngine.Debug.Log(accelInput);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            accelInput = accelInput - 0.001f;

            if (accelInput < -1.0f)
            {
                accelInput = -1.0f;
            }

            //UnityEngine.Debug.Log(accelInput);

        }

        if (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.D))
        {
            steeringInput = 0.0f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            steeringInput = 1.0f;
            //UnityEngine.Debug.Log("A");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            steeringInput = -1.0f;
            //UnityEngine.Debug.Log("D");
        }
        else
        {
            steeringInput = 0.0f;
        }

        //UnityEngine.Debug.Log(steeringInput);

    }
}

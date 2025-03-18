using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;


public class TraceMovement : MonoBehaviour
{

    public Transform traceParent;
    public Rigidbody boatRigidBody;
    public ShipMovement parentScript;

    public bool bBouyancy;
    public bool bTurning;
    public bool bPower;

    public bool Starboard;

    // Start is called before the first frame update
    void Start()
    {
        traceParent = transform.parent;
        boatRigidBody = traceParent.GetComponent<Rigidbody>();
        parentScript = traceParent.GetComponent<ShipMovement>();
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        bool traceHit = Physics.Raycast(transform.position, -transform.up, out hit, 10.0f);

        UnityEngine.Debug.DrawRay(transform.position, -transform.up * hit.distance, Color.red);

        if (bBouyancy)
        {
            UnityEngine.Debug.DrawRay(transform.position, -transform.up * hit.distance, Color.red);
            //UnityEngine.Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.blue);

            if (traceHit)
            {
                Vector3 springDir = transform.up;

                Vector3 traceWorldVel = boatRigidBody.GetPointVelocity(transform.position);

                float offset = parentScript.suspensionRestDist - hit.distance;

                float vel = Vector3.Dot(springDir, traceWorldVel);

                float force = (offset * parentScript.springStrength) - (vel * parentScript.springDamper);

                boatRigidBody.AddForceAtPosition(springDir * force, transform.position);
            }


        }
        
        if (bTurning)
        {

            UnityEngine.Debug.DrawRay(transform.position, -transform.up * hit.distance, Color.yellow);
            UnityEngine.Debug.DrawRay(transform.position, transform.forward * 4.0f, Color.blue);

            if (traceHit)
            {
                Vector3 steeringDir = transform.right;

                Vector3 traceWorldVel = boatRigidBody.GetPointVelocity(transform.position);

                float steeringVel = Vector3.Dot(steeringDir, traceWorldVel);

                float desiredVelChange = -steeringVel * parentScript.dragFactor;

                float desiredAccel = desiredVelChange / Time.fixedDeltaTime;

                boatRigidBody.AddForceAtPosition(steeringDir * parentScript.boatWeight * desiredAccel, transform.position);
            }
        }
        
        if (bPower)
        {
            //UnityEngine.Debug.DrawRay(transform.position, -transform.up * hit.distance, Color.green);
            //UnityEngine.Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.blue);

            Vector3 accelDir = transform.forward;

            if (Starboard)
            {
                if (parentScript.starPower != 0.0f)
                {
                    float boatSpeed = Vector3.Dot(transform.forward, boatRigidBody.velocity);

                    float normalizedSpeed = Mathf.Clamp01(Mathf.Abs(boatSpeed));

                    float availableTorque = parentScript.shipPower * parentScript.starPower;

                    boatRigidBody.AddForceAtPosition(accelDir * availableTorque, transform.position);

                    //UnityEngine.Debug.Log("Acceleration Force: " + (accelDir * availableTorque).magnitude);

                }
            }
            else
            {
                if (parentScript.portPower != 0.0f)
                {
                    float boatSpeed = Vector3.Dot(transform.forward, boatRigidBody.velocity);

                    float normalizedSpeed = Mathf.Clamp01(Mathf.Abs(boatSpeed));

                    float availableTorque = parentScript.shipPower * parentScript.portPower;

                    boatRigidBody.AddForceAtPosition(accelDir * availableTorque, transform.position);

                    //UnityEngine.Debug.Log("Acceleration Force: " + (accelDir * availableTorque).magnitude);

                }
            }

            var localVel = transform.InverseTransformDirection(parentScript.rb.velocity);

            float rearDrag = 0.5f * parentScript.dragCoefficient * (localVel.z * parentScript.rb.velocity.magnitude);
            float forwardDrag = 0.5f * parentScript.rearDragCoefficient * (localVel.z * parentScript.rb.velocity.magnitude);

            //UnityEngine.Debug.Log("Drag Force: " + (-accelDir * rearDrag).magnitude);
            if(localVel.z > 0)
            {
                boatRigidBody.AddForceAtPosition(-accelDir * rearDrag, parentScript.rb.transform.position);
            }
            else if(localVel.z < 0)
            {
                boatRigidBody.AddForceAtPosition(-accelDir * forwardDrag, parentScript.rb.transform.position);
            }

        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class TraceMovement : MonoBehaviour
{

    public Transform traceParent;
    public Rigidbody boatRigidBody;
    public ShipMovement parentScript;

    public string traceType;

    // Start is called before the first frame update
    void Start()
    {
        traceParent = transform.parent;
        boatRigidBody = traceParent.GetComponent<Rigidbody>();
        parentScript = traceParent.GetComponent<ShipMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        RaycastHit hit;
        bool traceHit = Physics.Raycast(transform.position, -transform.up, out hit, 10.0f);

        UnityEngine.Debug.DrawRay(transform.position, -transform.up * hit.distance, Color.red);

        if (traceType == "Bouyancy")
        {
            UnityEngine.Debug.DrawRay(transform.position, -transform.up * hit.distance, Color.red);

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
        else if (traceType == "Turning")
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

                boatRigidBody.AddForceAtPosition(steeringDir * desiredAccel, transform.position);

                boatRigidBody.AddForceAtPosition(transform.up * parentScript.heelMultiplier, transform.position);
            }
        }
        else if (traceType == "Power")
        {
            UnityEngine.Debug.DrawRay(transform.position, -transform.up * hit.distance, Color.green);

            Vector3 accelDir = transform.forward;

            if (parentScript.accelInput != 0.0f)
            {
                float boatSpeed = Vector3.Dot(transform.forward, boatRigidBody.velocity);

                float normalizedSpeed = Mathf.Clamp01(Mathf.Abs(boatSpeed));

                float availableTorque = parentScript.shipPower * parentScript.accelInput;

                boatRigidBody.AddForceAtPosition(accelDir * availableTorque, transform.position);

                UnityEngine.Debug.Log("Force: " + availableTorque);

            }

            var localVel = transform.InverseTransformDirection(boatRigidBody.velocity);

            float dragForce = 0.5f * parentScript.dragCoefficient * (localVel.z * boatRigidBody.velocity.magnitude);

            boatRigidBody.AddForceAtPosition(-accelDir * dragForce, transform.position);

            UnityEngine.Debug.Log("Drag: " + dragForce);

        }
    }
}

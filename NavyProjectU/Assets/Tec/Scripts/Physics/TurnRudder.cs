using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class TurnRudder : MonoBehaviour
{

    public ShipMovement parent;
    public bool Invert;
    float TurnAngle = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.GetComponent<ShipMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Invert == true)
        {
            TurnAngle = -35.0f;
        }
        else
        {
            TurnAngle = 35.0f;
        }

        if(parent.steeringInput != 0.0f)
        {
            if(Invert == true)
            {
                parent.steeringInput = -parent.steeringInput;
            }

            transform.eulerAngles = new Vector3(parent.transform.eulerAngles.x, parent.transform.eulerAngles.y - parent.steeringInput, parent.transform.eulerAngles.z);
        }
    }
}

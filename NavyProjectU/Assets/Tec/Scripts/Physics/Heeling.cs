using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Heeling : MonoBehaviour
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
            TurnAngle = 30.0f;
        }
        else
        {
            TurnAngle = -30.0f;
        }

        if (parent.rateOfTurn != 0.0f)
        {
            if (Invert == true)
            {
                parent.rateOfTurn = -parent.rateOfTurn;
            }

            transform.eulerAngles = new Vector3(parent.transform.eulerAngles.x, parent.transform.eulerAngles.y, parent.transform.eulerAngles.z - (parent.rateOfTurn * (TurnAngle/5.0f)));
        }

        //UnityEngine.Debug.Log("Ship Rotation: " + transform.eulerAngles);
    }
}
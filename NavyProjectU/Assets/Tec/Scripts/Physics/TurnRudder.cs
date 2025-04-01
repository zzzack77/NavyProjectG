using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

using System.Security.Cryptography;
using UnityEngine;

public class TurnRudder : MonoBehaviour
{

    public ShipMovement parent;
    public bool Invert;

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
            transform.eulerAngles = new Vector3(parent.transform.eulerAngles.x, parent.transform.eulerAngles.y - -parent.portActualRudder, parent.transform.eulerAngles.z);
            //Debug.Log(parent.steeringInput);
            

        }
        else
        {
            transform.eulerAngles = new Vector3(parent.transform.eulerAngles.x, parent.transform.eulerAngles.y - parent.portActualRudder, parent.transform.eulerAngles.z);
            //Debug.Log(parent.steeringInput);

        }
        //UnityEngine.Debug.Log(parent.transform.eulerAngles.z)
    }
}

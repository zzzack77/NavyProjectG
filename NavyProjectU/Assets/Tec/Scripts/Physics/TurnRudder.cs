using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class TurnRudder : MonoBehaviour
{

    public ShipMovement parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.GetComponent<ShipMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parent.steeringInput > 0.0f)
        {
            //transform.rotation = parent.transform.rotation * Quaternion.Euler(0f, 0f, -45f);
            transform.eulerAngles = new Vector3(parent.transform.eulerAngles.x, parent.transform.eulerAngles.y + 45.0f, parent.transform.eulerAngles.z);
            //UnityEngine.Debug.Log("TurnedRight");
            //UnityEngine.Debug.Log(transform.rotation);
        }
        else if(parent.steeringInput < 0.0f)
        {
            //transform.rotation = parent.transform.rotation * Quaternion.Euler(0f, 0f, 45f)
            transform.eulerAngles = new Vector3(parent.transform.eulerAngles.x, parent.transform.eulerAngles.y - 45.0f, parent.transform.eulerAngles.z);
            //UnityEngine.Debug.Log("TurnedLeft");
            //UnityEngine.Debug.Log(transform.rotation);
        }
        
        if (parent.steeringInput == 0.0f)
        {
            //transform.rotation = parent.transform.rotation * Quaternion.Euler(0f, 0f, 0f);
            transform.eulerAngles = new Vector3(parent.transform.eulerAngles.x, parent.transform.eulerAngles.y, parent.transform.eulerAngles.z);
            //UnityEngine.Debug.Log("BackToStraight");
        }
        //Debug.Log(transform.rotation.ToString());
    }
}

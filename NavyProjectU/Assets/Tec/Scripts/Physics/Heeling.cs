using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
//using System.Security.Policy;
using UnityEngine;

public class Heeling : MonoBehaviour
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

        float displacement = parent.rb.mass/1000;
        float velocity = parent.rb.velocity.magnitude;
        float comHeight = parent.rb.transform.position.y;
        float gravity = 9.81f;
        float turnRadius = ((velocity * (360.0f / parent.rateOfTurn))/Mathf.PI)/2;

        float heelAngle = Mathf.Asin(((displacement * (velocity*velocity)/ turnRadius)*((comHeight*comHeight)/(displacement*gravity*-30.0f)))) * (180/Mathf.PI);

        UnityEngine.Debug.Log(heelAngle);

        if (parent.rateOfTurn != 0.0f)
        {
            if (Invert == true)
            {
                transform.eulerAngles = new Vector3(parent.transform.eulerAngles.x, parent.transform.eulerAngles.y, parent.transform.eulerAngles.z - (-heelAngle));
            }
            else
            {
                transform.eulerAngles = new Vector3(parent.transform.eulerAngles.x, parent.transform.eulerAngles.y, parent.transform.eulerAngles.z - (heelAngle));
            }
        }
    }
}
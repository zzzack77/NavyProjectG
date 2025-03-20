using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThrottles : MonoBehaviour
{

    public GameObject throttleL;
    public GameObject throttleR;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (throttleL != null && throttleR != null)
        {
            throttleL.transform.eulerAngles = new Vector3(throttleL.transform.eulerAngles.x, throttleL.transform.eulerAngles.y, throttleL.transform.eulerAngles.z);
            throttleR.transform.eulerAngles = new Vector3(throttleR.transform.eulerAngles.x, throttleR.transform.eulerAngles.y, throttleR.transform.eulerAngles.z);
        }
    }
}

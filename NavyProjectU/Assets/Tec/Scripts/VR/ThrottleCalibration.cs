using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrottleCalibration : MonoBehaviour
{
    public GameObject newThrottle;
    public GameObject rightHand;
    public float throttleY = 2.209249f;
    public float zOffset;
    private bool throttleIsSpawned = false;
   // public Vector3 offset = new Vector3(0.9f, 0, 0.7f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        //Vector3 finalThrottlePos = new Vector3(rightHand.transform.localPosition.x, throttleY, rightHand.transform.localPosition.z);
        if (Input.GetKeyDown(KeyCode.T))
        {
            //Vector3 handPos = rightHand.transform.position;

            //newThrottle.transform.localPosition = finalThrottlePos;

            //Vector3 offset = newThrottle.transform.position - rightHand.transform.position;

            //newThrottle.transform.localPosition += new Vector3(offset.x, 0, offset.z + zOffset);

            CalibrateThrottle();
        }
    }

    public void CalibrateThrottle()
    {
        Vector3 finalThrottlePos = new Vector3(rightHand.transform.localPosition.x, throttleY, rightHand.transform.localPosition.z);

        Vector3 handPos = rightHand.transform.position;

        newThrottle.transform.localPosition = finalThrottlePos;

        Vector3 offset = newThrottle.transform.position - rightHand.transform.position;

        newThrottle.transform.localPosition += new Vector3(offset.x, 0, offset.z + zOffset);
    }
}


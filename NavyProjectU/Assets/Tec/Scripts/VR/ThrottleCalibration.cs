using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrottleCalibration : MonoBehaviour
{
    public GameObject throttle;
    public GameObject rightHand;
    public GameObject heroModelsParent;
    private float throttleY = 2.209249f;
    public Vector3 offset = new Vector3(0.9f, 0, 0.7f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        Vector3 finalThrottlePos = new Vector3(rightHand.transform.position.x, throttleY, rightHand.transform.position.z);
        if (Input.GetKeyDown(KeyCode.T))
        {
            GameObject newThrottle = Instantiate(throttle, finalThrottlePos + offset, Quaternion.Euler(0, rightHand.transform.eulerAngles.y, 0));
            //newThrottle.transform.SetParent(heroModelsParent.transform);
        }
    }
}


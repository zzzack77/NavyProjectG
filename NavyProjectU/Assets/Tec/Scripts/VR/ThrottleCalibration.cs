using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrottleCalibration : MonoBehaviour
{
    public GameObject throttle;
    public GameObject rightHand;
    private float throttleY = 2.209249f;
    private Vector3 offset = new Vector3(0.9f, 0, 0.7f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 finalThrottlePos = new Vector3(rightHand.transform.localPosition.x, throttleY, rightHand.transform.localPosition.z);
        if (Input.anyKeyDown)
        {
            throttle.transform.localPosition = finalThrottlePos + offset;
            throttle.transform.localRotation = Quaternion.Euler(0, rightHand.transform.eulerAngles.y, 0);
        }
    }
}

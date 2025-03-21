using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrottleCalibration : MonoBehaviour
{
    [SerializeField] private Transform throttle;
    [SerializeField] private Transform rightHand;
    [SerializeField] private float throttleY = 2.209249f;

    void Start()
    {
        if (throttle == null)
        {
            Debug.LogError("Transform: throttle not found!");
        }

        if (rightHand == null)
        {
            Debug.LogError("Transform: right hand not found!");
        }
    }

    //void Update()
    //{ 
    //    Vector3 finalThrottlePos = new Vector3(rightHand.localPosition.x, throttleY, rightHand.localPosition.z);
    //    if (Input.GetKeyDown(KeyCode.T))
    //    {
    //        throttle.localPosition = finalThrottlePos;

    //        Vector3 offset = throttle.position - rightHand.position;

    //        throttle.localPosition += new Vector3(offset.x, 0, offset.z);
    //    }
    //}
    public void ThrottleCalibrationFunction()
    {
        Vector3 finalThrottlePos = new Vector3(rightHand.localPosition.x, throttleY, rightHand.localPosition.z);

        throttle.localPosition = finalThrottlePos;

        Vector3 offset = throttle.position - rightHand.position;

        throttle.localPosition += new Vector3(offset.x, 0, offset.z);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class VRCalibration : MonoBehaviour
{
    private GameObject xrOrigin;
    public GameObject cameraGO;
    private TrackedPoseDriver trackedPoseDriver; // Reference to the main cameras tracked pose driver
    // Start is called before the first frame update
    void Start()
    {
        trackedPoseDriver = cameraGO.GetComponent<TrackedPoseDriver>();
        xrOrigin = GameObject.Find("XR Origin");

        if (xrOrigin == null)
        {
            Debug.Log("XR Origin Game Object Not Found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            VRResetRotation();
        }
    }

    public void VRResetRotation()
    {
        trackedPoseDriver.enabled = false;
        cameraGO.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        Debug.Log("R Key Pressed");
        trackedPoseDriver.enabled = true;
    }

    public void VRCalibrationMethod()
    {

    }
}

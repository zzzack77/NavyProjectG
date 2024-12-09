using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;

public class VRCalibration : MonoBehaviour
{
    private GameObject xrOrigin;
    public GameObject cameraGO;

    public GameObject leftHand;
    public GameObject rightHand;
    float lx = 0.0f;
    float rx = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
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

        lx = leftHand.transform.localPosition.x;
        rx = rightHand.transform.localPosition.x;
        Debug.Log(lx);
        Debug.Log(rx);
    }

    public void VRResetRotation()
    {
       
        cameraGO.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        Debug.Log("R Key Pressed");
        
    }

    public void VRCalibrationMethod()
    {

    }
}

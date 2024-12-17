using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;

public class VRCalibration : MonoBehaviour
{
    private GameObject xrOrigin;
    public GameObject leftHand, rightHand; 
    public GameObject leftWheelGripPoint, rightWheelGripPoint;
    public GameObject userOriginpos;
   
    // Start is called before the first frame update
    void Start()
    {
        
        xrOrigin = GameObject.Find("XR Origin");

        if (xrOrigin == null)
        {
            Debug.Log("XR Origin Game Object Not Found!");
        }
        StartCoroutine(CalibrationCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(CalibrationCountdown());
        }
    }

    public void VRResetRotation()
    {
        // Get current hand positions
        Vector3 realLeftHandPos = leftHand.transform.position;
        Vector3 realRightHandPos = rightHand.transform.position;

        // Get virtual wheel grip points
        Vector3 virtualLeftGripPos = leftWheelGripPoint.transform.position;
        Vector3 virtualRightGripPos = rightWheelGripPoint.transform.position;


        // Calculate rotation offset
        Vector3 realForward = (realRightHandPos - realLeftHandPos).normalized;
        Vector3 virtualForward = (virtualRightGripPos - virtualLeftGripPos).normalized;
        Quaternion fullRotationOffset = Quaternion.FromToRotation(realForward, virtualForward);
        Vector3 offsetEulerAngles = fullRotationOffset.eulerAngles; // Convert to Euler angles
        Quaternion yAxisRotationOffset = Quaternion.Euler(0, offsetEulerAngles.y, 0); // Only use Y-axis

        xrOrigin.transform.position = userOriginpos.transform.position;
        xrOrigin.transform.rotation = yAxisRotationOffset * xrOrigin.transform.rotation;
    }


    private IEnumerator CalibrationCountdown()
    {
        yield return new WaitForSeconds(3f);
        VRResetRotation();
    }
}

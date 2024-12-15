using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;

public class VRCalibration : MonoBehaviour
{
    private GameObject xrOrigin;
    public GameObject cameraGO;
    public GameObject testObject;
    public GameObject leftHand, rightHand; 
    public GameObject leftWheelGripPoint, rightWheelGripPoint;
    public GameObject userOriginpos;
    float lx = 0.0f;
    float rx = 0.0f;
    Vector3 handMiddlePosDistance;
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

        // Calculate position offset
        handMiddlePosDistance = (leftHand.transform.position - rightHand.transform.position) / 2;
        Vector3 virtualMidPoint = (virtualLeftGripPos - virtualRightGripPos) / 2;
        Vector3 positionOffset = virtualMidPoint - handMiddlePosDistance;
        positionOffset = new Vector3(positionOffset.x, 0, positionOffset.z);

        // Calculate rotation offset
        Vector3 realForward = (realRightHandPos - realLeftHandPos).normalized;
        Vector3 virtualForward = (virtualRightGripPos - virtualLeftGripPos).normalized;
        Quaternion fullRotationOffset = Quaternion.FromToRotation(realForward, virtualForward);
        Vector3 offsetEulerAngles = fullRotationOffset.eulerAngles; // Convert to Euler angles
        Quaternion yAxisRotationOffset = Quaternion.Euler(0, offsetEulerAngles.y, 0); // Only use Y-axis

        float scalingFactor = 2f;
        xrOrigin.transform.position = userOriginpos.transform.position;
        xrOrigin.transform.rotation = yAxisRotationOffset * xrOrigin.transform.rotation;
    }


    private IEnumerator CalibrationCountdown()
    {
        yield return new WaitForSeconds(3f);
        VRResetRotation();
    }
}

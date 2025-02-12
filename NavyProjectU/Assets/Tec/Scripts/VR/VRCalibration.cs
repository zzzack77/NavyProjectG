using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;

public class VRCalibration : MonoBehaviour
{
    [SerializeField] private GameObject xrOrigin;
    public GameObject leftHand, rightHand; 
    public GameObject leftWheelGripPoint, rightWheelGripPoint;
    public GameObject userOriginpos;
    public GameObject xrCamera;

    public float cameraOffsetY = 1.1176f;

    // Start is called before the first frame update
    void Start()
    {
        
        //xrOrigin = GameObject.Find("XR Origin");

        //if (xrOrigin == null)
        //{
        //    Debug.LogError("XR Origin Game Object Not Found!");
        //}

        if (xrCamera == null)
        {
            Debug.LogError("XR Camera Game Object not Found!");
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

        
        xrOrigin.transform.rotation = yAxisRotationOffset * xrOrigin.transform.rotation;

        // Adjust the position of the XR Origin to match the user origin position
        xrOrigin.transform.position = userOriginpos.transform.position;

        //// Adjust the height of the XR Camera to match the user origin position
        //Vector3 cameraPosition = xrCamera.transform.position;
        //cameraPosition.y = userOriginpos.transform.position.y + cameraOffsetY;
        //xrCamera.transform.position = cameraPosition;

    }


    private IEnumerator CalibrationCountdown()
    {
        yield return new WaitForSeconds(3f);
        VRResetRotation();
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;

public class VRCalibration : MonoBehaviour
{
    [SerializeField] private GameObject xrOriginGO;
    public GameObject leftHand, rightHand; 
    public GameObject leftWheelGripPoint, rightWheelGripPoint;
    public GameObject userOriginpos;
    public GameObject xrCamera;
    private Vector3 scaleOffset = new Vector3(0.05f, 0.1f, 0.0066666f);
    [SerializeField] private XROrigin xrOrigin;

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
        if (Input.GetKeyDown(KeyCode.F5))
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

        Vector3 virtualGripMidPoint = (virtualLeftGripPos + virtualRightGripPos) / 2;
        Vector3 realGripMidPoint = (realLeftHandPos + realRightHandPos) / 2;


        // Calculate rotation offset
        Vector3 realForward = (realRightHandPos - realLeftHandPos).normalized;
        Vector3 virtualForward = (virtualRightGripPos - virtualLeftGripPos).normalized;
        Quaternion fullRotationOffset = Quaternion.FromToRotation(realForward, virtualForward);
        Vector3 offsetEulerAngles = fullRotationOffset.eulerAngles; // Convert to Euler angles
        Quaternion yAxisRotationOffset = Quaternion.Euler(0, offsetEulerAngles.y, 0); // Only use Y-axis
        Quaternion scaleRotationOffset = Quaternion.Euler(scaleOffset.x, scaleOffset.y, scaleOffset.z);
        
        float distance = Vector3.Distance(realGripMidPoint, xrOrigin.CameraInOriginSpacePos) * 2;
        xrCamera.transform.rotation = yAxisRotationOffset * xrCamera.transform.rotation;


        // Set the position of the xr origins camera offset to the wheel + the offset of the hands and headset

        Vector3 cameraOffset = xrOrigin.CameraInOriginSpacePos;
        Vector3 localOffset = new Vector3(0.04f, 0, -distance);


        // Get current camera position in world space
        Vector3 cameraWorldPos = xrCamera.transform.position;

        // Calculate how much we need to move the XR Origin to align camera and grip midpoint
        Vector3 positionOffset = virtualGripMidPoint - cameraWorldPos;

        // Apply the offset to XR Origin's position
        xrOrigin.transform.position += positionOffset - new Vector3(0.1f, 0, 0.5f); // Slight manual offset
        xrOriginGO.transform.position += positionOffset - new Vector3(0.1f, 0, 0.5f); 
        // Kind of works, needs some more adjustments but definetely some progress


    }


    private IEnumerator CalibrationCountdown()
    {
        yield return new WaitForSeconds(3f);
        VRResetRotation();
    }
}

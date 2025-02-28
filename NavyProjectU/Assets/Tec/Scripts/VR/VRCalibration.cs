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
    private Vector3 scaleOffset = new Vector3(0.05f, 0.1f, 0.0066666f);

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
        
        float distance = Vector3.Distance(realGripMidPoint, xrCamera.transform.position);
        xrCamera.transform.rotation = yAxisRotationOffset * xrCamera.transform.rotation;


        // Set the position of the xr origins camera offset to the wheel + the offset of the hands and headset
        xrOrigin.transform.position = new Vector3((virtualGripMidPoint.x + 0.04f), xrCamera.transform.position.y, (virtualGripMidPoint.z - distance));
        xrCamera.transform.position = new Vector3((virtualGripMidPoint.x + 0.04f), xrCamera.transform.position.y, (virtualGripMidPoint.z - distance));
        

        // Kind of works, needs some more adjustments but definetely some progress


    }

    
    private IEnumerator CalibrationCountdown()
    {
        yield return new WaitForSeconds(3f);
        VRResetRotation();
    }
}

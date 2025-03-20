using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR;

public class VRCalibration : MonoBehaviour
{
    [SerializeField] private Transform xrOriginGO;
    [SerializeField] private Transform leftHand, rightHand;
    [SerializeField] private Transform leftWheelGripPoint, rightWheelGripPoint;
    [SerializeField] private Transform xrCamera;
    [SerializeField] private XROrigin xrOrigin;
    [SerializeField] private Transform userOriginPos;
    [SerializeField] private Camera xrOriginCamera;
    // Start is called before the first frame update
    void Start()
    {
        if (xrOrigin == null)
        {
            Debug.LogError("XR Origin Game Object Not Found!");
        }

        if (xrCamera == null)
        {
            Debug.LogError("XR Camera Game Object not Found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            StartCoroutine(CalibrationCountdown());
        }
    }

    public void VRCalibrateUser()
    {
        // Get current hand positions
        Vector3 realLeftHandPos = leftHand.position;
        Vector3 realRightHandPos = rightHand.position;

        // Get virtual wheel grip points
        Vector3 virtualLeftGripPos = leftWheelGripPoint.position;
        Vector3 virtualRightGripPos = rightWheelGripPoint.position;

        Vector3 virtualGripMidPoint = (virtualLeftGripPos + virtualRightGripPos) / 2;
        Vector3 realGripMidPoint = (realLeftHandPos + realRightHandPos) / 2;

        // Calculate rotation offset
        Vector3 realForward = (realRightHandPos - realLeftHandPos).normalized;
        Vector3 virtualForward = (virtualRightGripPos - virtualLeftGripPos).normalized;
        Quaternion fullRotationOffset = Quaternion.FromToRotation(realForward, virtualForward);
        Vector3 offsetEulerAngles = fullRotationOffset.eulerAngles; // Convert to Euler angles
        Quaternion yAxisRotationOffset = Quaternion.Euler(0, offsetEulerAngles.y, 0); // Only use Y-axis

        xrCamera.rotation = yAxisRotationOffset * xrCamera.rotation;

        Vector3 positionOffset = userOriginPos.position - xrOriginCamera.transform.position;
        xrOrigin.transform.position += positionOffset;
    }

    private IEnumerator CalibrationCountdown()
    {
        yield return new WaitForSeconds(3f);
        VRCalibrateUser();
    }
}

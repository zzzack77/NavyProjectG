using System.Collections;
using System.Collections.Generic;

using System.Security.Cryptography;


//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class ShipMovement : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;

    public PrivateVariables privateVariables;

    public Rigidbody rb;

    // Boat physiscs stats
    public float accelPortInput = 0.0f;
    public float accelStarboardInput = 0.0f;
    public float steeringInput;
    public float shipPower = 3500000.0f;

    public float suspensionRestDist = 5.0f;
    public float springStrength = 20000000.0f;
    public float springDamper = 500000.0f;

    public float dragFactor = 1.0f;
    public float dragCoefficient = 25000.0f;
    public float boatWeight = 10000.0f;

    private float rpmEngineMax = 3000.0f;
    private float rpmEngineStarboard = 0.0f;
    private float rpmEnginePort = 0.0f;

    public float rpmPropMax = 250.0f;
    public float rpmPropStarboard = 0.0f;
    public float rpmPropPort = 0.0f;

    [Header("Boat stats")]
    public float boatSpeedkph;
    public float boatSpeedkn;
    public float rateOfTurn;

    public bool isThrottleConnected;
    public bool isSteeringWheelConnected;
    public bool isFrozen;
    // Start is called before the first frame update
    void Start()
    {
        privateVariables = GameObject.FindGameObjectWithTag("Player").GetComponent<PrivateVariables>();
        
        camera1.gameObject.SetActive(true);
        camera2.gameObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (privateVariables != null) { privateVariables.Heading = transform.rotation.eulerAngles.y; }
        UpdateInspectorvariables();
    }

    // Update is called once per frame
    void Update()
    {       
        // Resets position / position, rotation and velocity back to 0 for debugging purposes
        if (Input.GetKey(KeyCode.Z)) { ResetPos(); }
        if (Input.GetKey(KeyCode.X)) { ResetPosRotVelocity(); }

        VerticalMovement();

        // Depending on autopilot nfu or manual call correct function for movement
        if (privateVariables != null)
        {
            if (privateVariables.IsAuto) { AutoPilotMode(); }
            else if (privateVariables.IsNFU) { NFUMode(); }
            else { ManualMode(); }
        }

        // If private variabels is null defult to manual mode (A, D key presses)
        else { ManualMode(); }

        if (Input.GetKeyDown(KeyCode.F1)) // Switch to first display
        {
            camera1.gameObject.SetActive(!camera1.gameObject.activeSelf);
            camera2.gameObject.SetActive(!camera2.gameObject.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.F11)) { isFrozen = true; }
        if (Input.GetKeyDown(KeyCode.F12)) { isFrozen = false; }
        if (isFrozen) { ResetPos(); }

    }

    // Resets boat without restarting the scene
    public void ResetPosRotVelocity()
    {
        transform.position = new Vector3(0, 5, 0);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rb.velocity = new Vector3(0, 0, 0);
    }

    // Resets position, can be used to test long distant movement without boat falling of the world
    public void ResetPos() { transform.position = new Vector3(0, 5, 0); }
    public void UpdateInspectorvariables()
    {
        Vector3 forwardDirection = transform.forward;

        var LocalV = transform.InverseTransformDirection(rb.velocity);

        boatSpeedkph = LocalV.z * 3.6f;
        boatSpeedkn = LocalV.z * 1.944f;
        rateOfTurn = rb.angularVelocity.y * Mathf.Rad2Deg;
    }
    public void VerticalMovement()
    {
        if (isThrottleConnected)
        {
            accelPortInput = Input.GetAxis("Vertical");
        }
        else
        {
            if (Input.GetKey(KeyCode.W) && accelPortInput < 1.0f) { accelPortInput = accelPortInput + 0.01f; }
            else if (Input.GetKey(KeyCode.S) && accelPortInput > -1.0f) { accelPortInput = accelPortInput - 0.01f; }

            if (Input.GetKey(KeyCode.R) && accelStarboardInput < 1.0f) { accelStarboardInput = accelStarboardInput + 0.01f; }
            else if (Input.GetKey(KeyCode.F) && accelStarboardInput > -1.0f) { accelStarboardInput = accelStarboardInput - 0.01f; }
        }
    }
    public void RPMCode()
    {
        float rpmPortInput = accelPortInput * rpmPropMax;
        float rpmStarboardInput = accelStarboardInput * rpmPropMax;

        // Starborad Propeller

        if (rpmStarboardInput > rpmPropStarboard)
        {
            rpmPropStarboard = rpmPropStarboard + 1.0f;
            if (rpmPropStarboard > rpmStarboardInput)
            {
                rpmPropStarboard = rpmStarboardInput;
            }
        }
        else if (rpmStarboardInput < rpmPropStarboard)
        {
            rpmPropStarboard = rpmPropStarboard - 1.0f;
            if (rpmPropStarboard < rpmStarboardInput)
            {
                rpmPropStarboard = rpmStarboardInput;
            }
        }

        // Port Propeller

        if (rpmPortInput > rpmPropPort)
        {
            rpmPropPort = rpmPropPort + 1.0f;
            if (rpmPropPort > rpmPortInput)
            {
                rpmPropPort = rpmPortInput;
            }

        }
        else if (rpmPortInput < rpmPropPort)
        {
            rpmPropPort = rpmPropPort - 1.0f;
            if (rpmPropPort < rpmPortInput)
            {
                rpmPropPort = rpmPortInput;
            }
        }
    }
    // Auto Pilot code
    public void AutoPilotMode()
    {
        float difference = (privateVariables.SetAutoCourse - privateVariables.Heading + 360) % 360;
        UnityEngine.Debug.Log(difference);

        

        if (difference <= 180) { steeringInput = -Mathf.Clamp(difference, 0, 5); }
        else { steeringInput = Mathf.Clamp((360 - difference), 0, 5); }
               
    }
    public void ManualMode()
    {
        if (isSteeringWheelConnected)
        {
            steeringInput = Input.GetAxis("Horizontal") * -35.0f;
        }
        else
        {
            if (Input.GetKey(KeyCode.A) && steeringInput < 35.0f) { steeringInput = steeringInput + 0.1f; }
            else if (Input.GetKey(KeyCode.D) && steeringInput > -35.0f) { steeringInput = steeringInput - 0.1f; }
        }
        if (Input.GetKey(KeyCode.A) && steeringInput < 35.0f) { steeringInput = steeringInput + 0.1f; }
        else if (Input.GetKey(KeyCode.D) && steeringInput > -35.0f) { steeringInput = steeringInput - 0.1f; }
    }
    public void NFUMode() { steeringInput = -privateVariables.NfuSteeringValue; }

    void ChangeDisplay(int displayIndex)
    {
        if (displayIndex >= 0 && displayIndex < Display.displays.Length)
        {
            Screen.SetResolution(Display.displays[1].systemWidth, Display.displays[1].systemHeight, FullScreenMode.Windowed);

        }
        else
        {
            Debug.LogError("Invalid display index!");
        }
    }
}

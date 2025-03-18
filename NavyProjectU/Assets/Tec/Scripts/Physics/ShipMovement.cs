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
    public GameObject assessorUI;

    public Transform visualsTransform;

    InputSubscription InputManager;

    LogitechThrottleInput ThrottleInput;

    public Rigidbody rb;

    // Boat physiscs stats
    public float accelPortInput = 0.0f;
    public float portPower = 0.0f;
    bool bPortReverse = false;
    float portDirection = 1.0f;
    public float accelStarboardInput = 0.0f;
    public float starPower = 0.0f;
    bool bStarReverse = false;
    float starboardDirection = 1.0f;
    public float steeringInput;
    public float shipPower = 3500000.0f;

    public float suspensionRestDist = 5.0f;
    public float springStrength = 20000000.0f;
    public float springDamper = 500000.0f;

    public float dragFactor = 1.0f;
    public float dragCoefficient = 35000.0f;
    public float rearDragCoefficient = 65000.0f;
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


    [Header("Models")]
    public GameObject throttleL;
    public GameObject throttleR;
    public GameObject steeringWheel;

    // Start is called before the first frame update
    void Start()
    {
        InputManager = GetComponent<InputSubscription>();

        ThrottleInput = GetComponent<LogitechThrottleInput>();

        privateVariables = GameObject.FindGameObjectWithTag("Player").GetComponent<PrivateVariables>();
        //assessorUI = GameObject.Find("GameManager").GetComponent<AssessorUI>();

        camera1.gameObject.SetActive(true);
        camera2.gameObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (privateVariables != null) { privateVariables.Heading = transform.rotation.eulerAngles.y; }
        UpdateInspectorvariables();
        RPMCode();
        SetThrottleModelRotation();
        SetSteeringWheelModelRotation();
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
        if (Input.GetKeyDown(KeyCode.F10)) 
        {
            if (assessorUI.activeSelf) { assessorUI.SetActive(false); }
            else { assessorUI.SetActive(true); }

        }
        if (isFrozen) { ResetPos(); }

        steeringWheel.transform.localEulerAngles = new Vector3(0f, 0f, -steeringInput);

        throttleR.transform.localEulerAngles = new Vector3(-accelStarboardInput * 90, 0f, 0f);
        throttleL.transform.localEulerAngles = new Vector3(-accelPortInput * 90, 0f, 0f);
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
        privateVariables.SpeedKn = boatSpeedkn;
        rateOfTurn = rb.angularVelocity.y * Mathf.Rad2Deg;
        privateVariables.RateOfTurn = rateOfTurn;

        privateVariables.PortRudderAngle = steeringInput;
        privateVariables.StarRudderAngle = steeringInput;
        privateVariables.PortClinometer = visualsTransform.transform.rotation.eulerAngles.x;
        privateVariables.StarClinometer = visualsTransform.transform.rotation.eulerAngles.z;
    }
    public void VerticalMovement()
    {
        if (isThrottleConnected)
        {
            if (InputManager.PortToggle)
            {
                accelPortInput = -1;
            }
            else 
            { 
                accelPortInput = ThrottleInput.portValue;
            }
            if (InputManager.StarboardToggle)
            {
                accelStarboardInput = -1;
            }
            else 
            {
                accelStarboardInput = ThrottleInput.starValue;
            }
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

        privateVariables.PortActualRPM = rpmPropPort;
        privateVariables.PortPredictedRPM = rpmPortInput;

        privateVariables.StarActualRPM = rpmPropStarboard;
        privateVariables.StarPredictedRPM = rpmStarboardInput;

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

        starPower = rpmPropStarboard / rpmPropMax;

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

        portPower = rpmPropPort / rpmPropMax;
    }
    // Auto Pilot code
    public void AutoPilotMode()
    {
        float difference = (privateVariables.SetAutoCourse - privateVariables.Heading + 360) % 360;
        Debug.Log(difference);



        if (difference <= 180) { steeringInput = -Mathf.Clamp(difference, 2.5f, 7); }
        else { steeringInput = Mathf.Clamp((360 - difference), 2.5f, 7); }

    }
    public void ManualMode()
    {
        if (isSteeringWheelConnected)
        {
            //UnityEngine.Debug.Log("Test");
            //steeringInput = Input.GetAxis("Horizontal") * -35.0f;
            steeringInput = (InputManager.Turn.x) * -35.0f;

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

    public void SetThrottleModelRotation()
    {
        throttleL.transform.eulerAngles = new Vector3(throttleL.transform.eulerAngles.x + accelPortInput * 90.0f, throttleL.transform.eulerAngles.y, throttleL.transform.eulerAngles.z);
        throttleR.transform.eulerAngles = new Vector3(throttleR.transform.eulerAngles.x + accelStarboardInput * 90.0f, throttleR.transform.eulerAngles.y, throttleR.transform.eulerAngles.z);
    }

    public void SetSteeringWheelModelRotation()
    {

    }
}
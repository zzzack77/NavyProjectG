using System.Collections;
using System.Collections.Generic;

using System.Security.Cryptography;


//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UIElements;

public class ShipMovement : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;

    public PrivateVariables privateVariables;

    public Rigidbody rb;
    
    public float accelInput = 0.0f;
    public float steeringInput = 0.0f;
    public float shipPower = 5.0f;

    public float suspensionRestDist;
    public float springStrength;
    public float springDamper;

    public float dragFactor;
    public float boatWeight;
    public float boatTopSpeed;

    [Header("Boat stats")]
    public float boatSpeedkph;
    public float boatSpeedkn;
    public float rateOfTurn;

    public bool isThrottleConnected;
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
        boatSpeedkph = rb.velocity.magnitude * 3.6f;
        boatSpeedkn = rb.velocity.magnitude * 1.944f;
        rateOfTurn = rb.angularVelocity.y * Mathf.Rad2Deg;
    }
    public void VerticalMovement()
    {
        if (isThrottleConnected)
        {
            //Put throttle code here
        }
        else
        {
            if (Input.GetKey(KeyCode.W) && accelInput < 1.0f) { accelInput = accelInput + 0.001f; }
            else if (Input.GetKey(KeyCode.S) && accelInput > -1) { accelInput = accelInput - 0.001f; }
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

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PrivateVariables : MonoBehaviour
{
    //Variables
    /*Using variables tutorial
     * declare variable.
     
    private PrivateVariables _PrivateVariables;

     * in start/awake get the component
     
    _PrivateVariables = GetComponent<PrivateVariables>();
    
     * then call varaible by referenecing used name e.g. _PrivateVariables
    
    _PrivateVariables.instertYourVariableHere = 0;
     */

    // Rotation variables
    private float heading;
    private float pitch;
    private float roll;

    // UI variables
    [SerializeField]
    private float setAutoCourse;
    private float settingAutoCourse;
    private float distanceFromGround;
    private bool isAuto;
    private bool isBow;

    // Failures / Errors
    private bool systemFailure;
    private bool gyroFailure;
    private bool steeringGearFailure;
    private bool autoPilotFailure;
    private bool logFailure;
    private bool rudderIndicatorFailure;



    // Script variables
    private AutoPilot2 autopilotoftTouch;
    private EchoSounderSoftTouch echoSounderSoftTouch;
    private ErrorUI errorUI;
    private AudioFunctions audioFunctions;

    private void Awake()
    {
        autopilotoftTouch = GameObject.Find("GameManager").GetComponent<AutoPilot2>();
        echoSounderSoftTouch = GetComponent<EchoSounderSoftTouch>();
        errorUI = GameObject.Find("GameManager").GetComponent<ErrorUI>();
        audioFunctions = GameObject.Find("MainCamera").GetComponent<AudioFunctions>();
    }

    // getters and setters
    public float Heading
    {
        get => heading;
        set
        {
            if (value < 0) heading = value + 360;
            else if (value >= 360) heading = value - 360;
            else heading = value;
            autopilotoftTouch.OnHeadingUpdate();
        }
    }
    public float SettingAutoCourse
    {
        get => settingAutoCourse;
        set
        {
            if (value < 0) settingAutoCourse = value + 360;
            else if (value >= 360) settingAutoCourse = value - 360;
            else settingAutoCourse = value;
            autopilotoftTouch.OnSettingAutoCourseUpdate();
        }
    }
    public float SetAutoCourse { get => setAutoCourse; set => setAutoCourse = value; }

    public float DistanceFromGround
    {
        get => distanceFromGround;
        set
        {
            distanceFromGround = value;
            echoSounderSoftTouch.UpdateDepthLabel(value);
        }
    }
    public bool IsBow { get => isBow; set => isBow = value; }
    public float Pitch { get => pitch; set => pitch = value; }
    public float Roll { get => roll; set => roll = value; }
    public bool IsAuto { get => isAuto; set => isAuto = value; }

    // Failures / Errors
    public bool SystemFailure
    {
        get => systemFailure;
        set
        {
            systemFailure = value;
            // If One error is true turn the alarm on
            if (value == true) { audioFunctions.AlarmAudioOn(); }

            // If all errors are false then turn the alarm off
            if (SystemFailure == false && GyroFailure == false && SteeringGearFailure == false && AutoPilotFailure == false
                && logFailure == false && RudderIndicatorFailure == false) { audioFunctions.AlarmAudioOff(); }

            // Update error UI screens
            errorUI.UpdateFailures();
        }
    }
    public bool GyroFailure
    {
        get => gyroFailure;
        set
        {
            gyroFailure = value;
            // If One error is true turn the alarm on
            if (value == true) { audioFunctions.AlarmAudioOn(); }

            // If all errors are false then turn the alarm off
            if (SystemFailure == false && GyroFailure == false && SteeringGearFailure == false && AutoPilotFailure == false
                && logFailure == false && RudderIndicatorFailure == false) { audioFunctions.AlarmAudioOff(); }

            // Update error UI screens
            errorUI.UpdateFailures();
        }
    }
    public bool SteeringGearFailure
    {
        get => steeringGearFailure;
        set
        {
            steeringGearFailure = value;
            // If One error is true turn the alarm on
            if (value == true) { audioFunctions.AlarmAudioOn(); }

            // If all errors are false then turn the alarm off
            if (SystemFailure == false && GyroFailure == false && SteeringGearFailure == false && AutoPilotFailure == false
                && logFailure == false && RudderIndicatorFailure == false) { audioFunctions.AlarmAudioOff(); }

            // Update error UI screens
            errorUI.UpdateFailures();
        }
    }
    public bool AutoPilotFailure
    {
        get => autoPilotFailure;
        set
        {
            autoPilotFailure = value;
            // If One error is true turn the alarm on
            if (value == true) { audioFunctions.AlarmAudioOn(); }

            // If all errors are false then turn the alarm off
            if (SystemFailure == false && GyroFailure == false && SteeringGearFailure == false && AutoPilotFailure == false
                && logFailure == false && RudderIndicatorFailure == false) { audioFunctions.AlarmAudioOff(); }

            // Update error UI screens
            errorUI.UpdateFailures();
        }
    }
    public bool LogFailure
    {
        get => logFailure;
        set
        {
            logFailure = value;
            // If One error is true turn the alarm on
            if (value == true) { audioFunctions.AlarmAudioOn(); }

            // If all errors are false then turn the alarm off
            if (SystemFailure == false && GyroFailure == false && SteeringGearFailure == false && AutoPilotFailure == false
                && logFailure == false && RudderIndicatorFailure == false) { audioFunctions.AlarmAudioOff(); }

            // Update error UI screens
            errorUI.UpdateFailures();
        }
    }
    public bool RudderIndicatorFailure
    {
        get => rudderIndicatorFailure;
        set
        {
            rudderIndicatorFailure = value;
            // If One error is true turn the alarm on
            if (value == true) { audioFunctions.AlarmAudioOn(); }

            // If all errors are false then turn the alarm off
            if (SystemFailure == false && GyroFailure == false && SteeringGearFailure == false && AutoPilotFailure == false
                && logFailure == false && RudderIndicatorFailure == false) { audioFunctions.AlarmAudioOff(); }

            // Update error UI screens
            errorUI.UpdateFailures();
        }
    }
}
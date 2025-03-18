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

    // Auto pilot UI variables
    private float setAutoCourse;
    private float settingAutoCourse;
    private float distanceFromGround;

    // NFU UI variables
    private float nfuSteeringValue;

    // Type of steering
    private bool isAuto;
    private bool isNFU;
    private bool isManual;

    // Echo sounder
    private bool isBow;

    // Heading UI
    private float rateOfTurn;
    private float speedKn;

    // Rudder Angle
    private float portRudderAngle;
    private float starRudderAngle;

    // Clinometer
    private float portClinomer;
    private float starClinomer;

    // Engine Revs UI
    private float portPredictedRPM;
    private float portActualRPM;
    private float starPredictedRPM;
    private float starActualRPM;

    // Failures / Errors
    private bool systemFailure;
    private bool gyroFailure;
    private bool steeringGearFailure;
    private bool autoPilotFailure;
    private bool logFailure;
    private bool rudderIndicatorFailure;

    // Script variables
    private AutoPilot2 autopilotSoftTouch;
    private EchoSounderSoftTouch echoSounderSoftTouch;
    private ErrorUI errorUI;
    private AudioFunctions audioFunctions;
    private RudderAngleUI rudderAngleUI;
    private HeadingUI headingUI;
    private AssessorUI assessorUI;

    private void Awake()
    {
        GameObject gameManger = GameObject.Find("GameManager");

        autopilotSoftTouch = gameManger.GetComponent<AutoPilot2>();
        echoSounderSoftTouch = gameManger.GetComponent<EchoSounderSoftTouch>();
        errorUI = gameManger.GetComponent<ErrorUI>();
        audioFunctions = GameObject.Find("MainCamera").GetComponent<AudioFunctions>();
        rudderAngleUI = gameManger.GetComponent<RudderAngleUI>();
        headingUI = gameManger.GetComponent<HeadingUI>();
        assessorUI = gameManger.GetComponent<AssessorUI>();
    }

    // Rotation variables
    public float Heading
    {
        get => heading;
        set
        {
            if (value < 0) heading = value + 360;
            else if (value >= 360) heading = value - 360;
            else heading = value;
            autopilotSoftTouch.OnHeadingUpdate();
            headingUI.OnHeadingUpdate();
            assessorUI.OnHeadingUpdate(value);
        }
    }
    public float Pitch
    {
        get => pitch;
        set
        {
            pitch = value;
        }
    }
    public float Roll
    {
        get => roll;
        set
        {
            roll = value;
        }
    }
    // Autopilot UI
    public float SetAutoCourse { get => setAutoCourse; set { setAutoCourse = value; autopilotSoftTouch.OnCurrentTargetUpdate(); } }
    public float SettingAutoCourse
    {
        get => settingAutoCourse;
        set
        {
            if (value < 0) settingAutoCourse = value + 360;
            else if (value >= 360) settingAutoCourse = value - 360;
            else settingAutoCourse = value;
            autopilotSoftTouch.OnSettingAutoCourseUpdate();
        }
    }
    // Echo sounder UI
    public float DistanceFromGround
    {
        get => distanceFromGround;
        set
        {
            distanceFromGround = value;
            echoSounderSoftTouch.UpdateDepthLabel(value);
        }
    }
    // NFU UI
    public float NfuSteeringValue { get => nfuSteeringValue; set => nfuSteeringValue = value; }
    // Type of steering 
    public bool IsAuto { get => isAuto; set => isAuto = value; }
    public bool IsManual { get => isManual; set => isManual = value; }
    public bool IsNFU { get => isNFU; set => isNFU = value; }
    public bool IsBow { get => isBow; set => isBow = value; }
    // Heading UI
    public float RateOfTurn
    {
        get => rateOfTurn;
        set
        {
            rateOfTurn = value;
            headingUI.OnRateOfTurnUpdate();
            assessorUI.OnRateOFTurnUpdate(value);
        }
    }
    public float SpeedKn
    {
        get => speedKn;
        set
        {
            speedKn = value;
            headingUI.OnSpeedKnUpdate();
            assessorUI.OnBoatSpeedUpdate(value);
        }
    }

    // Rudder angle
    public float PortRudderAngle
    {
        get => portRudderAngle;
        set
        {
            if (portRudderAngle != value)
            {
                portRudderAngle = value;
                rudderAngleUI.SetPortRudderAngle(value);
                assessorUI.OnRudderAngleUpdate(value);
            }
        }
    }
    public float StarRudderAngle
    {
        get => starRudderAngle;
        set
        {
            if (starRudderAngle != value)
            {
                starRudderAngle = value;
                rudderAngleUI.SetStarRudderAngle(value);
                //assessorUI.OnRudderAngleUpdate(value);
            }
        }
    }
    // Clinometer
    public float PortClinometer
    {
        get => portClinomer;
        set
        {
            if (portClinomer != value)
            {
                portClinomer = value;
                rudderAngleUI.SetPortClinometer(value);
            }
        }
    }
    public float StarClinometer
    {
        get => starClinomer;
        set
        {
            if (starClinomer != value)
            {
                starClinomer = value;
                rudderAngleUI.SetStarClinometer(value);
            }
        }
    }

    // Engine revs
    public float PortActualRPM
    {
        get => portActualRPM;
        set
        {
            if (portActualRPM != value)
            {
                portActualRPM = value;
                rudderAngleUI.setPortEngineRevsActual(value);
            }
        }
    }
    public float PortPredictedRPM
    {
        get => portPredictedRPM;
        set
        {
            if (portPredictedRPM != value)
            {
                portPredictedRPM = value;
                rudderAngleUI.setPortEngineRevsPredicted(value);
            }
        }
    }
    public float StarActualRPM
    {
        get => starActualRPM;
        set
        {
            if (starActualRPM != value)
            {
                starActualRPM = value;
                rudderAngleUI.setStarEngineRevsActual(value);
            }
        }
    }
    public float StarPredictedRPM
    {
        get => starPredictedRPM;
        set
        {
            if (starPredictedRPM != value)
            {
                starPredictedRPM = value;
                rudderAngleUI.setStarEngineRevsPredicted(value);
            }
        }
    }



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
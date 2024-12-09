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
    private float settingAutoCourse;
    [SerializeField]
    private float setAutoCourse;
    private float distanceFromGround;
    private bool isAuto;

    // Script variables
    //private AutoPilotUI autoPilotUI;
    private AutoPilotSoftTouch autopilotoftTouch;

    private void Awake()
    {
        //autoPilotUI = GetComponent<AutoPilotUI>();
        autopilotoftTouch = GetComponent<AutoPilotSoftTouch>();
    }

    //getters and setters
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

    public float Pitch { get => pitch; set => pitch = value; }
    public float Roll { get => roll; set => roll = value; }
    public bool IsAuto { get => isAuto; set => isAuto = value; }

}

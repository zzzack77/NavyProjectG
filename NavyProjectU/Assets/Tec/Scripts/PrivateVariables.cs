using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PrivateVariables : MonoBehaviour
{
    //Variables
    /*Using variables tutorial
     * declare variable.
     
    private PrivateVariables _variables;

     * in start/awake get the component
     
    _variables = GetComponent<PrivateVariables>();
    
     * then call varaible by referenecing used name e.g. _variables
    
    _variables.instertYourVariableHere = 0;
     */

    //rotation variables
    private float heading;
    private float pitch;
    private float roll;

    //ui variables
    private float setCourse;
    private float distanceFromGround;
    private bool isAuto;

    //getters and setters
    public float Heading 
    {
        get => heading;
        set
        {
            if (value < 0) heading = value + 360;
            if (value > 360) heading = value - 360;
            else heading = value;
        }
    }
    public float Pitch { get => pitch; set => pitch = value; }
    public float Roll { get => roll; set => roll = value; }
    public float SetCourse { get => setCourse; set => setCourse = value; }
    public bool IsAuto { get => isAuto; set => isAuto = value; }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RudderAngleUI : MonoBehaviour
{
    private PrivateVariables privateVariables;

    public GameObject portRudderDial;
    public GameObject starRudderDial;
    public GameObject portClinometer;
    public GameObject starClinometer;

    private float rudderAngleUnitScaler = 136 / 35f;
    private float clinometerUnitScaler = 10;
    // Start is called before the first frame update
    void Start()
    {
        privateVariables = GameObject.FindGameObjectWithTag("Player").GetComponent<PrivateVariables>();
    }
    
    public void SetPortRudderAngle(float rotation)
    {
        rotation *= rudderAngleUnitScaler;
        portRudderDial.transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
    public void SetStarRudderAngle(float rotation)
    {
        rotation *= rudderAngleUnitScaler;
        starRudderDial.transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    public void SetPortClinometer(float rotation)
    {
        rotation *= clinometerUnitScaler;
        portClinometer.transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
    public void SetStarClinometer(float rotation)
    {
        rotation *= clinometerUnitScaler;
        starClinometer.transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
}

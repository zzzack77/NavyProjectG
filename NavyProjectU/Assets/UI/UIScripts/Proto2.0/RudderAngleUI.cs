using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RudderAngleUI : MonoBehaviour
{
    private PrivateVariables privateVariables;

    public GameObject portRudderDial;
    public GameObject starRudderDial;

    public GameObject portClinometerDial;
    public GameObject starClinometerDial;

    public GameObject portEngineRevsDialActual;
    public GameObject portEngineRevsDialPredicted;
    public GameObject starEngineRevsDialActual;
    public GameObject starEngineRevsDialPredicted;

    private float rudderAngleUnitScaler = 20/5;
    private float clinometerUnitScaler = 2;
    private float engineRevsUnitScaler = 3f/5f;

    public float value;
    // Start is called before the first frame update
    void Start()
    {
        privateVariables = GameObject.FindGameObjectWithTag("Player").GetComponent<PrivateVariables>();
        
    }
    private void Update()
    {
        //Debug.Log(engineRevsUnitScaler);
        //setPortEngineRevs(value);
    }
    public void SetPortRudderAngle(float rotation)
    {
        rotation *= rudderAngleUnitScaler;
        //portRudderDial.transform.rotation = Quaternion.Euler(portRudderDial.transform.rotation.eulerAngles.x, 0, rotation);
        portRudderDial.transform.localRotation = Quaternion.Euler(0, 0, rotation);
    }
    public void SetStarRudderAngle(float rotation)
    {
        rotation *= rudderAngleUnitScaler;
        //starRudderDial.transform.rotation = Quaternion.Euler(starRudderDial.transform.rotation.eulerAngles.x, 0, rotation);
        starRudderDial.transform.localRotation = Quaternion.Euler(0, 0, rotation);

    }

    public void SetPortClinometer(float rotation)
    {
        rotation *= clinometerUnitScaler;
        portClinometerDial.transform.localRotation = Quaternion.Euler(0, 0, rotation);
    }
    public void SetStarClinometer(float rotation)
    {
        rotation *= clinometerUnitScaler;
        starClinometerDial.transform.localRotation = Quaternion.Euler(0, 0, rotation);
    }

    // Engine revs
    public void setPortEngineRevsActual(float rotation)
    {
        rotation *= engineRevsUnitScaler;
        portEngineRevsDialActual.transform.localRotation = Quaternion.Euler(0, 0, -rotation);
    }
    public void setPortEngineRevsPredicted(float rotation)
    {
        rotation *= engineRevsUnitScaler;
        portEngineRevsDialPredicted.transform.localRotation = Quaternion.Euler(0,0, -rotation);
    }
    public void setStarEngineRevsActual(float rotation)
    {
        rotation *= engineRevsUnitScaler;
        starEngineRevsDialActual.transform.localRotation = Quaternion.Euler(0, 0, -rotation);
    }
    public void setStarEngineRevsPredicted(float rotation)
    {
        rotation *= engineRevsUnitScaler;
        starEngineRevsDialPredicted.transform.localRotation = Quaternion.Euler(0, 0, -rotation);
    }
}

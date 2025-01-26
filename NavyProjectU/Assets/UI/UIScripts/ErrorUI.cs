using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ErrorUI : MonoBehaviour
{
    PrivateVariables _privateVariables;
    // Start is called before the first frame update
    void Start()
    {
        _privateVariables = GameObject.FindGameObjectWithTag("Player").GetComponent<PrivateVariables>();

        _privateVariables.SystemFailure = false;
        Debug.Log(_privateVariables.SystemFailure.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            _privateVariables.SystemFailure = true;
            Debug.Log(_privateVariables.SystemFailure.ToString());

        }
    }
    public void AcknowledgeAll()
    {
        _privateVariables.RudderIndicatorFailure = false;
        _privateVariables.LogFailure = false;
        _privateVariables.AutoPilotFailure = false;
        _privateVariables.SteeringGearFailure = false;
        _privateVariables.GyroFailure = false;
        _privateVariables.SystemFailure = false;
        Debug.Log("Error Acknowledge");
    }
    public void SystemFailureAcknowledge()
    {
        _privateVariables.SystemFailure = false;
        Debug.Log(_privateVariables.SystemFailure.ToString());
        Debug.Log("Error Acknowledge");
    }
    public void GyroFailureAcknowledge()
    {
        _privateVariables.GyroFailure = false;
        Debug.Log(_privateVariables.GyroFailure.ToString());
        Debug.Log("Error Acknowledged");
    }
    public void SteeringGearFailureAcknowledge()
    {
        _privateVariables.SteeringGearFailure = false;
        Debug.Log(_privateVariables.SteeringGearFailure.ToString());
        Debug.Log("Error Acknowledged");
    }
    public void AutoPilotFailureAcknowledge()
    {
        _privateVariables.AutoPilotFailure = false;
        Debug.Log(_privateVariables.AutoPilotFailure.ToString());
        Debug.Log("Error Acknowledged");
    }
    public void LogFailureAcknowledge()
    {
        _privateVariables.LogFailure = false;
        Debug.Log(_privateVariables.LogFailure.ToString());
        Debug.Log("Error Acknowledged");
    }
    public void RudderIndicatorAcknowledge()
    {
        _privateVariables.RudderIndicatorFailure = false;
        Debug.Log(_privateVariables.RudderIndicatorFailure.ToString());
        Debug.Log("Error Acknowledged");
    }
}

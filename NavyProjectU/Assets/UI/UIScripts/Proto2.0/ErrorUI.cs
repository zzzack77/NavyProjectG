using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ErrorUI : MonoBehaviour
{
    PrivateVariables _privateVariables;

    private Button systemFailureB;
    private Button gyroFailureB;
    private Button steeringGearFailureB;
    private Button autoPilotFailureB;
    private Button logFailureB;
    private Button rudderIndicatorFailureB;

    // Start is called before the first frame update
    void Start()
    {
        _privateVariables = GameObject.FindGameObjectWithTag("Player").GetComponent<PrivateVariables>();

        GameObject errorUICanvas = GameObject.Find("ErrorSTouchUI");
        if (errorUICanvas != null)
        {
            Button[] buttons = errorUICanvas.GetComponentsInChildren<Button>();

            var buttonMappings = new Dictionary<string, (Action listener, Action<Button> assign)>
            {
                { "SystemFailureB", (SystemFailureAcknowledge, b => systemFailureB = b) },
                { "GyroFailureB", (GyroFailureAcknowledge, b => gyroFailureB = b) },
                { "SteeringGearFailureB", (SteeringGearFailureAcknowledge, b => steeringGearFailureB = b) },
                { "AutoPilotFailureB", (AutoPilotFailureAcknowledge, b => autoPilotFailureB = b) },
                { "LogFailureB", (LogFailureAcknowledge, b => logFailureB = b) },
                { "RudderIndicatorFailureB", (RudderIndicatorAcknowledge, b => rudderIndicatorFailureB = b) }
            };

            foreach (Button button in buttons)
            {
                if (buttonMappings.TryGetValue(button.name, out var mapping))
                {
                    mapping.assign(button);
                    button.onClick.AddListener(() => mapping.listener());
                    //Debug.Log($"{button.name} assigned");
                }
            }
        }
        else
        {
            Debug.LogError("Error Soft Touch Pannel failed to be initilised");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Triggering errors
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _privateVariables.SystemFailure = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _privateVariables.GyroFailure = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _privateVariables.SteeringGearFailure = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _privateVariables.AutoPilotFailure = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            _privateVariables.LogFailure = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            _privateVariables.RudderIndicatorFailure = true;
        }
    }
    public void ActivateSystemFailure(Button FailureB)
    {
        if (FailureB != null)
        {
            
            _privateVariables.SystemFailure = true;
            Image buttonImage = FailureB.GetComponent<Image>();
            buttonImage.color = Color.red;
        }
    }
    public void UpdateFailures()
    {
        string hexColorGrey = "#898989";
        string hexColorRed = "#410000";

        if (ColorUtility.TryParseHtmlString(hexColorGrey, out Color greyColor) &&
            ColorUtility.TryParseHtmlString(hexColorRed, out Color redColor))
        {
            if (_privateVariables != null)
            {
                UpdateButtonColor(systemFailureB, _privateVariables.SystemFailure, redColor, greyColor);
                UpdateButtonColor(gyroFailureB, _privateVariables.GyroFailure, redColor, greyColor);
                UpdateButtonColor(steeringGearFailureB, _privateVariables.SteeringGearFailure, redColor, greyColor);
                UpdateButtonColor(autoPilotFailureB, _privateVariables.AutoPilotFailure, redColor, greyColor);
                UpdateButtonColor(logFailureB, _privateVariables.LogFailure, redColor, greyColor);
                UpdateButtonColor(rudderIndicatorFailureB, _privateVariables.RudderIndicatorFailure, redColor, greyColor);
            }
        }
    }
    private void UpdateButtonColor(Button button, bool failureState, Color redColor, Color greyColor)
    {
        if (button != null)
        {
            Image buttonImage = button.GetComponent<Image>();
            buttonImage.color = failureState ? redColor : greyColor;
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
    }
    public void SystemFailureAcknowledge() { _privateVariables.SystemFailure = false; }
    public void GyroFailureAcknowledge() { _privateVariables.GyroFailure = false; }
    public void SteeringGearFailureAcknowledge() { _privateVariables.SteeringGearFailure = false; }
    public void AutoPilotFailureAcknowledge() { _privateVariables.AutoPilotFailure = false; }
    public void LogFailureAcknowledge() { _privateVariables.LogFailure = false; }
    public void RudderIndicatorAcknowledge() { _privateVariables.RudderIndicatorFailure = false; }
}

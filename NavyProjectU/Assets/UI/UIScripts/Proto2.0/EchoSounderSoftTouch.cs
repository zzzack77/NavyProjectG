using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EchoSounderSoftTouch : MonoBehaviour
{
    private PrivateVariables _PrivateVariables;

    public GameObject depthLabel;
    public GameObject alarmLimitLable;

    private int currentAlarmLimit;

    public bool isAlarmSounding;
    private bool isMeters = true;

    void Start() { _PrivateVariables = GetComponent<PrivateVariables>(); }

    void Update() { if (isAlarmSounding) { AlarmSounding(); } }

    // Put code for alarm here
    public void AlarmSounding()
    {
        Debug.Log("The alarm has triggered");
    }
    public void PressFeetButton()
    {
        isMeters = false;
        UpdateDepthLabel(_PrivateVariables.DistanceFromGround);
        UpdateAlarmLimit(currentAlarmLimit);
    }
    public void PressMeterButton()
    {
        isMeters = true;
        UpdateDepthLabel(_PrivateVariables.DistanceFromGround);
        UpdateAlarmLimit(currentAlarmLimit);
    }
    public void PressBowButton() { _PrivateVariables.IsBow = true; }
    public void PressSternButton() { _PrivateVariables.IsBow = false; }
    
    // Button presses for input alarm limit
    public void PressHunderedButton() { PressInputButton(100); }
    public void PressTenButton() { PressInputButton(10); }
    public void PressOneButton() { PressInputButton(1); }
    public void PressResetButton() { PressInputButton(0); }
    public void PressInputButton(int number)
    {
        currentAlarmLimit = number;
        isAlarmSounding = false;
        UpdateAlarmLimit(currentAlarmLimit);
    }

    // Update alarm label
    public void UpdateAlarmLimit(int value)
    {
        TextMeshProUGUI _alarmLimitLable = alarmLimitLable.GetComponentInChildren<TextMeshProUGUI>();
        _alarmLimitLable.text = value.ToString("000.0");
    }

    // Updates the depth label every time the depth is changed 
    // Depth displayed takes into consideration unit (feet or meters) and checks if depth has dipped below the alarm limit
    public void UpdateDepthLabel(float value)
    {
        TextMeshProUGUI _depthLabel = depthLabel.GetComponentInChildren<TextMeshProUGUI>();
        if (isMeters) { _depthLabel.text = value.ToString("000.0"); }
        else { _depthLabel.text = (value * 3.28084).ToString("000.0"); }

        if (isMeters)
        {
            if (value <= currentAlarmLimit && currentAlarmLimit != 0) { isAlarmSounding = true;}
            else { isAlarmSounding = false; }
        }
        else
        {
            if ((value * 3.28084) <= currentAlarmLimit && currentAlarmLimit != 0) { isAlarmSounding = true; }
            else { isAlarmSounding = false;}
        }
        
    }
}

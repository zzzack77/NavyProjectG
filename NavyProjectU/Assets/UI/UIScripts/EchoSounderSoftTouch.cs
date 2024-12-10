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
    // Start is called before the first frame update
    void Start()
    {
        _PrivateVariables = GetComponent<PrivateVariables>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            _PrivateVariables.DistanceFromGround ++;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            _PrivateVariables.DistanceFromGround--;
        }
        if (isAlarmSounding)
        {
            AlarmSounding();
        }
    }
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
    public void PressBowButton()
    {
        _PrivateVariables.IsBow = true;
    }
    public void PressSternButton()
    {
        _PrivateVariables.IsBow = false;

    }
    public void PressResetButton()
    {
        currentAlarmLimit = 0;
        UpdateAlarmLimit(currentAlarmLimit);
        isAlarmSounding = false;
    }
    public void PressHunderedButton()
    {
        currentAlarmLimit = 100;
        UpdateAlarmLimit(currentAlarmLimit);
        isAlarmSounding = false;
    }
    public void PressTenButton()
    {
        currentAlarmLimit = 10;
        isAlarmSounding = false;
        UpdateAlarmLimit(currentAlarmLimit);
    }
    public void PressOneButton()
    {
        currentAlarmLimit = 1;
        isAlarmSounding = false;
        UpdateAlarmLimit(currentAlarmLimit);
    }
    public void UpdateAlarmLimit(int value)
    {
        TextMeshProUGUI _alarmLimitLable = alarmLimitLable.GetComponentInChildren<TextMeshProUGUI>();
        _alarmLimitLable.text = value.ToString("000.0");
    }
    public void UpdateDepthLabel(float value)
    {
        TextMeshProUGUI _depthLabel = depthLabel.GetComponentInChildren<TextMeshProUGUI>();
        if (isMeters) { _depthLabel.text = value.ToString("000.0"); }
        else { _depthLabel.text = (value * 3.28084).ToString("000.0"); }

        if (isMeters)
        {
            if (value >= currentAlarmLimit && currentAlarmLimit != 0) { isAlarmSounding = true;}
            else { isAlarmSounding = false; }
        }
        else
        {
            if ((value * 3.28084) >= currentAlarmLimit && currentAlarmLimit != 0) { isAlarmSounding = true; }
            else { isAlarmSounding = false;}
        }
        
    }
}

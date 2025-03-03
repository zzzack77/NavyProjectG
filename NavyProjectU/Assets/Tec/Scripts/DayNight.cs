using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;

public class DayNight : MonoBehaviour
{

    InputSubscription InputManager;
    GameObject globalLight;
    Light dirLight;

    public bool bDaytime = true;

    private void Start()
    {
        InputManager = GetComponent<InputSubscription>();

        globalLight = GameObject.Find("GlobalLight");
        dirLight = globalLight.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SetDay();
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            SetNight();
        }
        else
        {
            UnityEngine.Debug.Log("Day: " + bDaytime);
        }
    }

    public void SetDay()
    {
        UnityEngine.Debug.Log("Day");
        bDaytime = true;
        UnityEngine.RenderSettings.reflectionIntensity = 0.5f;
        UnityEngine.RenderSettings.ambientSkyColor = new Vector4(0.2862745f, 0.2862745f, 0.2862745f);
        dirLight.intensity = 1.0f;
        globalLight.transform.eulerAngles = new Vector3(160, 30, 0);
    }

    public void SetNight()
    {
        UnityEngine.Debug.Log("Night");
        bDaytime = false;
        UnityEngine.RenderSettings.reflectionIntensity = 0.1f;
        UnityEngine.RenderSettings.ambientSkyColor = new Vector4(0.04205232f, 0.05463764f, 0.06603771f);
        dirLight.intensity = 0.1f;
        globalLight.transform.eulerAngles = new Vector3(275, 30, 0);
    }
}

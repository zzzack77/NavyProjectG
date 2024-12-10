using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheelxAxes : MonoBehaviour
{
    LogitechGSDK.LogiControllerPropertiesData properties;
    public float xAxes;

    private void Start()
    {

    }

    void Update()
    {
        if (LogitechGSDK.LogiUpdate() && LogitechGSDK.LogiIsConnected(0))
        {
            LogitechGSDK.DIJOYSTATE2ENGINES rec;
            rec = LogitechGSDK.LogiGetStateUnity(0);

            xAxes = rec.lX / 32768f;
        }
        else
        {
            //print("No Steering Wheel Connected");
        }
    }
}

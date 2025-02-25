using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringWheelxAxes : MonoBehaviour
{
    LogitechGSDK.LogiControllerPropertiesData properties;
    public float xAxes, ThrottleInput;

    private void Start()
    {
        print(LogitechGSDK.LogiSteeringInitialize(false));
    }

    void Update()
    {
        if (LogitechGSDK.LogiUpdate() && LogitechGSDK.LogiIsConnected(0))
        {
            LogitechGSDK.DIJOYSTATE2ENGINES rec;
            rec = LogitechGSDK.LogiGetStateUnity(0);

            xAxes = rec.lX / 32768f; // for -1 to 1

            if(rec.lY < 0f)
            {
                ThrottleInput = 0f;
            }
            else if (rec.lY < 0f)
            {
                ThrottleInput = rec.lY / -32768f; // for -1 to 1
            }
        }
        else
        {
            print("No Steering Wheel Connected");
        }
    }
}

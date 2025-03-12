using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class LogitechThrottleInput : MonoBehaviour
{

    public float lastFrameValuePort;
    public float lastFrameValueStarboard;
    public float currentValue;

    public float portCounter = 1.0f;
    public float starCounter = 1.0f;

    public float portValue;
    public float starValue;

    InputSubscription InputManager;

    // Start is called before the first frame update
    void Start()
    {
        InputManager = GetComponent<InputSubscription>();
    }

    // Update is called once per frame
    void Update()
    {
        portValue = GetThrottleValue(true);
        //UnityEngine.Debug.Log(portValue);
        starValue = GetThrottleValue(false);
        //UnityEngine.Debug.Log(starValue);
        lastFrameValuePort = InputManager.PortThrottle;
        lastFrameValueStarboard = InputManager.StarboardThrottle;
    }

    public float GetThrottleValue(bool bPort)
    {

        float throttleDir = CheckThrottleDirection(bPort);

        //UnityEngine.Debug.Log(throttleDir);

        if (bPort)
        {
            currentValue = InputManager.PortThrottle;

            if (currentValue > 0.99 && throttleDir == 1)
            {
                portCounter += 1;
            }
            else if (currentValue < -0.99 && throttleDir == -1)
            {
                portCounter -= 1;
            }

            if (portCounter < 1)
            {
                portCounter = 1;
            }
            else if (portCounter > 15)
            {
                portCounter = 15;
            }

            //UnityEngine.Debug.Log(InputManager.PortThrottle / (portCounter / 15));
            return (InputManager.PortThrottle * (portCounter/15));
        }
        else
        {
            currentValue = InputManager.StarboardThrottle;

            if (currentValue == -1 && lastFrameValueStarboard > 0.8)
            {
                UnityEngine.Debug.Log(throttleDir);
                starCounter += 1;
            }
            else if (currentValue < -0.99 && throttleDir == -1)
            {
                starCounter -= 1;
            }

            if (starCounter < 1)
            {
                starCounter = 1;
            }
            else if (starCounter > 15)
            {
                starCounter = 15;
            }

            //UnityEngine.Debug.Log(InputManager.StarboardThrottle / (starCounter / 15));
            return (InputManager.StarboardThrottle * (starCounter/15));
        }
    }

    public float CheckThrottleDirection(bool bPort)
    {

        if (bPort)
        {
            currentValue = InputManager.PortThrottle;
            //UnityEngine.Debug.Log("ThrottleInput Test");

            if (currentValue > lastFrameValuePort)
            {
                //UnityEngine.Debug.Log(1);
                return 1;
            }
            else if (currentValue < lastFrameValuePort)
            {
                //UnityEngine.Debug.Log(-1);
                return -1;
            }
            else
            {
                //UnityEngine.Debug.Log(0);
                return 0;
            }
        }
        else
        {
            currentValue = InputManager.StarboardThrottle;
            if (currentValue > lastFrameValueStarboard)
            {
                //UnityEngine.Debug.Log(1);
                return 1;
            }
            else if (currentValue < lastFrameValueStarboard)
            {
                //UnityEngine.Debug.Log(-1);
                return -1;
            }
            else
            {
                //UnityEngine.Debug.Log(0);
                return 0;
            }
        }
    }
}

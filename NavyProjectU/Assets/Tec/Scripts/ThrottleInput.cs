using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThrottleInput : MonoBehaviour
{
    public InputActionAsset inputActions;
    private InputAction rxAction;
    private InputAction ryAction;
    private InputAction zAction;

    private void OnEnable()
    {
        // Find the actions from the input action asset
        rxAction = inputActions.FindAction("ThrottleAction/Rx");
        ryAction = inputActions.FindAction("ThrottleAction/Ry");
        zAction = inputActions.FindAction("ThrottleAction/Z");

        //rxAction = inputActions.was

        // Enable the input actions
        rxAction.Enable();
        ryAction.Enable();
        zAction.Enable();
    }

    private void OnDisable()
    {
        // Disable the input actions when the script is disabled
        rxAction.Disable();
        ryAction.Disable();
        zAction.Disable();
    }

    private void Update()
    {
        // Read the axis values as floats
        float rxValue = rxAction.ReadValue<float>();
        float ryValue = ryAction.ReadValue<float>();
        float zValue = zAction.ReadValue<float>();

        // Print the values for debugging purposes
        Debug.Log("RX: " + rxValue);
        Debug.Log("RY: " + ryValue);
        Debug.Log("Z: " + zValue);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSubscription : MonoBehaviour
{
    public Vector2 Turn { get; private set; } = Vector2.zero;
    public float PortThrottle { get; private set; } = 0.0f;
    public float StarboardThrottle { get; private set; } = 0.0f;
    public bool PortToggle { get; private set; } = false;
    public bool StarboardToggle { get; private set; } = false;
    public bool Day { get; private set; } = false;
    public bool Night { get; private set; } = false;

    InputMap input = null;

    private void OnEnable()
    {
        input = new InputMap();

        input.SteeringWheel.Enable();

        input.SteeringWheel.Turn.performed += SetSteering;
        input.SteeringWheel.Turn.canceled += SetSteering;

        input.SteeringWheel.PortThrottle.performed += SetPortThrottle;
        input.SteeringWheel.PortThrottle.canceled += SetPortThrottle;

        input.SteeringWheel.StarboardThrottle.performed += SetStarboardThrottle;
        input.SteeringWheel.StarboardThrottle.canceled += SetStarboardThrottle;

        //input.SteeringWheel.PortToggle.started += SetPortToggle;
        //input.SteeringWheel.PortToggle.canceled += SetPortToggle;

        //input.SteeringWheel.StarboardToggle.started += SetStarboardToggle;
        //input.SteeringWheel.StarboardToggle.canceled += SetStarboardToggle;
    }

    private void OnDisable()
    {
        input.SteeringWheel.Turn.performed -= SetSteering;
        input.SteeringWheel.Turn.canceled -= SetSteering;

        input.SteeringWheel.PortThrottle.performed -= SetPortThrottle;
        input.SteeringWheel.PortThrottle.canceled -= SetPortThrottle;

        input.SteeringWheel.StarboardThrottle.performed -= SetStarboardThrottle;
        input.SteeringWheel.StarboardThrottle.canceled -= SetStarboardThrottle;

        //input.SteeringWheel.PortToggle.started -= SetPortToggle;
        //input.SteeringWheel.PortToggle.canceled -= SetPortToggle;

        //input.SteeringWheel.StarboardToggle.started -= SetStarboardToggle;
        //input.SteeringWheel.StarboardToggle.canceled -= SetStarboardToggle;

        input.SteeringWheel.Disable();
    }

    private void Update()
    {
        PortToggle = input.SteeringWheel.PortToggle.WasPressedThisFrame();
        StarboardToggle = input.SteeringWheel.StarboardToggle.WasPressedThisFrame();
        Day = input.SteeringWheel.Day.WasPressedThisFrame();
        Night = input.SteeringWheel.Night.WasPressedThisFrame();
    }

    void SetSteering(InputAction.CallbackContext ctx)
    {
        Turn = ctx.ReadValue<Vector2>();
    }

    void SetPortThrottle(InputAction.CallbackContext ctx)
    {
        PortThrottle = ctx.ReadValue<float>();
    }

    void SetStarboardThrottle(InputAction.CallbackContext ctx)
    {
        StarboardThrottle = ctx.ReadValue<float>();
    }

    //void SetPortToggle(InputAction.CallbackContext ctx)
    //{
    //    PortToggle = ctx.started;
    //}

    //void SetStarboardToggle(InputAction.CallbackContext ctx)
    //{
    //    StarboardToggle = ctx.started;
    //}
}

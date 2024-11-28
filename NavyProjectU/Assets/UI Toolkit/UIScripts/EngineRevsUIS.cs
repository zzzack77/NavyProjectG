using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EngineRevsUIS : MonoBehaviour
{
    private UIDocument _UIDocumentdocument;
    private PrivateVariables _PrivateVariables;

    // Dials are stored as visual elements from left to right top to bottom
    public VisualElement portPropellerPitchTrue;
    public VisualElement portPropellerPitchPredicted;

    public VisualElement portEngineRPM;

    public VisualElement starboardPropellerPitchTrue;
    public VisualElement starboardPropellerPitchPredicted;

    public VisualElement portPropellerRPMTrue;
    public VisualElement portPropellerRPMPredicted;

    private VisualElement starboardEngineRPM;

    public VisualElement starboardPropellerRPMTrue;
    public VisualElement starboardPropellerRPMPredicted;

    // The speed at which the yellow dials follow the white
    public float portPropellerPitchRate = 1f;
    public float starboardPropellerPitchRate = 1f;
    public float portPropellerRPMRate = 1f;
    public float starboardPropellerRPMRate = 1f;

    // Target values for predicted dials (white)
    private float portPropellerPitchTarget;
    private float starboardPropellerPitchTarget;
    private float portPropellerRPMTarget;
    private float starboardPropellerRPMTarget;

    // Current rotation values for true dials (yellow)
    private float portPropellerPitchCurrent;
    private float starboardPropellerPitchCurrent;
    private float portPropellerRPMCurrent;
    private float starboardPropellerRPMCurrent;

    // Testing variables
    public float testPortPropPitch;
    public float testPortEngine;
    public float testStarPropPitch;
    public float testPortPropRPM;
    public float testStarEngine;
    public float testStarPropRPM;

    void Start()
    {
        _UIDocumentdocument = GetComponent<UIDocument>();
        _PrivateVariables = GetComponent<PrivateVariables>();

        // Follows the path from left to right top to bottom. Elements with white and yellow dials are grouped in two's
        // Using query search to find each visual element dial
        portPropellerPitchTrue = _UIDocumentdocument.rootVisualElement.Q("portPropellerPitchTrueD") as VisualElement;
        portPropellerPitchPredicted = _UIDocumentdocument.rootVisualElement.Q("portPropellerPitchPredictedD") as VisualElement;

        portEngineRPM = _UIDocumentdocument.rootVisualElement.Q("portEngineRPMD") as VisualElement;

        starboardPropellerPitchTrue = _UIDocumentdocument.rootVisualElement.Q("starboardPropellerPitchTrueD") as VisualElement;
        starboardPropellerPitchPredicted = _UIDocumentdocument.rootVisualElement.Q("starboardPropellerPitchPredictedD") as VisualElement;

        portPropellerRPMTrue = _UIDocumentdocument.rootVisualElement.Q("portPropellerRPMTrueD") as VisualElement;
        portPropellerRPMPredicted = _UIDocumentdocument.rootVisualElement.Q("portPropellerRPMPredictedD") as VisualElement;

        starboardEngineRPM = _UIDocumentdocument.rootVisualElement.Q("starboardEngineRPMD") as VisualElement;

        starboardPropellerRPMTrue = _UIDocumentdocument.rootVisualElement.Q("starboardPropellerRPMTrueD") as VisualElement;
        starboardPropellerRPMPredicted = _UIDocumentdocument.rootVisualElement.Q("starboardPropellerRPMPredictedD") as VisualElement;

        // Put initial values in here
        portPropellerPitchCurrent = 0f;
        starboardPropellerPitchCurrent = 0f;
        portPropellerRPMCurrent = 0f;
        starboardPropellerRPMCurrent = 0f;
    }

    void Update()
    {
        // Smoothly update the yellow dials to follow the predicted (white) dials
        portPropellerPitchCurrent = UpdateDialTrue(portPropellerPitchTrue, portPropellerPitchRate, portPropellerPitchCurrent, portPropellerPitchTarget, -4, 9);
        starboardPropellerPitchCurrent = UpdateDialTrue(starboardPropellerPitchTrue, starboardPropellerPitchRate, starboardPropellerPitchCurrent, starboardPropellerPitchTarget, -4, 9);
        portPropellerRPMCurrent = UpdateDialTrue(portPropellerRPMTrue, portPropellerRPMRate, portPropellerRPMCurrent, portPropellerRPMTarget, -250, 500);
        starboardPropellerRPMCurrent = UpdateDialTrue(starboardPropellerRPMTrue, starboardPropellerRPMRate, starboardPropellerRPMCurrent, starboardPropellerRPMTarget, -250, 500);


        // Tester functions to show they are working
        SetPortPropellerPitchPredicted(testPortPropPitch);
        SetPortEngineRPM(testPortEngine);
        SetStarboardPropellerPitchPredicted(testStarPropPitch);
        SetPortPropellerRPMPredicted(testPortPropRPM);
        SetStarboardEngineRPM(testStarEngine);
        SetStarboardPropellerRPMPredicted(testStarPropRPM);
    }

    // The four functions below are do the same thing but for each different dial
    // The functions set the predicted dial (white) and updated the target for the true dials (yellow)
    public void SetPortPropellerPitchPredicted(float pitch)
    {
        portPropellerPitchTarget = Mathf.Clamp(pitch, 0f, 8f);
        UpdateDialPredicted(portPropellerPitchPredicted, portPropellerPitchTarget, -4, 9);
    }

    public void SetStarboardPropellerPitchPredicted(float pitch)
    {
        starboardPropellerPitchTarget = Mathf.Clamp(pitch, 0f, 8f);
        UpdateDialPredicted(starboardPropellerPitchPredicted, starboardPropellerPitchTarget, -4, 9);
    }

    public void SetPortPropellerRPMPredicted(float rpm)
    {
        portPropellerRPMTarget = Mathf.Clamp(rpm, -250f, 250f);
        UpdateDialPredicted(portPropellerRPMPredicted, portPropellerRPMTarget, -250, 500);
    }

    public void SetStarboardPropellerRPMPredicted(float rpm)
    {
        starboardPropellerRPMTarget = Mathf.Clamp(rpm, -250f, 250f);
        UpdateDialPredicted(starboardPropellerRPMPredicted, starboardPropellerRPMTarget, -250, 500);
    }

    // Function to set the rotation for the Port Engine (RPM)
    public void SetPortEngineRPM(float rpm)
    {
        // Clamp RPM to range 0 to 3000
        float clampedRPM = Mathf.Clamp(rpm, 0f, 3000f);
        float angleInTurns = clampedRPM / 3000f;
        portEngineRPM.style.rotate = new Rotate(new Angle(angleInTurns, AngleUnit.Turn));
    }

    // Function to set the rotation for the Starboard Engine (RPM)
    public void SetStarboardEngineRPM(float rpm)
    {
        // Clamp RPM to range 0 to 3000
        float clampedRPM = Mathf.Clamp(rpm, 0f, 3000f);
        float angleInTurns = clampedRPM / 3000f;
        starboardEngineRPM.style.rotate = new Rotate(new Angle(angleInTurns, AngleUnit.Turn));
    }

    // Updates the predicted (white) dials
    private void UpdateDialPredicted(VisualElement dial, float targetValue, float offset, float range)
    {
        float angleInTurns = (targetValue + offset) / range;
        dial.style.rotate = new Rotate(new Angle(angleInTurns, AngleUnit.Turn));
    }

    // Updates the true (yellow) dials over time by using lerping
    private float UpdateDialTrue(VisualElement dial, float rate, float currentValue, float targetValue, float offset, float range)
    {
        // Lerp yellow dial towards white dial
        float newValue = Mathf.Lerp(currentValue, targetValue, rate * Time.deltaTime);

        // Update the yellow dial rotation
        float angleInTurns = (newValue + offset) / range;
        dial.style.rotate = new Rotate(new Angle(angleInTurns, AngleUnit.Turn));

        // Return the updated current value
        return newValue;
    }
}


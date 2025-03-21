using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AssessorUI : MonoBehaviour
{
    //public ReflectionProbe baker;
    //public GameObject reflectionbean;
    public ReflectionProbe reflectionProbe;

    // Scripts
    private PrivateVariables privateVariables;
    public VRCalibration vrCalibration;
    public ThrottleCalibration throttleCalibration;
    public DayNight dayNight;
    public SkyboxManager skyboxManager;
    public GameObject headingValue;

    // Errors
    [Header("Errors")]
    public Button systemFailureB;
    public Button gyroFailureB;
    public Button steeringGearFailureB;
    public Button autoPilotFailureB;
    public Button logFailureB;
    public Button rudderIndicatorFailureB;

    // Assessor control buttons
    [Header("Assessor control buttons")]
    public Button pauseB;
    public Button restartB;
    public Button endB;

    // Settings
    [Header("Settings")]
    public Button resetPlayerPosB;
    public Button resetThrottleB;
    public Button toggleRainB;
    public Button toggleFogB;
    public Button toggleRedSunB;
    public Button toggleNightB;

    // Boat stats
    //public Button rudderAngleB;
    //public Button rateOfTurnB;
    //public Button throttleSpeedB;

    [Header("Boat stats")]
    public GameObject rudderAngleV;
    public GameObject rateOfTurnV;
    public GameObject boatSpeedV;

    public RawImage HeadingImage;
    public Transform Ship;

    public GameObject rain;

    private float ye = 1 / 360f;

    private float offset = 179.49865f;

    public bool isPaused = false;


    // Start is called before the first frame update
    void Start()
    {
        privateVariables = GetComponent<PrivateVariables>();
        dayNight = GetComponent<DayNight>();
        skyboxManager = GetComponent<SkyboxManager>();

        //baker = gameObject.AddComponent<ReflectionProbe>();
        //baker.cullingMask = 0;
        //baker.refreshMode = ReflectionProbeRefreshMode.ViaScripting;
        //baker.mode = ReflectionProbeMode.Realtime;
        //baker.timeSlicingMode = ReflectionProbeTimeSlicingMode.NoTimeSlicing;

        //RenderSettings.defaultReflectionMode = DefaultReflectionMode.Custom;
        //StartCoroutine(UpdateEnvironment());
    }
    private void FixedUpdate()
    {
        HeadingImage.uvRect = new Rect((Ship.localEulerAngles.y * ye) - offset, 0, 1, 1);
    }
    // Error on button click events
    public void Press1SystemFailureB() { privateVariables.SystemFailure = true; }
    public void Press2GyroFailureB() { privateVariables.GyroFailure = true; }
    public void Press3SteeringGearFailureB() { privateVariables.SteeringGearFailure = true; }
    public void Press4AutoPilotFailureB() { privateVariables.AutoPilotFailure = true; }
    public void Press5LogFailureB() { privateVariables.LogFailure = true; }
    public void Press6RudderIndicatorFailureB() { privateVariables.RudderIndicatorFailure = true; }

    // Pause scene
    public void Press11PauseB()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0.0f;
        }
    }
    // Restart the current scene
    public void Press12RestartB()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(currentSceneName);
    }
    // End scene
    public void Press13EndB()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    // These are the function that get called when buttons are pressed
    // place correct code in each function to be called on assessor clicks
    public void PressResetPlayerB() { vrCalibration.VRCalibrateUser(); }
    public void PressResetThrottleB() { throttleCalibration.ThrottleCalibrationFunction(); }
    public void PressDayB() { skyboxManager.SetSkyClear(); reflectionProbe.RenderProbe(); }
    public void PressToggleRainB() { rain.SetActive(!rain.activeSelf); reflectionProbe.RenderProbe(); }
    public void PressToggleFogB() { skyboxManager.SetSkyCloudy(); reflectionProbe.RenderProbe();}
    public void PressToggleRedSun() { skyboxManager.SetSkyRS(); reflectionProbe.RenderProbe(); }
    public void PressToggleNightB() { skyboxManager.SetSkyN(); reflectionProbe.RenderProbe(); }

    public void OnHeadingUpdate(float value)
    {
        TextMeshProUGUI headingText = headingValue.GetComponentInChildren<TextMeshProUGUI>();

        if (headingText != null)
        {
            headingText.text = value.ToString("000.0");
        }
    }
    public void OnRudderAngleUpdate(float value)
    {
        TextMeshProUGUI headingText = rudderAngleV.GetComponentInChildren<TextMeshProUGUI>();

        if (headingText != null)
        {
            headingText.text = value.ToString("0.0");
        }
    }
    public void OnRateOFTurnUpdate(float value)
    {
        TextMeshProUGUI rotText = rateOfTurnV.GetComponentInChildren<TextMeshProUGUI>();

        if (rotText != null)
        {
            rotText.text = value.ToString("0.0");
        }
    }
    public void OnBoatSpeedUpdate(float value)
    {
        TextMeshProUGUI boatSpeedText = boatSpeedV.GetComponentInChildren<TextMeshProUGUI>();

        if (boatSpeedText != null)
        {
            boatSpeedText.text = value.ToString("0.0");
        }
    }
    //IEnumerator UpdateEnvironment()
    //{
    //    DynamicGI.UpdateEnvironment();
    //    baker.RenderProbe();
    //    yield return new WaitForEndOfFrame();
    //    RenderSettings.customReflectionTexture = baker.texture;
    //}
}
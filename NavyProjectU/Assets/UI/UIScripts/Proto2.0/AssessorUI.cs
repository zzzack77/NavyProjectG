using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AssessorUI : MonoBehaviour
{
    private PrivateVariables privateVariables;

    // Errors
    public Button systemFailureB;
    public Button gyroFailureB;
    public Button steeringGearFailureB;
    public Button autoPilotFailureB;
    public Button logFailureB;
    public Button rudderIndicatorFailureB;

    // Assessor editor buttons
    public Button editB;
    public Button resetPlayerPosB;
    public Button resetThrottleB;
    public Button resetWheelB;
    public Button pauseB;
    public Button restartB;
    public Button endB;

    public bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        privateVariables = GetComponent<PrivateVariables>();
    }

    // Error on button click events
    public void Press1SystemFailureB() { privateVariables.SystemFailure = true; }
    public void Press2GyroFailureB() { privateVariables.GyroFailure = true; }
    public void Press3SteeringGearFailureB() { privateVariables.SteeringGearFailure = true;}
    public void Press4AutoPilotFailureB() { privateVariables.AutoPilotFailure = true;}
    public void Press5LogFailureB() { privateVariables.LogFailure = true; }
    public void Press6RudderIndicatorFailureB() { privateVariables.RudderIndicatorFailure = true;}
    public void Press7EditB() { }
    public void Press8ResetPlayerPosB() { }
    public void Press9ResetThrottleB() { }
    public void Press10ResetWheelB() { }
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
}

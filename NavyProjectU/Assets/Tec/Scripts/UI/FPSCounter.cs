using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    public TextMeshProUGUI fpsText;  // Reference to the UI Text element
    private float deltaTime = 0.0f;
    private bool fpsIsOn = false;
    private bool showFps = false;

    void Start()
    {
        if (fpsText == null) // Null check
        {
            Debug.Log("The FPS Text reference is missing!");
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !fpsIsOn) // Sets showFps to true after pressing F
        {
            showFps = true;
        }
        else if (Input.GetKeyDown(KeyCode.F) && fpsIsOn) // Sets showFps to false after pressing F
        {
            showFps = false;
        }

        if (showFps)
        {
            // Calculate time between frames
            deltaTime += (Time.deltaTime - deltaTime) * 0.1f;

            // Calculate FPS
            float fps = 1.0f / deltaTime;
            fpsText.text = $"FPS: {Mathf.Ceil(fps)}";  // Update the UI Text to show fps
            fpsIsOn = true;
        }

        else if (!showFps)
        {
            fpsText.text = "";  // Update the UI to show nothing
            fpsIsOn = false;
        }

    }
}

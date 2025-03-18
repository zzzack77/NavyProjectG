using UnityEngine;

public class MultiDisplaySetup : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;

    void Start()
    {
        if (Display.displays.Length > 1)
        {
            Display.displays[1].Activate();
        }

        if (Display.displays.Length > 2)
        {
            Display.displays[2].Activate();
        }

        // Assign cameras to displays
        camera1.targetDisplay = 0; // Display 1 (Main Display)
        if (camera1 != null)

            if (camera2 != null && Display.displays.Length > 1)
                camera2.targetDisplay = 1; // Display 2 (Second Monitor)
    }
}
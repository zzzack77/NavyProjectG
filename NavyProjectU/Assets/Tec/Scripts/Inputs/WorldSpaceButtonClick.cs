using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class WorldSpaceButtonClick : MonoBehaviour
{
    public Camera camera;  // Camera to cast the ray from
    public Button button;  // Reference to the world-space button

    void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            Debug.Log("cilcickiek");
            // Cast a ray from the camera to where the mouse is pointing
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Debug.DrawRay(transform.position, transform.forward, Color.red, 50f);
            // Perform the raycast and check if it hits the button
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Debug.Log("you hit summin");
                Debug.Log(hit.collider.gameObject.ToString());
                // Check if the raycast hit the button's collider
                if (hit.collider != null && hit.collider.gameObject.CompareTag("Button"))
                {
                    // If the button was clicked, invoke the button click event
                    hit.collider.GetComponent<Button>().onClick.Invoke();
                    Debug.Log("Button Clicked!");
                }

                if (hit.collider != null && hit.collider.gameObject.CompareTag("AutoPilot"))
                {
                    // If the button was clicked, invoke the button click event
                   // hit.collider.GetComponent<Button>().OnPointerDown(hit.collider.GetComponent<>().eventData);
                    Debug.Log("Button Clicked!");
                }
            }
        }
    }
}

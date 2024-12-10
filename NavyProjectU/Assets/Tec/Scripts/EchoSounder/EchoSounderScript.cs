using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoSounder : MonoBehaviour
{
    public GameObject bowEchoSounder;
    public GameObject sternEchoSounder;
    public RaycastHit hit;
    private float height;

    public bool isBow = true;

    void Start()
    {
        InvokeRepeating("WrapperStartEchoSounder", 0f, 1f);
    }

   
    void WrapperStartEchoSounder()
    {
        StartEchoSounder(isBow);
    }

    // Raycast's down from the Bow or Stern depending on the bool isBow and returns the distance from the game object to the sea floor.
    public float StartEchoSounder(bool isBow)
    {
        if (bowEchoSounder != null && sternEchoSounder != null)
        {
            if (isBow == true)
            {
                Ray ES = new(bowEchoSounder.transform.position, -Vector3.up);

                if (Physics.Raycast(ES, out hit))
                {
                    if (hit.collider.CompareTag("SeaFloor"))
                    {
                        height = hit.distance - 0.5f;
                        Debug.Log(height);
                    }
                }
            }

            if (isBow == false)
            {
                Ray ES = new(sternEchoSounder.transform.position, -Vector3.up);

                if (Physics.Raycast(ES, out hit))
                {
                    if (hit.collider.CompareTag("SeaFloor"))
                    {
                        height = hit.distance - 0.5f;
                        Debug.Log(height);
                    }
                }
            }
            return height;
        }
        else
        {
            Debug.Log("Initialise the Bow and Stern echo sounder in the game manager.");
            return 0f;
        }
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateRainPosition : MonoBehaviour
{
    [SerializeField] private GameObject rain;

    public bool rainIsOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rain.transform.position = transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            ToggleRain(rainIsOn);
        }
    }

    public void ToggleRain(bool rainIsOn)
    {
        if (rainIsOn)
        {
            // code for on
            rain.SetActive(true);
            rainIsOn = !rainIsOn;
        }
        else
        {
            // code for off
            rain.SetActive(false);
            rainIsOn = !rainIsOn;
            
        }
    }

}

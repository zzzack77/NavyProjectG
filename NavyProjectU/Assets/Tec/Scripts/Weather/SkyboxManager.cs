using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxManager : MonoBehaviour
{
    public Material Clear;
    public Material Overcast;
    public Material Night;
    public Material RedSun;



    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SetSkyClear();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            SetSkyCloudy();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            SetSkyN();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            SetSkyRS();
        }
 
    }

    public void SetSkyClear()
    {
        RenderSettings.skybox = Clear;
    }

    public void SetSkyCloudy()
    {
        RenderSettings.skybox = Overcast;
    }

    public void SetSkyN()
    {
        RenderSettings.skybox = Night;
    }


    public void SetSkyRS()
    {
        RenderSettings.skybox = RedSun;
    }
}

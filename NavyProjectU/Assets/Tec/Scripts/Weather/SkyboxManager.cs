using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxManager : MonoBehaviour
{
    public Material Clear;
    public Material Overcast;
    public Material Night;
    public Material RedSun;


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

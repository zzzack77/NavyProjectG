using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AudioFunctions : MonoBehaviour
{
    #region AudioSources,Clips
    public AudioSource BoatSource, StarSource, PortSource, AlarmSource, WaveSource, RainSource;
    public AudioClip Waves, BoatEngine, Horn, FaultAlarm, rain;
    public ShipMovement ShipMovement;
    #endregion

    void Start()
    {
        ShipMovement = GameObject.Find("Ship").GetComponent<ShipMovement>();

        BoatIdle();
        Wave();
    }


    void Update()
    {
        BoatHorn();
        BoatThrottle();
    }

    public void Wave()
    {
        if (WaveSource != null)
        {
            WaveSource.clip = Waves;
            WaveSource.Play();

            WaveSource.pitch = ShipMovement.rateOfTurn - 0.65f;
        }
    }

    
    public void StartRain()
    {
        if (RainSource != null)
        {
            RainSource.clip = rain;
            RainSource.Play();
        }
    }
    public void StopRain()
    {
        if (RainSource != null)
        {
            RainSource.Stop();
        }
    }

    void BoatIdle()
    {
        if (PortSource != null)
        {
            PortSource.clip = BoatEngine;
            PortSource.Play();
        }
        if (StarSource != null)
        {
            StarSource.clip = BoatEngine;
            StarSource.Play();
        }
    }

    void BoatThrottle()
    {
        if (PortSource != null)
        {
            PortSource.pitch = ShipMovement.accelPortInput + 0.5f;

            if (PortSource.pitch >= 1.4f)
            {
                PortSource.pitch = 1.4f;
            }
        }

        if (StarSource != null)
        {
            StarSource.pitch = ShipMovement.accelStarboardInput + 0.5f;

            if (StarSource.pitch >= 1.4f)
            {
                StarSource.pitch = 1.4f;
            }
        }
    }

    public void AlarmAudioOn()
    {
        if (AlarmSource != null)
        {
            AlarmSource.clip = FaultAlarm;
            AlarmSource.Play();
        }
    }
    public void AlarmAudioOff()
    {
        if (AlarmSource != null)
        {
            AlarmSource.clip = FaultAlarm;
            AlarmSource.Stop();
        }
    }

    public void BoatHorn()
    {
        if (BoatSource != null)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                BoatSource.PlayOneShot(Horn);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AudioFunctions : MonoBehaviour
{
    #region AudioSources,Clips
    public AudioSource BoatSource, AlarmSource, WaveSource;
    public AudioClip Waves, BoatEngine, Horn, FaultAlarm;
    #endregion

    #region ThrottleVars
    private float keyPressStartTime = -1f;
    private float keyHoldDuration = 0f;
    public float BoatRev;

    private bool IsOn;
    #endregion

    void Start()
    {
        // Start audio for waves and boat idel
        Wave();
        BoatIdle();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) { AlarmAudioOn(); }
        if (Input.GetKeyDown(KeyCode.G)) { AlarmAudioOff(); }
    }

    public void Wave()
    {
        if (WaveSource != null)
        {
            WaveSource.clip = Waves;
            WaveSource.Play();
        }
    }
    void BoatIdle()
    {
        if (BoatSource != null)
        {
            BoatSource.clip = BoatEngine;
            BoatSource.Play();
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
            if (Input.GetKeyDown(KeyCode.B))
            {
                BoatSource.PlayOneShot(Horn);
                Debug.Log("BoatHorn");
            }
        }
        else
        {
            BoatSource = null;
            Debug.Log("No Boat Audio Source");
        }
    }

    public void BoatThrottle()
    {
        #region Forward Throttle
        if (Input.GetKeyDown(KeyCode.W))
        {
            keyPressStartTime = Time.time;
            IsOn = true;
        }

        if (Input.GetKey(KeyCode.W))
        {

            keyHoldDuration = Time.time - keyPressStartTime;
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            keyPressStartTime = -1f;

            keyHoldDuration = 0f;

            IsOn = false;
        }
        #endregion

        #region Reverse Throttle
        if (Input.GetKeyDown(KeyCode.S))
        {
            keyPressStartTime = Time.time;
            IsOn = true;
        }

        if (Input.GetKey(KeyCode.S))
        {

            keyHoldDuration = Time.time - keyPressStartTime;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            keyPressStartTime = -1f;

            keyHoldDuration = 0f;

            IsOn = false;
        }
        #endregion

        if (IsOn == true)
        {
            BoatRev = (keyHoldDuration / 10) + 0.5f;
        }
        else
        {
            BoatRev -= 0.2f * Time.deltaTime;

            if (BoatRev <= 0.5f)
            {
                BoatRev = 0.5f;
            }
        }

        BoatSource.pitch = BoatRev;

        if (BoatRev >= 1.4f)
        {
            BoatSource.pitch = 1.4f;
        }

        //Debug.Log(BoatRev);
    }
}

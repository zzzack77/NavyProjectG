using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AudioFunctions : MonoBehaviour
{
    #region AudioSources,Clips
    public AudioSource BoatSource, PortSource, StarboardSource, AlarmSource, WaveSource;
    public AudioClip Waves, BoatEngine, Horn, FaultAlarm;
    #endregion

    #region ThrottleVars
    private float keyPressStartTime = -1f;
    private float keyHoldDuration = 0f;
    public float BoatRev;

    private bool IsOn;

    public ShipMovement ShipMovement;
    #endregion

    void Start()
    {
        ShipMovement = GameObject.Find("Ship").GetComponent<ShipMovement>();
        
        // Start audio for waves and boat idel
        Wave();
        BoatIdle();
    }

    
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F)) { AlarmAudioOn(); }
        //if (Input.GetKeyDown(KeyCode.G)) { AlarmAudioOff(); }
        BoatThrottle();
        BoatHorn();
    }

    public void Wave()
    {
        if (WaveSource != null)
        {
            WaveSource.clip = Waves;
            WaveSource.Play();

           WaveSource.pitch = ShipMovement.rateOfTurn - 0.75f;
        }
    }
    void BoatIdle()
    {
        if (BoatSource != null)
        {
            PortSource.clip = BoatEngine;
            PortSource.Play();
            StarboardSource.clip = BoatEngine;
            StarboardSource.Play();

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
            }
        }
    }

    public void BoatThrottle()
    {
        PortSource.pitch = ShipMovement.accelPortInput + 0.65f;
        StarboardSource.pitch = ShipMovement.accelStarboardInput + 0.65f;


        //#region Forward Throttle
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    keyPressStartTime = Time.time;
        //    IsOn = true;
        //}

        //if (Input.GetKey(KeyCode.W))
        //{

        //    keyHoldDuration = Time.time - keyPressStartTime;
        //}

        //if (Input.GetKeyUp(KeyCode.W))
        //{
        //    keyPressStartTime = -1f;

        //    keyHoldDuration = 0f;

        //    IsOn = false;
        //}
        //#endregion

        //#region Reverse Throttle
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    keyPressStartTime = Time.time;
        //    IsOn = true;
        //}

        //if (Input.GetKey(KeyCode.S))
        //{

        //    keyHoldDuration = Time.time - keyPressStartTime;
        //}

        //if (Input.GetKeyUp(KeyCode.S))
        //{
        //    keyPressStartTime = -1f;

        //    keyHoldDuration = 0f;

        //    IsOn = false;
        //}
        //#endregion

        //if (IsOn == true)
        //{
        //    BoatRev = (keyHoldDuration / 10) + 0.5f;
        //}
        //else
        //{
        //    BoatRev -= 0.2f * Time.deltaTime;

        //    if (BoatRev <= 0.5f)
        //    {
        //        BoatRev = 0.5f;
        //    }
        //}

        //BoatSource.pitch = BoatRev;

        //if (BoatRev >= 1.4f)
        //{
        //    BoatSource.pitch = 1.4f;
        //}

        //Debug.Log(BoatRev);
    }
}

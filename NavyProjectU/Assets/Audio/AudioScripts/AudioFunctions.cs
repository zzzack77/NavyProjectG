using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

public class AudioFunctions : MonoBehaviour
{
    #region AudioSources
    public AudioSource audioSource;
    public AudioSource BoatAmbiences;
    public AudioSource WeatherAudio;
    public AudioSource GFAudio;
    public AudioSource APFAudio;
    public AudioSource RIFAudio;
    public AudioSource LFAudio;
    public AudioSource SFAudio;
    #endregion

    public AudioClip BoatEngine, Waves, Rain, Storm, Wind, GFail, APFail, RIFail, LFail, SFail, BoatAmbience;

    #region VolumesVars
    public float BoatEngineVolume;
    public float RainVolume;
    public float StormVolume;
    public float WaveVolume;
    #endregion

    #region WeatherVars
    public bool IsRaining;
    public bool IsStorming;

    public GameObject Weather;
    #endregion

    #region FaultAlarmsVars
    public GameObject GF;
    public bool Gyro;

    public GameObject APF;
    public bool AP;

    public GameObject RIF;
    public bool RI;

    public GameObject LF;
    public bool L;

    public GameObject SF;
    public bool S;
    #endregion

    #region RandomBoatAmbience
    public float t = 1f;
    public float RandomSound = 0f;
    public GameObject BA;
    #endregion

    public Transform SpawnLocation;

    public float pitch;

    private float Throttle;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = BoatEngine;
        audioSource.PlayOneShot(BoatEngine, BoatEngineVolume);
        audioSource.clip = Waves;
        audioSource.PlayOneShot(Waves, WaveVolume);

    }

    void Update()
    {
        Throttle = BoatEngineVolume;

        //Set it to rain
        if (Input.GetKeyDown(KeyCode.D))
        {
            Raining();
            IsRaining = true;
            IsStorming = false;
        }
 
        //Set it to storm
        if (Input.GetKeyDown(KeyCode.T))
        {
            Storming();
            IsStorming = true;
            IsRaining = false;
        }

        //Set it to calm
        if (Input.GetKeyDown(KeyCode.C))
        {
            Destroy(Weather);
        }

        //Gyro Failure
        if (Input.GetKeyDown(KeyCode.G))
        {
            GyroFailure();
            Gyro = false;
            
            if (Gyro == true)
            {
                Destroy(GF);
            }
        }

        //Autopilot Failure
        if (Input.GetKeyDown(KeyCode.A))
        {
            AutopilotFailure();
            AP = false;

            if (AP == true)
            {
                Destroy(APF);
            }
        }
        

        //Rudder Indicator Failure
        if (Input.GetKeyDown(KeyCode.R))
        {
            RudderIndicatorFailure();
            RI = false;

            if (RI == true)
            {
                Destroy(RIF);
            }
        }

        //Log Failure
        if (Input.GetKeyDown(KeyCode.L))
        {
            LogFailure();
            L = false;

            if (L == true)
            {
                Destroy(LF);
            }
        }

        //System Failure
        if (Input.GetKeyDown(KeyCode.S))
        {
            SystemFailure();
            S = false;

            if (S == true)
            {
                Destroy(SF);
            }
        }

        t = t * Time.deltaTime;

        if (t == 4)
        {
            AmbientShipSound();
        }
        else if (t == 6)
        {
            Destroy(BA);
        }

    }

    void Raining()
    {
        if (IsRaining == true)
        {
            Destroy(Weather);
        }

        Instantiate(Weather, transform.position = SpawnLocation.position, transform.rotation = SpawnLocation.rotation);

        Debug.Log("D");
        
        WeatherAudio = GetComponent<AudioSource>();

        WeatherAudio.clip = Rain;
        WeatherAudio.PlayOneShot(Rain, RainVolume);
    }

    void Storming()
    {
        if (IsRaining == true)
        {
            Destroy(Weather);
        }

        Instantiate(Weather, transform.position = SpawnLocation.position, transform.rotation = SpawnLocation.rotation);

        Debug.Log("T");

        WeatherAudio = GetComponent<AudioSource>();

        WeatherAudio.clip = Storm;
        WeatherAudio.PlayOneShot(Storm, StormVolume);
    }

    void GyroFailure()
    {
        Instantiate(GF, transform.position = SpawnLocation.position, transform.rotation = SpawnLocation.rotation);

        GFAudio = GetComponent<AudioSource>();

        GFAudio.clip = GFail;
        GFAudio.PlayOneShot(GFail, 0.5f);
    }

    void AutopilotFailure()
    {
        Instantiate(APF, transform.position = SpawnLocation.position, transform.rotation = SpawnLocation.rotation);

        APFAudio = GetComponent<AudioSource>();

        APFAudio.clip = APFail;
        APFAudio.PlayOneShot(APFail, 0.5f);
    }

    void RudderIndicatorFailure()
    {
        Instantiate(RIF, transform.position = SpawnLocation.position, transform.rotation = SpawnLocation.rotation);

        RIFAudio = GetComponent<AudioSource>();

        RIFAudio.clip = RIFail;
        RIFAudio.PlayOneShot(RIFail, 0.5f);
    }

    void LogFailure()
    {
        Instantiate(LF, transform.position = SpawnLocation.position, transform.rotation = SpawnLocation.rotation);

        LFAudio = GetComponent<AudioSource>();

        LFAudio.clip = LFail;
        LFAudio.PlayOneShot(LFail, 0.5f);
    }

    void SystemFailure()
    {
        Instantiate(SF, transform.position = SpawnLocation.position, transform.rotation = SpawnLocation.rotation);

        SFAudio = GetComponent<AudioSource>();

        SFAudio.clip = SFail;
        SFAudio.PlayOneShot(SFail, 0.5f);
    }

    void AmbientShipSound()
    {
        RandomSound = Random.Range(1, 10);

        if (RandomSound <= 5)
        {
                Instantiate(BA, transform.position = SpawnLocation.position, transform.rotation = SpawnLocation.rotation);

                BoatAmbiences = GetComponent<AudioSource>();

                BoatAmbiences.clip = BoatAmbience;
                BoatAmbiences.PlayOneShot(BoatAmbience, 0.5f);

            if (t == 6)
            {
                t = 1;
                Destroy(BA);
            }

        }
    }
}
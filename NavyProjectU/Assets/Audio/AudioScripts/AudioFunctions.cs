using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class AudioFunctions : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip BoatEngine, Waves, Rain, Storm, Wind, GFail, APFail, RIFail, LFail, SFail;

    #region VolumesVars
    public float BoatEngineVolume;
    public float RainVolume;
    public float StormVolume;
    public float WaveVolume;
    #endregion

    #region WeatherVars
    public bool IsRaining;
    public bool IsStorming;

    public GameObject Rainer;
    public GameObject Stormer;
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
            Destroy(Rainer);
            Destroy(Stormer);
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
    }

    void Raining()
    {
        if (IsRaining == true)
        {
            Destroy(Stormer);
        }

        Instantiate(Rainer, transform.position = SpawnLocation.position, transform.rotation = SpawnLocation.rotation);
        
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = Rain;
        audioSource.PlayOneShot(Rain, RainVolume);
    }

    void Storming()
    {
        if (IsRaining == true)
        {
            Destroy(Rainer);
        }

        Instantiate(Stormer, transform.position = SpawnLocation.position, transform.rotation = SpawnLocation.rotation);

        audioSource = GetComponent<AudioSource>();

        audioSource.clip = Storm;
        audioSource.PlayOneShot(Storm, StormVolume);
    }

    void GyroFailure()
    {
        Instantiate(GF, transform.position = SpawnLocation.position, transform.rotation = SpawnLocation.rotation);

        audioSource = GetComponent<AudioSource>();

        audioSource.clip = GFail;
        audioSource.PlayOneShot(GFail, 0.5f);
    }

    void AutopilotFailure()
    {
        Instantiate(APF, transform.position = SpawnLocation.position, transform.rotation = SpawnLocation.rotation);

        audioSource = GetComponent<AudioSource>();

        audioSource.clip = APFail;
        audioSource.PlayOneShot(APFail, 0.5f);
    }

    void RudderIndicatorFailure()
    {
        Instantiate(RIF, transform.position = SpawnLocation.position, transform.rotation = SpawnLocation.rotation);

        audioSource = GetComponent<AudioSource>();

        audioSource.clip = RIFail;
        audioSource.PlayOneShot(RIFail, 0.5f);
    }

    void LogFailure()
    {
        Instantiate(LF, transform.position = SpawnLocation.position, transform.rotation = SpawnLocation.rotation);

        audioSource = GetComponent<AudioSource>();

        audioSource.clip = LFail;
        audioSource.PlayOneShot(LFail, 0.5f);
    }

    void SystemFailure()
    {
        Instantiate(SF, transform.position = SpawnLocation.position, transform.rotation = SpawnLocation.rotation);

        audioSource = GetComponent<AudioSource>();

        audioSource.clip = SFail;
        audioSource.PlayOneShot(SFail, 0.5f);
    }
}
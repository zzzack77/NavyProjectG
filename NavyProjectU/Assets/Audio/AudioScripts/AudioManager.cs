using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class AudioManager : MonoBehaviour
{
    public AudioSource BoatSource;
    public AudioClip BoatIdle, Horn;

    public float keyPressStartTime = -1f;  
    public float keyHoldDuration;     
    public float BoatRev;

    public bool IsOn;

    void Start()
    {
        BoatIdling();

        IsOn = true;
    }


    void BoatIdling()
    {
        BoatSource = GetComponent<AudioSource>();
        BoatSource.clip = BoatIdle;
        BoatSource.Play();
    }

    
    void Update()
    {
        BoatHorn();
        BoatThrottle();
    }
    
    public void BoatHorn()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            BoatSource.PlayOneShot(Horn);
        }
    }

    public void BoatThrottle()
    {
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

            keyHoldDuration = BoatRev;

            IsOn = false;

        }

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

            keyHoldDuration = BoatRev;

            IsOn = false;

        }

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

        Debug.Log(BoatRev);
    }
}

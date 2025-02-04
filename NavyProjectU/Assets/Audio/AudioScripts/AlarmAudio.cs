using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AlarmAudio : MonoBehaviour
{
    public AudioSource AlarmSource;
    public AudioClip FaultAlarm;

    void Start()
    {
        AlarmSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        Alarm();
    }

    public void Alarm()
    {
        if (Input.GetKey(KeyCode.F))
        {

            AlarmSource.clip = FaultAlarm;
            AlarmSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            AlarmSource.Stop();
        }
    }
}

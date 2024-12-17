using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveAudio : MonoBehaviour
{

    public AudioSource WaveSource;
    public AudioClip Waves;

    void Start()
    {
        Wavey();
    }

    void Wavey()
    {
        WaveSource = GetComponent<AudioSource>();
        WaveSource.clip = Waves;
        WaveSource.Play();
    }
}

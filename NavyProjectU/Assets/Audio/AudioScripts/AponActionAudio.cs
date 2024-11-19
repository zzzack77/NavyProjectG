using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AponActionAudio : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip clips;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.clip = clips;
            audioSource.Play();
        }
    }
}

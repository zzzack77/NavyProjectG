using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AponActionAudio : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip clip1, clip2 ;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.clip = clip1;
            audioSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            audioSource.clip = clip2;
            audioSource.Play();
        }
    }
}

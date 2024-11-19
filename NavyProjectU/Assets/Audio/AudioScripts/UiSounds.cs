using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiSounds : MonoBehaviour
{
    public AudioSource UIAudios;
    public AudioClip sfx1, sfx2, sfx3;

    public void Button1()
    {
        UIAudios.clip = sfx1;
        UIAudios.Play();

        //Repeat for different buttons
    }
}

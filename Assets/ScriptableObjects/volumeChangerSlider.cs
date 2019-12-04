using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class volumeChangerSlider : MonoBehaviour
{
    private AudioSource audioSrc;
    private float musicVolume = 1.0f;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        audioSrc.volume = musicVolume;
    }

    public void setVolume(float vol)
    {
        musicVolume = vol;
    }
}

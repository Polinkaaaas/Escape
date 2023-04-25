using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Music : MonoBehaviour
{
    public AudioClip musicClip;
    private AudioSource musicSource;

    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        musicSource.clip = musicClip;
        musicSource.Play();
    }
}

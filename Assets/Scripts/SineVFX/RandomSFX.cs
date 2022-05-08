using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RandomSFX : MonoBehaviour
{

    public AudioClip[] clips;
    private AudioSource asource;

    void Start()
    {
        asource = GetComponent<AudioSource>();
        asource.clip = clips[Random.Range(0, clips.Length)];
        asource.Play();
        asource.pitch = Random.Range(0.9f, 1.1f);
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f,1f)]
    public float volume = 0.5f;
    [Range(-1f, 3f)]
    public float pitch = 1f;
    public bool loop = false;
    [HideInInspector]
    public AudioSource source;
}

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if(instance == null) {
            instance = this;
		} else {
            Destroy(gameObject);
            return;
		}

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
		}
    }

	public void Play (string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null) {
            Debug.LogWarning("Sound: " + name + " was not found!");
            return;
		}
        s.source.Play();
	}
    public void Play (string name, bool randomPitch) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound: " + name + " was not found!");
            return;
        }
		if (randomPitch) {
            float variance = UnityEngine.Random.Range(-0.1f, 0.1f);
            s.source.pitch = s.pitch;
            s.source.pitch += variance;
		}
        s.source.Play();
    }

    public void Stop (string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound: " + name + " was not found!");
            return;
        }
        s.source.Stop();
    }

    public void PlayPhaseMusic (RoundController.Phase phase) {
		switch (phase) {
			case RoundController.Phase.PlayerVanguard:
            /*
            FadeInSound("NAME");
            FadeOutSound("NAME");
            */
            break;
			case RoundController.Phase.EnemyVangaurd:
            /*
            FadeInSound("NAME");
            FadeOutSound("NAME");
            */
            break;
			case RoundController.Phase.PlayerSwap:
            /*
            FadeInSound("NAME");
            FadeOutSound("NAME");
            */
            break;
			case RoundController.Phase.EnemySwap:
            /*
            FadeInSound("NAME");
            FadeOutSound("NAME");
            */
            break;
			case RoundController.Phase.PlayerSupport:
            /*
            FadeInSound("NAME");
            FadeOutSound("NAME");
            */
            break;
			case RoundController.Phase.EnemySupport:
            /*
            FadeInSound("NAME");
            FadeOutSound("NAME");
            */
            break;
			case RoundController.Phase.NextPhase:
            /*
            FadeInSound("NAME");
            FadeOutSound("NAME");
            */
            break;
			default:
			break;
		}
	}

    void FadeInSound (string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound: " + name + " was not found!");
            return;
        }
        StartCoroutine(FadeIn(s));
    }

    void FadeOutSound (string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound: " + name + " was not found!");
            return;
        }
        StartCoroutine(FadeOut(s));
    }

    IEnumerator FadeOut (Sound s) {
        float volume = s.source.volume;
		while (volume >= 0) {
            volume -= Time.deltaTime;
            s.source.volume = volume;
            yield return 0;
		}
	}

    IEnumerator FadeIn (Sound s) {
        float volume = 0;
        while (volume <= s.volume) {
            volume += Time.deltaTime;
            s.source.volume = volume;
            yield return 0;
        }
    }
}

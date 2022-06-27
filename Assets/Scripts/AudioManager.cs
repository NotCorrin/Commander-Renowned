using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

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

public class AudioManager : Listener
{
    public static AudioManager instance;

    /// <summary>
    /// An array of sounds for the AudioManager.
    /// </summary>
    public Sound[] sounds;
    private string currentMusic;
    private bool isBattleMusic = true;

    protected override void SubscribeListeners()
    {
        GameEvents.onPhaseChanged += PlayPhaseMusic;
        SceneManager.sceneLoaded += CheckScene;
    }

    protected override void UnsubscribeListeners()
    {
        GameEvents.onPhaseChanged -= PlayPhaseMusic;
        SceneManager.sceneLoaded -= CheckScene;
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " was not found!");
            return;
        }

        s.source.Play();
    }

    public void PlayZeroVolume(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " was not found!");
            return;
        }

        s.source.volume = 0f;
        s.source.Play();
    }

    public void Play(string name, bool randomPitch)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " was not found!");
            return;
        }

        if (randomPitch)
        {
            float variance = UnityEngine.Random.Range(-0.1f, 0.1f);
            s.source.pitch = s.pitch;
            s.source.pitch += variance;
        }

        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " was not found!");
            return;
        }

        s.source.Stop();
    }

    public void PlayPhaseMusic(RoundController.Phase phase)
    {
        switch (phase)
        {
            case RoundController.Phase.PlayerVanguard:
                FadeInSound($"{currentMusic}V");
                FadeOutSound($"{currentMusic}S");
                break;
            case RoundController.Phase.PlayerSwap:
                FadeInSound($"{currentMusic}S");
                FadeOutSound($"{currentMusic}V");
                break;
            default:
                break;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void StopAll()
    {
        foreach (Sound s in sounds)
        {
            if (s.name != "Swoosh")
            {
                s.source.Stop();
            }
        }
    }

    private void CheckScene(Scene scene, LoadSceneMode mode)
    {
        int currentSceneIndex = scene.buildIndex;
        isBattleMusic = true;
        bool shouldStopMusic = true;

        if (currentSceneIndex != (int)SceneIndex.MenuSelectionScene)
        {
            StopAll();
        }

        switch (currentSceneIndex)
        {
            case (int)SceneIndex.TerrainTestScene:
                currentMusic = "TrackOne";
                break;
            case (int)SceneIndex.BattleSceneTwo:
                currentMusic = "TrackTwo";
                break;
            case (int)SceneIndex.BattleSceneThree:
                currentMusic = "TrackThree";
                break;
            case (int)SceneIndex.StartMenuScene:
                currentMusic = "MainMenu";
                isBattleMusic = false;
                break;
            case (int)SceneIndex.StoryScene:
                currentMusic = "Story";
                isBattleMusic = false;
                break;
            case (int)SceneIndex.AddMenuScene:
                currentMusic = "Story";
                isBattleMusic = false;
                break;
            case (int)SceneIndex.MenuSelectionScene:
                currentMusic = "Story";
                isBattleMusic = false;
                shouldStopMusic = false;
                break;
            default:
                isBattleMusic = false;
                break;
        }

        if (isBattleMusic)
        {
            PlayZeroVolume($"{currentMusic}S");
            PlayZeroVolume($"{currentMusic}V");
        }
        else if (shouldStopMusic)
        {
            Play($"{currentMusic}");
        }
    }

    private void FadeInSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " was not found!");
            return;
        }

        if (s.source.volume > 0)
        {
            return;
        }

        StartCoroutine(FadeIn(s));
    }

    private void FadeOutSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " was not found!");
            return;
        }

        if (s.source.volume <= 0)
        {
            return;
        }

        StartCoroutine(FadeOut(s));
    }

    private IEnumerator FadeOut(Sound s)
    {
        float volume = s.source.volume;
        while (volume >= 0)
        {
            volume -= (Time.deltaTime * s.volume) * 0.5f;
            s.source.volume = volume;
            yield return 0;
        }
    }

    private IEnumerator FadeOutFast(Sound s)
    {
        float volume = s.source.volume;
        while (volume >= 0)
        {
            volume -= (Time.deltaTime * s.volume) * 15f;
            s.source.volume = volume;
            yield return 0;
        }
    }

    private IEnumerator FadeIn(Sound s)
    {
        float volume = 0;
        while (volume <= s.volume)
        {
            volume += (Time.deltaTime * s.volume) * 0.5f;
            s.source.volume = volume;
            yield return 0;
        }
    }
}

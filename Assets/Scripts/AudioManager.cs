using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

/// <summary>
/// This class is used to manage the audio in the game.
/// It will be used as a singleton to ensure that there is only one instance of the audio manager.
/// </summary>
public class AudioManager : Listener
{
    private static AudioManager instance;

    /// <summary>
    /// An array of sounds for the AudioManager.
    /// </summary>
    [SerializeField] private Sound[] sounds;
    private string currentMusic;
    private bool isBattleMusic = true;

    /// <summary>
    /// Gets the AudioManager instance.
    /// </summary>
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<AudioManager>();
            }

            return instance;
        }
    }

    /// <summary>
    /// Plays a sound.
    /// </summary>
    /// <param name="name">The name of the sound to play.</param>
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " was not found!");
            return;
        }

        s.Source.Play();
    }

    /// <summary>
    /// Plays a sound with zero volume.
    /// </summary>
    /// <param name="name">The name of the sound to play.</param>
    public void PlayZeroVolume(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " was not found!");
            return;
        }

        s.Source.volume = 0f;
        s.Source.Play();
    }

    /// <summary>
    /// Plays a sound with a random pitch.
    /// </summary>
    /// <param name="name">The name of the sound to play.</param>
    /// <param name="randomPitch">Should play a random pitch.</param>
    public void Play(string name, bool randomPitch)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " was not found!");
            return;
        }

        if (randomPitch)
        {
            float variance = UnityEngine.Random.Range(-0.1f, 0.1f);
            s.Source.pitch = s.Pitch;
            s.Source.pitch += variance;
        }

        s.Source.Play();
    }

    /// <summary>
    /// Stops a sound.
    /// </summary>
    /// <param name="name">The name of the sound to stop.</param>
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " was not found!");
            return;
        }

        s.Source.Stop();
    }

    /// <summary>
    /// A method to play the battle music.
    /// </summary>
    /// <param name="phase">The current phase.</param>
    public void PlayPhaseMusic(RoundController.PhaseType phase)
    {
        switch (phase)
        {
            case RoundController.PhaseType.PlayerVanguard:
                FadeInSound($"{currentMusic}V");
                FadeOutSound($"{currentMusic}S");
                break;
            case RoundController.PhaseType.PlayerSwap:
                FadeInSound($"{currentMusic}S");
                FadeOutSound($"{currentMusic}V");
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Subscribe to events in AudioManager.
    /// </summary>
    protected override void SubscribeListeners()
    {
        GameEvents.onPhaseChanged += PlayPhaseMusic;
        SceneManager.sceneLoaded += CheckScene;
    }

    /// <summary>
    /// Unsubscribe from events in AudioManager.
    /// </summary>
    protected override void UnsubscribeListeners()
    {
        GameEvents.onPhaseChanged -= PlayPhaseMusic;
        SceneManager.sceneLoaded -= CheckScene;
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
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.Clip;
            s.Source.volume = s.Volume;
            s.Source.pitch = s.Pitch;
            s.Source.loop = s.Loop;
        }
    }

    private void StopAll()
    {
        foreach (Sound s in sounds)
        {
            if (s.Name != "Swoosh")
            {
                s.Source.Stop();
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
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " was not found!");
            return;
        }

        if (s.Source.volume > 0)
        {
            return;
        }

        StartCoroutine(FadeIn(s));
    }

    private void FadeOutSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " was not found!");
            return;
        }

        if (s.Source.volume <= 0)
        {
            return;
        }

        StartCoroutine(FadeOut(s));
    }

    private IEnumerator FadeOut(Sound s)
    {
        float volume = s.Source.volume;
        while (volume >= 0)
        {
            volume -= (Time.deltaTime * s.Volume) * 0.5f;
            s.Source.volume = volume;
            yield return 0;
        }
    }

    private IEnumerator FadeOutFast(Sound s)
    {
        float volume = s.Source.volume;
        while (volume >= 0)
        {
            volume -= (Time.deltaTime * s.Volume) * 15f;
            s.Source.volume = volume;
            yield return 0;
        }
    }

    private IEnumerator FadeIn(Sound s)
    {
        float volume = 0;
        while (volume <= s.Volume)
        {
            volume += (Time.deltaTime * s.Volume) * 0.5f;
            s.Source.volume = volume;
            yield return 0;
        }
    }

    [Serializable] private class Sound
    {
        [SerializeField] private string name;
        [SerializeField] private AudioClip clip;
        [Range(0f, 1f)]
        [SerializeField] private float volume = 0.5f;
        [Range(-1f, 3f)]
        [SerializeField] private float pitch = 1f;
        [SerializeField] private bool loop = false;
        private AudioSource source;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public AudioClip Clip
        {
            get { return clip; }
            set { clip = value; }
        }

        public float Volume
        {
            get { return volume; }
            set { volume = value; }
        }

        public float Pitch
        {
            get { return pitch; }
            set { pitch = value; }
        }

        public bool Loop
        {
            get { return loop; }
            set { loop = value; }
        }

        public AudioSource Source
        {
            get { return source; }
            set { source = value; }
        }
    }
}

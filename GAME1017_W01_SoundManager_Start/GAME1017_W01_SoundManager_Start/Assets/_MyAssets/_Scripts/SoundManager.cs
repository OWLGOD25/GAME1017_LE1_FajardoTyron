using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public enum SoundType
    {
        SOUND_SFX,
        SOUND_MUSIC
    }

    public static SoundManager Instance { get; private set; } // Singleton instance of SoundManager.

    // Create Dictionary for sfx.
    private Dictionary<string, AudioClip> sfxDictionary = new Dictionary<string, AudioClip>();
    // Create Dictionary for music.
    private Dictionary<string, AudioClip> musicDictionary = new Dictionary<string, AudioClip>();
    // Create AudioSource for sfx.
    private AudioSource sfxSource;
    // Create AudioSource for music.
    private AudioSource musicAudioSource;

    public void Awake()
    {
        // Check if an instance of SoundManager already exists.
        if (Instance == null)
        {
            Instance = this; // Set the instance to this object.
            Initialize(); // Initialize the SoundManager.
            DontDestroyOnLoad(gameObject); // Prevent this object from being destroyed on scene load.
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances.
        }
    }


    // Initialize the SoundManager. I just put this functionality here instead of in the static constructor.
    private void Initialize()
    {
        // Create a new GameObject to hold the AudioSource
        GameObject soundManagerObject = new GameObject("SoundManager");
        sfxSource = soundManagerObject.AddComponent<AudioSource>();
        sfxSource.volume = 1.0f; // Set the volume for SFX

        // Fill in for lab.
        musicAudioSource = soundManagerObject.AddComponent<AudioSource>();
        musicAudioSource.volume = 0.5f; // Set the volume for Music
        musicAudioSource.loop = true; // Set the music source to loop
    }

    // Add a sound to the dictionary.
    public void AddSound(string soundKey, AudioClip audioClip, SoundType soundType)
    {
        // Fill in for lab.
        Dictionary<string, AudioClip> targetDictionary = GetDictionaryByType(soundType);

        if (!targetDictionary.ContainsKey(soundKey))
        {
            targetDictionary.Add(soundKey, audioClip);
        }
        else
        {
            Debug.LogWarning($"Sound with key {soundKey} already exists in {soundType}.");
        }
    }

    // Play a sound by key interface.
    public void PlaySound(string soundKey)
    {
        // Fill in for lab.
        Play(soundKey, SoundType.SOUND_SFX);
    }

    // Play music by key interface.
    public void PlayMusic(string soundKey)
    {
        // Fill in for lab.
        musicAudioSource.Stop();
        Play(soundKey, SoundType.SOUND_MUSIC);
    }

    // Play utility.
    private void Play(string soundKey, SoundType soundType)
    {
        // Fill in for lab.
        Dictionary<string, AudioClip> targetDictionary;
        AudioSource targetSource;
        SetTargetsByType(soundType, out targetDictionary, out targetSource);
        if (targetDictionary.ContainsKey(soundKey))
        { 
            targetSource.PlayOneShot(targetDictionary[soundKey]);
        }
        else
        {
            Debug.LogWarning($"Sound with key {soundKey} not found in {soundType}.");
        }

    }

    private void SetTargetsByType(SoundType soundType, out Dictionary<string, AudioClip> targetDictionary, out AudioSource targetSource)
    {
        // Fill in for lab.
        switch (soundType)
        { 
        case SoundType.SOUND_SFX:
                targetDictionary = sfxDictionary;
                targetSource = sfxSource;
                break;
            case SoundType.SOUND_MUSIC:
                targetDictionary = musicDictionary;
                targetSource = musicAudioSource;
                break;
            default:
                Debug.LogError($"unknown sound type {soundType}");
                targetDictionary = null;
                targetSource = null;
                break;
        }
    }
    private Dictionary<string, AudioClip> GetDictionaryByType(SoundType soundType)
    {
        // Fill in for lab.
        switch(soundType)
        {
            case SoundType.SOUND_SFX:
                return sfxDictionary;
            case SoundType.SOUND_MUSIC:
                return musicDictionary;
            default:
                Debug.LogError($"unknown sound type {soundType}");
                return null;
        }
    }
        private float Mastersounds = 1.0f;
    private float Sfxsounds = 1.0f; 
    private float MusicSounds = 1.0f; 

  public void SetMastersounds(float volume)
    {
        Mastersounds = Mathf.Clamp01(volume);
        UpdateVolumes();
    }

    public void SetSfxsounds(float volume)
    {
        Sfxsounds = Mathf.Clamp01(volume);
        UpdateVolumes();
    }

    public void SetMusicSounds(float volume)
    {
        MusicSounds = Mathf.Clamp01(volume);
        UpdateVolumes();
    }

    private void UpdateVolumes()
    {
        if (sfxSource != null)
            sfxSource.volume = Sfxsounds * Mastersounds;
        if (musicAudioSource != null)
            musicAudioSource.volume = Mastersounds * Mastersounds;
    }

    public void StereoPanning(float pan)
    {
        float clampedPan = Mathf.Clamp(pan, -1f, 1f);
        if (sfxSource != null)
            sfxSource.panStereo = clampedPan;
        if (musicAudioSource != null)
            musicAudioSource.panStereo = clampedPan;
    }
}
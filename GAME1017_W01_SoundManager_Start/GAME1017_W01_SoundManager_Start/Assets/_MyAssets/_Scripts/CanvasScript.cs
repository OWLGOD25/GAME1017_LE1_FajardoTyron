using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasScript : MonoBehaviour
{
    void Start()
    {
        // Fill in for lab. Add all sounds to SoundManager.
        SoundManager.Instance.AddSound("Boom", Resources.Load<AudioClip>("Boom"),SoundManager.SoundType.SOUND_SFX);
        SoundManager.Instance.AddSound("Death", Resources.Load<AudioClip>("Death"), SoundManager.SoundType.SOUND_SFX);
        SoundManager.Instance.AddSound("jump", Resources.Load<AudioClip>("jump"), SoundManager.SoundType.SOUND_SFX);
        SoundManager.Instance.AddSound("Lazer", Resources.Load<AudioClip>("Laser"), SoundManager.SoundType.SOUND_SFX);
        SoundManager.Instance.AddSound("TCats", Resources.Load<AudioClip>("Thundercats"), SoundManager.SoundType.SOUND_MUSIC);
        SoundManager.Instance.AddSound("TMNT", Resources.Load<AudioClip>("Turtles"), SoundManager.SoundType.SOUND_MUSIC);
        SoundManager.Instance.AddSound("MASK", Resources.Load<AudioClip>("MASK"), SoundManager.SoundType.SOUND_MUSIC);
    }

    public void PlaySFX(string soundKey)
    {
        SoundManager.Instance.PlaySound(soundKey);
    }

    public void PlayMusic(string soundKey)
    {
        SoundManager.Instance.PlayMusic(soundKey);
    }

    public void SetMastersound (float Value)
    {
        SoundManager.Instance.SetMastersounds(Value);
    }

    public void SetSfxsounds (float Value)
    {
        SoundManager.Instance.SetSfxsounds(Value);
    }
    public void SetMusicSounds (float Value)
    {
        SoundManager.Instance.SetMusicSounds(Value);
    }
    public void StereoPanning(float Value)
    {
        SoundManager.Instance.StereoPanning(Value);
    }
}

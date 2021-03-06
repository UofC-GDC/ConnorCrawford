﻿using UnityEngine;
using UnityEngine.Audio;

public class VolumeLeveler : MonoBehaviour {
    [SerializeField] AudioMixer masterMixer;

    public void SetMusicLvl(float musicLvl)
    {
        masterMixer.SetFloat("MusicVolume", musicLvl);
    }

    public void SetSfxLvl(float sfxLvl)
    {
        masterMixer.SetFloat("SoundEffectsVolume", sfxLvl);
    }
}

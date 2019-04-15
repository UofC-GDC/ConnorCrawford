using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager> 
{
    [Header("AudioMixers")]
    [SerializeField] private AudioMixerSnapshot mainThemeDay;
    [SerializeField] private AudioMixerSnapshot mainThemeNight;
    [SerializeField] private AudioMixerSnapshot starTheme;
    [SerializeField] private AudioMixerSnapshot timeTravelTheme;
    [Header("AudioSources")]
    [SerializeField] private AudioSource starThemeSource;
    [SerializeField] private AudioSource timeTravelThemeSource;
    [SerializeField] private AudioSource credits;

    [SerializeField] public float transitionTime = 5f;

    [ContextMenu("MainThemeDay")]
    public void MainThemeDay()
    {
        mainThemeDay.TransitionTo(transitionTime);
    }

    [ContextMenu("MainThemeNight")]
    public void MainThemeNight()
    {
        mainThemeNight.TransitionTo(transitionTime);
    }

    [ContextMenu("StarTheme")]
    public void StarTheme()
    {
        starTheme.TransitionTo(transitionTime);
        if(!starThemeSource.isPlaying)
            starThemeSource.PlayDelayed(transitionTime/2);
    }

    [ContextMenu("TimeTravelTheme")]
    public void TimeTravelTheme()

    {
        timeTravelTheme.TransitionTo(transitionTime);
        if (!timeTravelThemeSource.isPlaying)
            timeTravelThemeSource.PlayDelayed(transitionTime / 2);
    }

    [ContextMenu("Credits")]
    public void Credits()
    {
        starTheme.TransitionTo(transitionTime);
        credits.PlayDelayed(transitionTime / 2);
    }
}

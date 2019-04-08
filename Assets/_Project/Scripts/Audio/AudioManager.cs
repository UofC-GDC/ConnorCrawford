using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager> 
{
    [SerializeField] private AudioMixerSnapshot mainThemeDay;
    [SerializeField] private AudioMixerSnapshot mainThemeNight;
    [SerializeField] private AudioMixerSnapshot starTheme;
    [SerializeField] private AudioMixerSnapshot timeTravelTheme;

    [SerializeField] private float transitionTime = 5f;

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
    }

    [ContextMenu("TimeTravelTheme")]
    public void TimeTravelTheme()
    {
        timeTravelTheme.TransitionTo(transitionTime);
    }
}

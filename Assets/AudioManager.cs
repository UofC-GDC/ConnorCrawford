using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager> 
{
    [SerializeField] private AudioMixerSnapshot mainTheme;
    [SerializeField] private AudioMixerSnapshot starTheme;
    [SerializeField] private AudioMixerSnapshot timeTravelTheme;

    [SerializeField] private float transitionTime = 5f;

    [ContextMenu("MainTheme")]
    public void MainTheme()
    {
        mainTheme.TransitionTo(transitionTime);
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

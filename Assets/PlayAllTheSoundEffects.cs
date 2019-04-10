using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAllTheSoundEffects : Thing 
{
    [SerializeField] private List<AudioSource> soundEffects;
    [SerializeField] private OutroCutscene outroCutscene;

    private int i = 0;
    private bool start = false;

    public override State Action(StateManager.Env env, ref Player player)
    {
        if (i < soundEffects.Count)
        {
            if (!soundEffects[i].isPlaying && !start)
            {
                soundEffects[i].Play();
                start = true;
                return new DoInteractionState();
            }
            else if (!soundEffects[i].isPlaying && start)
            {
                i++;
                start = false;
                return new DoInteractionState();
            }

            return new DoInteractionState();
        }
        else
        {
            i = 0;
            start = false;
            outroCutscene.doneSounds = true;
            return outroCutscene.Action(env, ref player);
        }
    }
}

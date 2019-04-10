using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroCutscene : Thing
{
    [SerializeField] private Animator fadeInOutPanelAnimator;
    [SerializeField] private Animator connerAnimator;
    [SerializeField] private PlayAllTheSoundEffects playAllTheSoundEffeccts;

    private bool letsGo = false;
    private bool allDone = false;

    public bool doneSounds = false;

    public override State Action(StateManager.Env env, ref Player player)
    {
        if (!letsGo && !allDone)
        { 
            StartCoroutine(action());
            return new DoInteractionState();
        }
        else if (letsGo)
        {
            if (donePart1 && !leggo2 && !doneSounds)
            {
                return playAllTheSoundEffeccts.Action(env, ref player);
            }
            else if (doneSounds && !leggo2)
            {
                StartCoroutine(actionPart2());
            }
            else if (leggo2)
            {
                return new DoInteractionState();
            }
            return new DoInteractionState();
        }
        else
            return null;
    }

    private bool donePart1 = false;

    private IEnumerator action()
    {
        letsGo = true;

        connerAnimator.SetBool("Cutscene", true);
        connerAnimator.SetTrigger("FadeOut");

        while (!connerAnimator.GetCurrentAnimatorStateInfo(0).IsName("FadedOut"))
        {
            yield return null;
        }

        fadeInOutPanelAnimator.SetTrigger("FadeToBlack");

        while (!fadeInOutPanelAnimator.GetCurrentAnimatorStateInfo(0).IsName("Black"))
        {
            yield return null;
        }

        donePart1 = true;
    }

    private bool leggo2 = false;

    private IEnumerator actionPart2()
    {
        leggo2 = true;
        //Remove objects or change scene or whatever.

        fadeInOutPanelAnimator.SetTrigger("FadeFromBlack");

        while (!fadeInOutPanelAnimator.GetCurrentAnimatorStateInfo(0).IsName("Transparent"))
        {
            yield return null;
        }

        connerAnimator.SetTrigger("FadeIn");

        while (!connerAnimator.GetCurrentAnimatorStateInfo(0).IsName("IdleSouth"))
        {
            yield return null;
        }

        letsGo = false;
        allDone = true;
        yield break;
    }
}

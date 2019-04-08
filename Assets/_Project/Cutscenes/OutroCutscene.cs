using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroCutscene : Thing
{
    [SerializeField] private Animator fadeInOutPanelAnimator;

    private bool letsGo = false;
    private bool allDone = false;

    public override State Action(StateManager.Env env, ref Player player)
    {
        if (!letsGo && !allDone)
        { 
            StartCoroutine(action());
            return new DoInteractionState();
        }
        else if (letsGo)
            return new DoInteractionState();
        else
            return null;
    }

    private IEnumerator action()
    {
        letsGo = true;
        //Fade out Conner
        fadeInOutPanelAnimator.SetTrigger("FadeToBlack");

        while (!fadeInOutPanelAnimator.GetCurrentAnimatorStateInfo(0).IsName("Black"))
        {
            yield return null;
        }

        //Play all the sounds
        //Remove objects or change scene or whatever.
        fadeInOutPanelAnimator.SetTrigger("FadeFromBlack");

        while (!fadeInOutPanelAnimator.GetCurrentAnimatorStateInfo(0).IsName("Transparent"))
        {
            yield return null;
        }

        //Fade in Conner

        letsGo = false;
        allDone = true;
        yield break;
    }
}

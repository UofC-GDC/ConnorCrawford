using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeItFadeOut : MakeItFadeIn 
{
    public override State Action(StateManager.Env env, ref Player player)
    {
        fadeInOutPanelAnimator.SetTrigger("FadeToBlack");

        return null;
    }
}

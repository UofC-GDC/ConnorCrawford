using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeItFadeIn : Thing
{
    [SerializeField] protected Animator fadeInOutPanelAnimator;

    public override State Action(StateManager.Env env, ref Player player)
    {
        fadeInOutPanelAnimator.SetTrigger("FadeFromBlack");
          
        return null;
    }

    [HideInInspector] public bool black;

    private void Update()
    {
        if (fadeInOutPanelAnimator.GetCurrentAnimatorStateInfo(0).IsName("Black"))
        {
            black = true;
        }
        else
        {
            black = false;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeItFadeIn : Thing
{
    [SerializeField] protected Animator fadeInOutPanelAnimator;

    protected bool start = false;

    public override State Action(StateManager.Env env, ref Player player)
    {
        if (!start)
        {
            start = true;
            fadeInOutPanelAnimator.SetTrigger("FadeFromBlack");
            return new DoInteractionState();
        }
        else
        {
            if (black) return new DoInteractionState();
            else
            {
                start = false;
                return null;
            }
        }
    }

    [HideInInspector] public bool black;

    protected virtual void Update()
    {
        if (fadeInOutPanelAnimator.GetCurrentAnimatorStateInfo(0).IsName("Transparent"))
        {
            black = false;
        }
        else
        {
            black = true;
        }
    }
}
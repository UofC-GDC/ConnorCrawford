using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : Thing 
{
    private bool rooollllllCredits = false;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override State Action(StateManager.Env env, ref Player player)
    {
        if (!rooollllllCredits)
        {
            rooollllllCredits = true;
            animator.SetTrigger("Credits");
            return new DoInteractionState();
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Null"))
        {
            PauseMenu.Instance.Quit();
            return null;
        }
        else
            return new DoInteractionState();
    }
}

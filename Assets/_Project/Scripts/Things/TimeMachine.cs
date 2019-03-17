using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMachine : Thing
{
    private bool open = false;
    private bool unlocked = false;
    [SerializeField] private Animator lidAnimator;
    [SerializeField] private Animator steamAnimator;
    [SerializeField] private GameObject manual;

    private float heldTime = 0f;

    public override State Action(StateManager.Env env, ref Player player)
    {
        if (!open)
        {
            lidAnimator.SetTrigger("Open");
            steamAnimator.SetTrigger("Steam");
            manual.SetActive(true);
            open = true;
        }
        else if (!unlocked)
        {
            if (heldTime >= 3f && heldTime <= 4f && !Input.GetMouseButtonDown(1))
            {
                //Unlock Time Machine
                unlocked = true;
            }
            else if (Input.GetMouseButtonDown(1))
            {
                heldTime += Time.deltaTime;
                return new DoInteractionState();
            }
            else
            {
                heldTime = 0;
            }
        }
        else
        {
            //Open Star puzzle
        }

        return base.Action(env, ref player);
    }
}

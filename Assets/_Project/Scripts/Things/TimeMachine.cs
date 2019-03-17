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
            StartCoroutine(BookTurnOn());
            return null;
        }
        else if (!unlocked)
        {
            if (heldTime >= 3f && heldTime <= 4f && !Input.GetMouseButtonDown(1))
            {
                //Unlock Time Machine
                unlocked = true;
                return null;
            }
            else if (Input.GetMouseButtonDown(1))
            {
                heldTime += Time.deltaTime;
                return new DoInteractionState();
            }
            else
            {
                heldTime = 0;
                return base.Action(env, ref player);
            }
        }
        else
        {
            //Open Star puzzle
            return null;
        }
    }

    private IEnumerator BookTurnOn()
    {
        while (!lidAnimator.GetCurrentAnimatorStateInfo(0).IsName("TimeMachineOpened"))
        {
            yield return null;
        }

        manual.SetActive(true);
        open = true;
        yield break;
    }
}

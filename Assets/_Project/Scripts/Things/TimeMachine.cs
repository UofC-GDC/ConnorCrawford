using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMachine : Thing
{
    private bool open = false;
    private bool unlocked = false;
    public bool readyToTimeTravel = false;
    [SerializeField] private Animator lidAnimator;
    [SerializeField] private Animator steamAnimator;
    [SerializeField] private GameObject manual;

    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject starPuzzle;
    [SerializeField] private Animator fadeInOutPanelAnimator;

    private float heldTime = 0f;

    public override State Action(StateManager.Env env, ref Player player)
    {
        print(env);
        print(Input.GetMouseButton(1));
        if (!open)
        {
            lidAnimator.SetTrigger("Open");
            steamAnimator.SetTrigger("Steam");
            StartCoroutine(BookTurnOn());
            return null;
        }
        else if (!unlocked)
        {
            //unlocked = true;
            //return null;
            if (heldTime >= 3f && heldTime <= 4f && !Input.GetMouseButton(1))
            {
                //Unlock Time Machine
                Debug.Log("TIME MACHINE UNLOCKED!");
                unlocked = true;
                return null;
            }
            else if (Input.GetMouseButton(1))
            {
                heldTime += Time.deltaTime;
                return new DoInteractionState();
            }
            else
            {
                heldTime = 0;
                return base.Action(env, ref player);
                //return new DoInteractionState();
            }
        }
        else if (readyToTimeTravel)
        {
            print("TRAVELING THROUGH TIME!!!");
            return null;
        }
        else
        {
            StarExitButton.Instance.ActivateStarPuzzle();
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

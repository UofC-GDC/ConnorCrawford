using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerBox : Thing3d
{
    [SerializeField] private Animator animator;
    [SerializeField] private Collider2D colliderClosed;
    [SerializeField] private Collider2D colliderOpen;
    [SerializeField] private GameObject breakerBoxDoor;

    [Header("Match with start state. Do not touch during gameplay")]
    public bool broken = false;
    public bool open = false;

    public void SetOpenClose(bool open)
    {
        if (open)   Open();
        else        Close();
    }

    public override State Action(StateManager.Env env, ref Player player)
    {
        if (!open)
        {
            Open();
            return null;
        }
        else
        {
            return base.Action(env, ref player);
        }
    }

    private void Open()
    {
        animator.SetTrigger("Open");
        colliderClosed.enabled = false;
        colliderOpen.enabled = true;
        breakerBoxDoor.SetActive(true);
        open = true;
    }
    private void Close()
    {
        animator.SetTrigger("Close");
        colliderClosed.enabled = false;
        colliderOpen.enabled = true;
        breakerBoxDoor.SetActive(false);
        open = false;
    }
}

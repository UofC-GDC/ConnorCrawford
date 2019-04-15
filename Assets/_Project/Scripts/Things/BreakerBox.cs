using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerBox : Thing3d
{
    [SerializeField] private Animator animator;
    [SerializeField] private Collider2D colliderClosed;
    [SerializeField] private Collider2D colliderOpen;
    [SerializeField] private GameObject breakerBoxDoor;
    [SerializeField] private GameObject brokenEffect;

    [Header("Match with start state. Do not touch during gameplay")]
    public bool broken = false;
    public bool open = false;

    protected override void Start()
    {
        base.Start();
        SetOpenClose(open);
        SetBroken(broken);
    }

    public void SetOpenClose(bool open)
    {
        if (open)   Open();
        else        Close();
    }

    public void SetBroken(bool broken)
    {
        if (broken) Broken();
        else Fixed();
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

    private void Broken()
    {
        broken = true;
        brokenEffect.SetActive(true);
    }

    private void Fixed()
    {
        broken = false;
        brokenEffect.SetActive(false);
    }
}

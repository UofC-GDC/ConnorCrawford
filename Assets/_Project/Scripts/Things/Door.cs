﻿using UnityEngine;

public class Door : Thing 
{
    [SerializeField]    private Animator animator;
    [SerializeField]    private GameObject collider3d;
    [SerializeField]    private AudioSource doorSource;
    [SerializeField]    private AudioClip doorOpenClip;
    [SerializeField]    private AudioClip doorCloseClip;
    [SerializeField]    private BoxCollider2D openCollider;
    [SerializeField]    private BoxCollider2D closedCollider;
    [SerializeField]    private GameObject note;
    [SerializeField]    private NoteThingAct2 noteThing;
    [SerializeField]    private CUTSCENE_BUTTON thisIsTheEnd;

    [SerializeField]    private bool locked = false;
                        private bool noteDropped = false;

    public override State Action(StateManager.Env env, ref Player player)
    {
        if (!locked)
        {
            if (DarknessManager.Instance.doorOpen)
            {
                CloseDoor();
                return null;
            }
            else
            {
                OpenDoor();
                return null;
            }
        }
        else if (player.inventory != null && player.inventory.GetType() == typeof(Key))
        {
            UnlockDoor(env, ref player);
            return thisIsTheEnd.OutroCutscene();
        }
        else if (!noteDropped)
        {
            note.SetActive(true);
            noteThing.MakeNoteFall();
            noteDropped = true;
        }

        return base.Action(env, ref player);
    }

    private void Update()
    {
        if (locked && DarknessManager.Instance.doorOpen) CloseDoor();
    }

    private void UnlockDoor(StateManager.Env env, ref Player player)
    {
        player.inventory = null;
        locked = false;
    }

    private void OpenDoor()
    {
        animator.SetTrigger("OpenDoor");
        DarknessManager.Instance.OpenDoor();
        collider3d.SetActive(true);
        ChangeAndPlayClip(doorOpenClip);
        transform.localRotation = Quaternion.Euler(-57, -90, 90);
        openCollider.enabled = true;
        closedCollider.enabled = false;
    }

    private void CloseDoor()
    {
        if(!animator.GetNextAnimatorStateInfo(0).IsName("DoorClosed"))
            animator.SetTrigger("CloseDoor");
        DarknessManager.Instance.CloseDoor();
        collider3d.SetActive(false);
        ChangeAndPlayClip(doorCloseClip);
        openCollider.enabled = false;
        closedCollider.enabled = true;
        transform.localRotation = Quaternion.Euler(-57, 90, -90);
    }


    private void ChangeAndPlayClip(AudioClip clip)
    {
        doorSource.Stop();
        doorSource.clip = clip;
        doorSource.Play();
    }
}

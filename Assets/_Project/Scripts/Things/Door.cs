using UnityEngine;

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

    [SerializeField]    private bool locked = false;
    [HideInInspector]   public bool open = true;
                        private bool noteDropped = false;

    public override State Action(StateManager.Env env, ref Player player)
    {
        if (!locked)
        {
            if (open)
            {
                CloseDoor();
                return null;
            }
            else
            {
                animator.SetTrigger("OpenDoor");
                open = true;
                collider3d.SetActive(true);
                ChangeAndPlayClip(doorOpenClip);
                transform.localRotation = Quaternion.Euler(-57, -90, 90);
                openCollider.enabled = true;
                closedCollider.enabled = false;
                return null;
            }
        }
        else if (!noteDropped)
        {
            note.SetActive(true);
            noteDropped = true;
        }

        return base.Action(env, ref player);
    }

    private void Update()
    {
        if (locked && open) CloseDoor();
    }

    private void CloseDoor()
    {
        animator.SetTrigger("CloseDoor");
        open = false;
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

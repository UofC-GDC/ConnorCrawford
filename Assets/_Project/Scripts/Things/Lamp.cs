using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : Thing 
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource lampSound;

    private void Start()
    {
        animator.SetTrigger("LampOn");
        lampSound.Stop();
        lampSound.pitch = 1;
    }

    private bool lightOn = true;
    private string triggerString = "";
    private float soundPitch = 1;

    public override State Action()
    {
        if (!lightOn)
        {
            triggerString = "LampOn";
            lightOn = true;
            soundPitch = 1;
        }
        else
        {
            triggerString = "LampOff";
            lightOn = false;
            soundPitch = .6f;
        }

        lampSound.pitch = soundPitch;
        animator.SetTrigger(triggerString);
        lampSound.Play();

        return null
    }
}

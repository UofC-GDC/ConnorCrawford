using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : Thing 
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource lampSound;

    [SerializeField] private Thing powerOutInsight;

    private void Start()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("lampOff"))
            animator.SetTrigger("LampOff");
        lampSound.Stop();
        lampSound.pitch = 1;
    }

    private bool lightOn = false;
    private string triggerString = "";
    private float soundPitch = 1;

    bool firstTime = true;

    public bool act2 = false;
    public bool powerOn = false;

    public override State Action(StateManager.Env env, ref Player player)
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
        if(act2 && powerOn)
            animator.SetTrigger(triggerString);
        lampSound.Play();

        if (firstTime && !powerOn)
        {
            firstTime = false;
            return new DisplayInsight(StateManager.Instance.connerSpeechBubble, StateManager.Instance.connerNextButton, powerOutInsight, StateManager.Instance.connerTextMesh, StateManager.Instance.connerAudioSource, StateManager.Instance.connerAudioCurve);
        }
        return null;
    }

    private bool lastPowerStatus;

    private void Update()
    {
        if (lastPowerStatus != powerOn && !powerOn)
        {
            animator.SetTrigger("LampOff");
            firstTime = true;
        }
        lastPowerStatus = powerOn;
    }
}

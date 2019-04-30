using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteThingAct2 : Thing
{
    [SerializeField] private Animator animator;
    [SerializeField] private Thing doorUhOhInsight;
    [SerializeField] private GameObject mySpeechBubble;
    [SerializeField] private GameObject myNextButton;
    [SerializeField] private Thing noteInsight;
    [SerializeField] private TextMeshPro myTextMesh;
    [SerializeField] private AudioSource noteAudioSource;
    [SerializeField] private AnimationCurve myAudioCurve;

    //private void OnEnable()
    //{
    //    animator.SetTrigger("fall");
    //}

    public override State Action(StateManager.Env env, ref Player player)
    {
        if (DarknessManager.Instance.doorOpen) return new DisplayInsight(StateManager.Instance.connerSpeechBubble, StateManager.Instance.connerNextButton, doorUhOhInsight, StateManager.Instance.connerTextMesh, StateManager.Instance.connerAudioSource, StateManager.Instance.connerAudioCurve);
        return new DisplayInsight(mySpeechBubble, myNextButton, noteInsight, myTextMesh, noteAudioSource, myAudioCurve);
    }

    public void MakeNoteFall()
    {
        animator.SetTrigger("fall");
    }
}

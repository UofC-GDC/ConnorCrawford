using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteThing : Thing 
{
    //[SerializeField] private Animator animator;
    [SerializeField] private Thing doorUhOhInsight;

    //private void OnEnable()
    //{
    //    animator.SetTrigger("fall");
    //}

    public override State Action(StateManager.Env env, ref Player player)
    {
        if (DarknessManager.Instance.doorOpen) return new DisplayInsight(StateManager.Instance.connerSpeechBubble, StateManager.Instance.connerNextButton, doorUhOhInsight, StateManager.Instance.connerTextMesh, StateManager.Instance.connerAudioSource, StateManager.Instance.connerAudioCurve);
        return base.Action(env, ref player);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Mom : Thing 
{
    [SerializeField] private TextMeshPro dummyText;
    [SerializeField] private GameObject dummyObj;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AnimationCurve animationCurve;

    public override State Action(StateManager.Env env, ref Player player)
    {
        return new DisplayInsight(dummyObj, dummyObj, this, dummyText, audioSource, animationCurve);
    }
}

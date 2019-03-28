using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInsight : State 
{
    GameObject speechBubble;
    GameObject nextButton;
    Thing target;
    TextMeshPro textMesh;
    AudioSource audioSource;
    AnimationCurve curve;


    public DisplayInsight(GameObject speechBubble, GameObject nextButton, Thing newTarget, TextMeshPro textMesh, AudioSource audioSource, AnimationCurve curve)
    {
        this.target = newTarget;
        this.speechBubble = speechBubble;
        this.nextButton = nextButton;
        this.textMesh = textMesh;
        this.audioSource = audioSource;
        this.curve = curve;
    }

    InsightOption option;

    public State DoAction(State prevSate, StateManager.Env curr_env, ref StateManager.Env? new_env)
    {
        if (option == null)
        {
            if(target != null)
                option = target.GetInsightOption();
            else
                option = curr_env.target.GetInsightOption();

            foreach (string line in option.insightOption)
            {
                //Debug.Log(line);
            }
            if (option != null)
            {
                if (target == null)
                    DialogueManager.Instance.SetupLines(option.insightOption, speechBubble, textMesh, nextButton, audioSource, curve);
                else
                    DialogueManager.Instance.SetupLines(option.insightOption, speechBubble, textMesh, nextButton, audioSource, curve);
            }
        }

        /*if (DialogueManager.Instance.PlayNextLine()) return this;
        else return StateManager.controller;*/
        if (!DialogueManager.Instance.doneLines) return this;
        else return StateManager.controller;
    }
}

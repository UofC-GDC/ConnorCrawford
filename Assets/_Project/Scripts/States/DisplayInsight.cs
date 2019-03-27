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

    public DisplayInsight(GameObject speechBubble, GameObject nextButton, Thing newTarget, TextMeshPro textMesh)
    {
        this.target = newTarget;
        this.speechBubble = speechBubble;
        this.nextButton = nextButton;
        this.textMesh = textMesh;
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
                    DialogueManager.Instance.SetupLines(option.insightOption, speechBubble, textMesh, nextButton);
                else
                    DialogueManager.Instance.SetupLines(option.insightOption, speechBubble, textMesh, nextButton);
            }
        }

        /*if (DialogueManager.Instance.PlayNextLine()) return this;
        else return StateManager.controller;*/
        if (!DialogueManager.Instance.doneLines) return this;
        else return StateManager.controller;
    }
}

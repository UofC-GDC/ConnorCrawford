using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInsight : State 
{
    InsightOption option;
    public State DoAction(State prevSate, StateManager.Env curr_env, ref StateManager.Env? new_env)
    {
        if (option == null)
        {
            option = curr_env.target.GetInsightOption();
            foreach (string line in option.insightOption)
            {
                //Debug.Log(line);
            }
            if (option != null)
            {
                DialogueManager.Instance.SetupLines(option.insightOption, curr_env.target.insight.style);
            }
        }

        /*if (DialogueManager.Instance.PlayNextLine()) return this;
        else return StateManager.controller;*/
        if (!DialogueManager.Instance.doneLines) return this;
        else return StateManager.controller;
    }
}

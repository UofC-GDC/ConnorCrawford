using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingState : State
{
    bool hasSetDestination = false;
    public State DoAction(State prevState, StateManager.Env curr_env, ref StateManager.Env? new_env)
    {
        //Debug.Log("Do Walking State");
        var agent = StateManager.Instance.agent;
        float dist = agent.remainingDistance;
       //Debug.Log(dist);
        //float distManual = Vector3.Distance(agent.destination, agent.gameObject.transform.position);
        if (
            dist < .1f && /*distManual < .001f &&*/ 
            !agent.pathPending && 
            agent.pathStatus != NavMeshPathStatus.PathPartial && 
            agent.pathStatus != NavMeshPathStatus.PathInvalid &&
            hasSetDestination )
        {
            if (curr_env.target != null)
            {
                // Do a thing
                if (curr_env.leftClicked)
                {
                    return new DisplayInsight(StateManager.Instance.connerSpeechBubble, StateManager.Instance.connerNextButton, null, StateManager.Instance.connerTextMesh);
                }

                if (curr_env.rightClicked)
                {
                    return new DoInteractionState();
                }
            }
            else
            {
                return StateManager.controller;
            }


            return StateManager.controller;
        }
        else
        {
            if (!hasSetDestination)
            {
                agent.SetDestination(curr_env.hit3D.point);
                //Debug.Log(agent.gameObject.transform.position + " " + agent.destination);
                hasSetDestination = true;
            }
            
        }

        return this;

    }
}

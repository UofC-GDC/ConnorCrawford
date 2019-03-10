using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoInteractionState : State
{
    public State DoAction(State prevSate, StateManager.Env curr_env, ref StateManager.Env? new_env)
    {
        var maybeState = curr_env.target.Action(curr_env, ref curr_env.player);

        new_env = curr_env;

        if (maybeState != null) return maybeState;
        else return StateManager.controller;
    }
}

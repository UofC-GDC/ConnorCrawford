using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarState : State 
{
    public State DoAction(State prevSate, StateManager.Env curr_env, ref StateManager.Env? new_env)
    {
        if (Camera.main == null) return this;
        else return new GetInputState();
    }
}

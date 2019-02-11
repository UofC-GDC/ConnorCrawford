using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Entry Point for the game
 **/
public class StartState : State
{
    public State DoAction(State prevSate, StateManager.Env curr_env, ref StateManager.Env? new_env)
    {
        Debug.Log("Starting");
        return new DummyState();
    }
}

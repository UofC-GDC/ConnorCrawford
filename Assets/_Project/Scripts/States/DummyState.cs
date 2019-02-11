using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * For testing
 **/
public class DummyState : State {
    public State DoAction(State prevSate, StateManager.Env curr_env, ref StateManager.Env? new_env)
    {
        Debug.Log("Dummy action");
        return this;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface State {
    /*
     * Used to describe the action of the current state and provide the next state
     * Return this to stay in the same state
     * Assign to new_env to update the game state, query curr_env to check the current game state
     */
   State DoAction(State prevState, StateManager.Env curr_env, ref StateManager.Env? new_env);
}

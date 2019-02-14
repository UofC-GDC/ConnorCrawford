using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * THE GAME
 * 
 * This drives the game, and is the main state machine as well as the data manager
 **/
public class StateManager : Singleton<StateManager> {

    State currentState;
    State previousSate;

    public Env env {
        get;
        private set;
    }

    private void Awake()
    {
        previousSate = null;
        currentState = new StartState(); // Begin
    }

    private void Update()
    {
        var prev = previousSate;
        previousSate = currentState;
        Env? next = null;
        currentState = currentState.DoAction(prev, env, ref next); // State Transition
        env = next ?? env;
    }

    // The Game State
    public struct Env
    {
        public Player player;
        bool rightClicked;
        bool leftClicked;
    }

}

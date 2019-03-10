using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
 * THE GAME
 *
 * This drives the game, and is the main state machine as well as the data manager
 **/
public class StateManager : Singleton<StateManager>
{

    public NavMeshAgent agent;

	State currentState;
	State previousSate;

    public static State controller = new GetInputState();

	public Env env
	{
		get;
		private set;
	}

    private void Awake()
    {
        previousSate = null;
        currentState = new StartState();
    }

	private void Update()
	{
		var prev = previousSate;
		previousSate = currentState;
		Env? next = null;
		currentState = currentState.DoAction(prev, env, ref next); // State Transition
        var type = currentState.GetType();
        if (type == typeof(GetInputState) || type == typeof(CutSceneState)) controller = currentState;
		env = next ?? env;
	}

	// The Game State
	public struct Env
	{
		public Player player;
		public bool rightClicked;
		public bool leftClicked;
		public Thing target;
		public RaycastHit2D hit;
        public RaycastHit hit3D;
        public readonly NavMeshAgent agent;
	}

}

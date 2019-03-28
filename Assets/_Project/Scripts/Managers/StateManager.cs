//#define SM_DEBUG

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

/*
 * THE GAME
 *
 * This drives the game, and is the main state machine as well as the data manager
 **/
public class StateManager : Singleton<StateManager>
{

    public NavMeshAgent agent;
    public GameObject connerSpeechBubble;
    public GameObject connerNextButton;
    public TextMeshPro connerTextMesh;
    public AudioSource connerAudioSource;
    public AnimationCurve connerAudioCurve;

#if SM_DEBUG
    public CutScene testScene;
#endif

    State currentState;
	State previousSate;

#if !SM_DEBUG
    public static State controller = new GetInputState();
#else
    public static State controller;
#endif

    public Env env
	{
		get;
		private set;
	}

    private void Awake()
    {
        previousSate = null;
#if !SM_DEBUG
        currentState = new StartState();
#else
        env = new Env();
        currentState = new CutSceneState(testScene);
        controller = currentState;
#endif
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

        public override string ToString()
        {
            return
                "rightClick=" + rightClicked + " " +
                "leftClick=" + leftClicked;

        }
    }

}

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
    public bool completeDarkness = false;

    public NavMeshAgent agent;

    [Header("ConnerText")]
    public GameObject connerSpeechBubble;
    public GameObject connerNextButton;
    public TextMeshPro connerTextMesh;
    [Header("Story Text")]
    public GameObject storySpeechBubble;
    public GameObject storyNextButton;
    public TextMeshPro storyTextMesh;

    public AudioSource connerAudioSource;
    public AnimationCurve connerAudioCurve;
    public CUTSCENE_BUTTON cutsceneManager;

#if SM_DEBUG
    public CutScene testScene;
#endif

    public State currentState;
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

    [SerializeField] private bool day;

    private void Awake()
    {
        previousSate = null;
#if !SM_DEBUG
        env = new Env();
        currentState = day ? cutsceneManager.IntroCutscene() : cutsceneManager.IntroCutscenePart2();
        controller = currentState;
#else
        env = new Env();
        currentState = new CutSceneState(testScene);
        controller = currentState;
#endif
    }

	private void Update()
	{
        if (completeDarkness)
        {
            var env2 = env;
            env2.leftClicked = false;
            env = env2;
        }
        var prev = previousSate;
		previousSate = currentState;
		Env? next = null;
        if (completeDarkness)
        {
            var env2 = env;
            env2.leftClicked = false;
            env = env2;
        }
        currentState = currentState.DoAction(prev, env, ref next); // State Transition
        var type = currentState.GetType();
        if (type == typeof(GetInputState) || type == typeof(CutSceneState)) controller = currentState;
		env = next ?? env;
        if (completeDarkness)
        {
            var env2 = env;
            env2.leftClicked = false;
            env = env2;
        }
    }

	// The Game State
	public struct Env
	{
		public Player player;
		public bool rightClicked;
		public bool leftClicked;
        public bool middleClicked;
        public Thing target;
		public RaycastHit2D hit;
        public RaycastHit hit3D;
        public readonly NavMeshAgent agent;

        public override string ToString()
        {
            return
                "rightClick=" + rightClicked + " " +
                "leftClick=" + leftClicked + " " +
                "middleClicked=" + middleClicked;
        }
    }

}

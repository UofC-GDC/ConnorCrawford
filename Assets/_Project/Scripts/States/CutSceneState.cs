using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneState : State
{
    CutScene scene;
    IEnumerator<CutScene.Line> cutSceneEnumerator;

    public CutSceneState(CutScene cutScene)
    {
        scene = cutScene;
        cutSceneEnumerator = scene.script.GetEnumerator();
    }

    public State DoAction(State prevState, StateManager.Env curr_env, ref StateManager.Env? new_env)
    {
        Debug.Log("Entering next Scene");
        if (cutSceneEnumerator.MoveNext())
        {
            CutScene.Line currentLine = cutSceneEnumerator.Current;
            State next = new GetInputState();
            StateManager.Env localEnv = curr_env;

            RaycastHit fake = new RaycastHit();
            fake.point = currentLine.arg.transform.position;
            localEnv.hit3D = fake;
            localEnv.target = currentLine.arg.GetComponent<Thing>();

            switch (currentLine.verb)
            {
                case CutScene.Verb.WalkTo:
                    next = new WalkingState();
                    localEnv.rightClicked = false;
                    localEnv.leftClicked = false;
                    break;
                case CutScene.Verb.DisplayInsight:
                    next = new DisplayInsight(StateManager.Instance.connerSpeechBubble, StateManager.Instance.connerNextButton, null, StateManager.Instance.connerTextMesh, StateManager.Instance.connerAudioSource, StateManager.Instance.connerAudioCurve);
                    localEnv.rightClicked = false;
                    localEnv.leftClicked = true;
                    break;
                case CutScene.Verb.DoAction:
                    next = new DoInteractionState();
                    localEnv.rightClicked = true;
                    localEnv.leftClicked = false;
                    break;
            }

            new_env = localEnv;
            Debug.Log("The next state is: " + next);
            return next;
        }
        else
        {
            Debug.Log("Cutscene Over.");
            return new GetInputState();
        }
    }
}

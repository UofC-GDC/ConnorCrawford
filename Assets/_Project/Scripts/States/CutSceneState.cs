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
        //cutSceneEnumerator.MoveNext();
    }

    public State DoAction(State prevState, StateManager.Env curr_env, ref StateManager.Env? new_env)
    {
        Debug.Log("Entering next Scene");
        if (cutSceneEnumerator.MoveNext())
        {
            State next = new GetInputState();
            var localEnv = curr_env;
            RaycastHit fake = new RaycastHit();
            fake.point = cutSceneEnumerator.Current.arg.transform.position;
            localEnv.hit3D = fake;
            localEnv.target = cutSceneEnumerator.Current.arg.GetComponent<Thing>();
            switch (cutSceneEnumerator.Current.verb)
            {
                case CutScene.Verb.WalkTo:
                    next = new WalkingState();
                    break;
                case CutScene.Verb.DisplayInsight:
                    next = new DisplayInsight(StateManager.Instance.connerSpeechBubble, StateManager.Instance.connerNextButton, null, StateManager.Instance.connerTextMesh);
                    break;
                case CutScene.Verb.DoAction:
                    next = new DoInteractionState();
                    break;
            }

           // cutSceneEnumerator.MoveNext();
            new_env = localEnv;
            Debug.Log("Next is: " + next);
            return next;
        }
        else
        {
            Debug.Log("Cutscene Over");
            return new GetInputState();
        }
    }
}

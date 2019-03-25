using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInputState : State
{
    public State DoAction(State prevSate, StateManager.Env curr_env, ref StateManager.Env? new_env)
    {
        if (DarknessManager.Instance.runTheDoorCutscene) return DarknessManager.Instance.DoorCutscene();

        //Debug.Log("Doing Input State");
        StateManager.Env localEnv = curr_env;

        localEnv.leftClicked = Input.GetMouseButtonDown(0);
        localEnv.rightClicked = Input.GetMouseButtonDown(1);

        RaycastHit2D hit2D;
        RaycastHit hit3D;

        if (Camera.main == null) return new DummyState();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit3D)) ;
            //agent.SetDestination(hit3D.point);
            
            
        hit2D = Physics2D.GetRayIntersection(ray);
        if (hit2D)
            localEnv.target = hit2D.collider.gameObject.GetComponent<Thing>();
        else
            localEnv.target = null;

        //Debug.Log(localEnv.leftClicked);
       // Debug.Log(localEnv.rightClicked);

        localEnv.hit = hit2D;
        localEnv.hit3D = hit3D;

        new_env = localEnv;
        if (localEnv.leftClicked || localEnv.rightClicked) return new WalkingState();
        return this;
    }
}

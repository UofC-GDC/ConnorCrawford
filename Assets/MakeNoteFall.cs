using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeNoteFall : Thing 
{

	private void Start () 
    {
		
	}

    public override State Action(StateManager.Env env, ref Player player)
    {
        GetComponent<Animator>().SetTrigger("fall");
        return null;
    }
}

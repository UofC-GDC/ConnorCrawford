using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneNight : Thing 
{

	private void Start () 
    {
		
	}

    public override State Action(StateManager.Env env, ref Player player)
    {
        SceneManager.LoadScene("Night(Dirty)");
        return null;
    }
}

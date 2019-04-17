using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoReset : Singleton<DemoReset> 
{
	private void Update () 
    {
        if (Input.GetKeyUp(KeyCode.P))
        { 
            SceneManager.LoadScene("Night(Dirty)");
        }
    }
}

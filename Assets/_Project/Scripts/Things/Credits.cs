using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : Thing 
{
    public override State Action(StateManager.Env env, ref Player player)
    {
        GetComponent<Animator>().SetTrigger("Credits");
        return null;
    }
}

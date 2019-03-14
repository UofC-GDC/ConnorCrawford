using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerBoxDoor : Thing 
{
    [SerializeField] private BreakerBox breakerBox;

    public override State Action(StateManager.Env env, ref Player player)
    {
        breakerBox.open = false;
        breakerBox.SetOpenClose(false);
        return null;
    }
}

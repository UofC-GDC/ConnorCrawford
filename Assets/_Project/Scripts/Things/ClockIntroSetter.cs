using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockIntroSetter : Thing 
{
    public override State Action(StateManager.Env env, ref Player player)
    {
        Clock.Instance.SetClock(1);
        return null;
    }
}

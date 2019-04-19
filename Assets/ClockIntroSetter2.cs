using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockIntroSetter2 : Thing
{
    public override State Action(StateManager.Env env, ref Player player)
    {
        Clock.Instance.SetClock(9);
        return null;
    }
}

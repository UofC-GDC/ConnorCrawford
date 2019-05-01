using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act2Setup : Thing 
{
    [SerializeField] private Flashlight flashlight;
    [SerializeField] private TimeMachine timeMachine;

    public override State Action(StateManager.Env env, ref Player player)
    {
        flashlight.AddBattery();
        //timeMachine.open = true;
        //timeMachine.unlocked = true;
        //timeMachine.readyToTimeTravel = true;
        return null;
    }
}

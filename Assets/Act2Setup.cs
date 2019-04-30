using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Act2Setup : Thing 
{
    [SerializeField] private Flashlight flashlight;

    public override State Action(StateManager.Env env, ref Player player)
    {
        flashlight.AddBattery();
        return null;
    }
}

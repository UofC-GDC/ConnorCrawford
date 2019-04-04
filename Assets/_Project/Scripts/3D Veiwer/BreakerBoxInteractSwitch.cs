using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerBoxInteractSwitch : Interatable3D
{
    [SerializeField] private Vector3 rotationOn;
    [SerializeField] private Vector3 rotationOff;

    public bool on = false;

    public override void interact(StateManager.Env env, ref Player player)
    {
        var rot = on ? rotationOff : rotationOn;
        transform.rotation = Quaternion.Euler(rot);
    }
}

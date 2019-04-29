using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerBoxInteractSwitch : Interatable3D
{
    [SerializeField] private Vector3 posOn;
    [SerializeField] private Vector3 posOff;

    public bool on = false;

    protected override void interactStart()
    {
        var pos = on ? posOff : posOn;
        transform.parent.localPosition = pos;
        on = !on;
    }
}

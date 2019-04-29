using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : Interatable3D 
{
    [SerializeField] private GameObject origin;

    private Vector3 mouseStartPos;

    protected override void interactStart()
    {
        mouseStartPos = Input.mousePosition;
    }

    public override void interact(StateManager.Env env, ref Player player)
    {
        origin.transform.Rotate(origin.transform.forward, (Input.mousePosition - mouseStartPos).x);
    }
}

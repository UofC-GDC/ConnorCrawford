using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : Interatable3D 
{
    [SerializeField] private GameObject origin;

    public override void interact(StateManager.Env env, ref Player player)
    {
        
    }
}

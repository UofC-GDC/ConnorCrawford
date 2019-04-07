using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioInteract : Interatable3D
{
    private bool battery = false;

    public override void interact(StateManager.Env env, ref Player player)
    {
        if (!battery)
        {
            battery = true;
            player.inventory = gameObject.AddComponent<Battery>();
        }
    }

    private void Start()
    {
        
    }
}

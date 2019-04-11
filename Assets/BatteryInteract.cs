using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryInteract : Interatable3D
{
    [HideInInspector] public bool battery = false;
    [SerializeField] private Desk desk;

    // This seems to add a battery script component to whatever object this script is attached to
    // if put in the interact method it will do the above continuously and a lot
    public override void interact(StateManager.Env env, ref Player player)
    {
        if (battery)
        {
            battery = false;
            player.inventory = null;
        }
        else
        {
            battery = true;
            if (player.inventory != null && player.inventory.GetType() == typeof(BluePaper))
                desk.paper = false;
            player.inventory = gameObject.AddComponent<Battery>();
        }
    }
}

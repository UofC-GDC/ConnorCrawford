using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : Thing 
{
    [HideInInspector] public bool paper = false;
    [SerializeField] private Insight dummy;
    [SerializeField] private RadioInteract radio;

    public override State Action(StateManager.Env env, ref Player player)
    {
        if (!paper)
        {
            paper = true;
            var paperThing = gameObject.AddComponent<BluePaper>();
            paperThing.insight = dummy;
            if (player.inventory != null && player.inventory.GetType() == typeof(Battery))
                radio.battery = false;
            player.inventory = paperThing;
        }
        else
        {
            return base.Action(env, ref player);
        }

        return null;
    }
}

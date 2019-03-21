using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : Thing 
{
    private bool paper = false;
    [SerializeField] private Insight dummy;

    public override State Action(StateManager.Env env, ref Player player)
    {
        if (!paper)
        {
            paper = true;
            var paperThing = gameObject.AddComponent<BluePaper>();
            paperThing.insight = dummy;
            player.inventory = paperThing;
        }
        else
        {
            return base.Action(env, ref player);
        }

        return null;
    }
}

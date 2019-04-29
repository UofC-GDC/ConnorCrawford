using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerBoxManager : Singleton<BreakerBoxManager>
{
    [SerializeField] List<BreakerBoxInteractSwitch> switches = new List<BreakerBoxInteractSwitch>();

    bool everythingOff = true;

    private void Update()
    {
        everythingOff = true;

        for (int i = 0; i < switches.Count; i++)
        {
            if (i == 3 || i == 1 || i == 2 || i == 8) { continue; }
            if (switches[i].on)
            {
                everythingOff = false;
                break;
            }
        }

        if (switches[3].on && switches[1].on && switches[2].on && switches[8].on && everythingOff)
        {
            //Turn off all objects that need to be turned off. Turn off lights. Trigger particle effect & sound effects, etc.
            Destroy(this);
        }
    }
}

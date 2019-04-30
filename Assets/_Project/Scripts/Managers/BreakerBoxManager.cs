using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerBoxManager : Singleton<BreakerBoxManager>
{
    [SerializeField] List<BreakerBoxInteractSwitch> switches = new List<BreakerBoxInteractSwitch>();

    [SerializeField] private LightSwitch lightswitch;
    [SerializeField] private Lamp lamp;
    [SerializeField] private BreakerBox breakerBox;

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
            lightswitch.powerOn = false;
            lamp.powerOn = false;
            DarknessManager.Instance.powerOn = false;
            breakerBox.SetBroken(true);
            GetComponent<AudioSource>().Play();
            Destroy(this);
        }
    }
}

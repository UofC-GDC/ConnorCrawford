using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryInteract : Interatable3D
{
    [HideInInspector]
    public bool battery1 = false;
    [HideInInspector]
    public bool battery2 = true;
    [SerializeField] private Desk desk;
    [SerializeField] private GameObject battery1Vis;
    [SerializeField] private GameObject battery2Vis;

    private Battery battery1Real;
    private Battery battery2Real;

    private bool canGo = true;

    private void Start()
    {
        battery1Real = gameObject.AddComponent<Battery>();
        //battery2Real = gameObject.AddComponent<Battery>();
    }

    public override void interact(StateManager.Env env, ref Player player)
    {
        if (!canGo) return;

        if (player.inventory != null && player.inventory.GetType() == typeof(Battery))
        {
            player.inventory = null;
            if (battery1Vis.activeSelf == true)
            {
                if (battery2Vis.activeSelf == true)
                { }
                else
                {
                    battery2Vis.SetActive(true);
                    battery2 = false;
                }
            }
            else
            {
                battery1Vis.SetActive(true);
                battery1 = false;
            }

        }
        else
        {
            if (!battery1)
            {
                battery1 = true;
                if (player.inventory != null && player.inventory.GetType() == typeof(BluePaper))
                    desk.paper = false;
                player.inventory = battery1Real;
            }
            else
            {
                battery2 = true;
                if (player.inventory != null && player.inventory.GetType() == typeof(BluePaper))
                    desk.paper = false;
                player.inventory = battery2Real;
            }
        }

        canGo = false;
    }

    // This seems to add a battery script component to whatever object this script is attached to
    // if put in the interact method it will do the above continuously and a lot
    protected override void interactEnd()
    {
        canGo = true;
    }

    private void Update()
    {
        if (!battery1)
        {
            battery1Vis.SetActive(true);
        }
        else
            battery1Vis.SetActive(false);

        if (!battery2)
        {
            battery2Vis.SetActive(true);
        }
        else
            battery2Vis.SetActive(false);
    }
}

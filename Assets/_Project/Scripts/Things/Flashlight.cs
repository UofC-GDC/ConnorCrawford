using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Thing
{
    [SerializeField] private new SpriteRenderer renderer;
    [SerializeField] private Transform flashLightHolder;

    private void Start()
    {
        renderer.enabled = true;
        DarknessManager.Instance.ResetFlashlight();
    }

    public override State Action(StateManager.Env env, ref Player player)
    {
        if (env.player.inventory != null)
        {
            if (env.player.inventory.GetType() == typeof(BluePaper))
            {
                DarknessManager.Instance.BlueifyFlashlight();
                player.inventory = null;
            }
            else if (env.player.inventory.GetType() == typeof(Battery))
            {
                DarknessManager.Instance.PowerFlashlight();
                player.inventory = null;
            }
            else if (!DarknessManager.Instance.flashlightInHand)
            {
                PickupFlashlight();
                return base.Action(env, ref player);
            }
            else
            {
                return base.Action(env, ref player);
            }
        }
        else if (!DarknessManager.Instance.flashlightInHand)
        {
            PickupFlashlight();
        }
        else
        {
            return base.Action(env, ref player);
        }

        return null;
    }

    private void PickupFlashlight()
    {
        DarknessManager.Instance.PickupFlashlight();
        renderer.transform.SetParent(flashLightHolder, true);
        renderer.transform.localPosition = Vector3.zero;
    }
}

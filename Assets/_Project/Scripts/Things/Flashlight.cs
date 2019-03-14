using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Thing
{
    [SerializeField] private new SpriteRenderer renderer;

    private void Start()
    {
        renderer.enabled = true;
        DarknessManager.Instance.ResetFlashlight();
    }

    public override State Action(StateManager.Env env, ref Player player)
    {
        switch (DarknessManager.Instance.currentFlashLightState)
        {
            case DarknessManager.FlashLightState.ground:
                renderer.enabled = false;
                DarknessManager.Instance.PickupFlashlight();
                break;
            case DarknessManager.FlashLightState.inHand:
                if (env.player.inventory.GetType() == typeof(BluePaper))
                    DarknessManager.Instance.BlueifyFlashlight();
                break;
            case DarknessManager.FlashLightState.blue:
                return base.Action(env, ref player);
        }

        return null;
    }
}

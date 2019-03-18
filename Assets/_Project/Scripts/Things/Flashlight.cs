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

    //Caelum you were removing the enum for flashlight and replacing with bools since all states of onGround x blue x powered are possible. Additionally power needs to properly programmed in.

    public override State Action(StateManager.Env env, ref Player player)
    {
        if (env.player.inventory != null)
        {
            if (env.player.inventory.GetType() == typeof(BluePaper))
            {
                DarknessManager.Instance.BlueifyFlashlight(); //Double check this
            }
            else if (env.player.inventory.GetType() == typeof(Battery))
            {
                DarknessManager.Instance.PowerFlashlight(); //Double check this
            }
        }
        else if (DarknessManager.Instance.flashlightInHand)
        {
            renderer.enabled = false;
            DarknessManager.Instance.PickupFlashlight();
        }
        else
        {
            return base.Action(env, ref player);
        }

        return null;
    }
}

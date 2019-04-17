using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Thing
{
    [SerializeField] private new SpriteRenderer renderer;
    [SerializeField] private Transform flashLightHolder;
    [SerializeField] private Thing flashlightPickupInsightObject;
    [SerializeField] private Thing flashlightPowerInsightObject;
    [SerializeField] private Thing flashlightBlueInsightObject;

    private void Start()
    {
        renderer.enabled = true;
        DarknessManager.Instance.ResetFlashlight();
    }

    Battery myBattery = null;

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
                myBattery = (Battery)player.inventory;
                player.inventory = null;
                if (!DarknessManager.Instance.flashlightBlue)
                    return new DisplayInsight(StateManager.Instance.connerSpeechBubble, StateManager.Instance.connerNextButton, flashlightPowerInsightObject, StateManager.Instance.connerTextMesh, StateManager.Instance.connerAudioSource, StateManager.Instance.connerAudioCurve);
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
            if (!DarknessManager.Instance.flashlightPowered)
                return new DisplayInsight(StateManager.Instance.connerSpeechBubble, StateManager.Instance.connerNextButton, flashlightPickupInsightObject, StateManager.Instance.connerTextMesh, StateManager.Instance.connerAudioSource, StateManager.Instance.connerAudioCurve);
        }
        else
        {
            if (DarknessManager.Instance.flashlightPowered)
            {
                DarknessManager.Instance.DePowerFlashlight();
                player.inventory = myBattery;
                myBattery = null;
            }
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

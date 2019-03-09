﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Thing
{
    [SerializeField] private new SpriteRenderer renderer;

    private flashLightState currentFlashLightState = flashLightState.ground;

    public enum flashLightState
    {
        ground,
        inHand,
        blue
    }

    private void Start()
    {
        renderer.enabled = true;
    }

    public override State Action()
    {
        switch (currentFlashLightState)
        {
            case flashLightState.ground:
                renderer.enabled = false;
                //cursor.hasLight = true;
                currentFlashLightState = flashLightState.inHand;
                break;
            case flashLightState.inHand:
                //if (typeof(StateManager.Instance.env.player.inventory) == typeof(BluePaper))
                //{
                //    currentFlashLightState = flashLightState.blue;
                //}
                break;
            case flashLightState.blue:
                return base.Action();
        }

        return null;
    }
}

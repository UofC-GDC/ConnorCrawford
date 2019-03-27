using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manual : Thing 
{
    [SerializeField] private GameObject speechBubble;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private TextMeshPro textMesh;
    [SerializeField] private Thing manualTarget;

    public override State Action(StateManager.Env env, ref Player player)
    {
        if (DarknessManager.Instance.flashlightPowered && DarknessManager.Instance.flashlightInHand && DarknessManager.Instance.flashlightBlue)
            Clock.Instance.SetClock(6);
        return new DisplayInsight(speechBubble, nextButton, manualTarget, textMesh);
    }
}

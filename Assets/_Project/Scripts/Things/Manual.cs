using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manual : Thing 
{
    [SerializeField] private GameObject speechBubble;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private TextMeshPro textMesh;

    public override State Action(StateManager.Env env, ref Player player)
    {
        return new DisplayInsight(speechBubble, nextButton, this, textMesh);
    }
}

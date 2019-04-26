using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : Thing 
{
    [HideInInspector] public bool paper = false;
    [SerializeField] private Insight dummy;
    [SerializeField] private BatteryInteract battery;
    [SerializeField] private Thing bluePaperInsight;
    [SerializeField] private SpriteRenderer visuals;
    [SerializeField] private Collider2D hitbox;

    public override State Action(StateManager.Env env, ref Player player)
    {
        if (!paper)
        {
            paper = true;
            var paperThing = gameObject.AddComponent<BluePaper>();
            paperThing.insight = dummy;
            if (player.inventory != null && player.inventory.GetType() == typeof(Battery))
                battery.battery1 = false;
            player.inventory = paperThing;
            return new DisplayInsight(StateManager.Instance.storySpeechBubble, StateManager.Instance.storyNextButton, bluePaperInsight, StateManager.Instance.storyTextMesh, StateManager.Instance.connerAudioSource, StateManager.Instance.connerAudioCurve);
        }
        else
        {
            return base.Action(env, ref player);
        }

        return null;
    }

    private void Update()
    {
        visuals.enabled = !paper;
        hitbox.enabled = !paper;
    }
}

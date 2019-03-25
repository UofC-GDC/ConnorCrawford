using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUTSCENE_BUTTON : Thing 
{
    [SerializeField] private GameObject door;

    public override State Action(StateManager.Env env, ref Player player)
    {
        StarExitButton.Instance.ActivateStarPuzzle();
        return null;
        //return DoorCutscene();
    }

    public State DoorCutscene()
    {
        CutScene c = (CutScene)ScriptableObject.CreateInstance(typeof(CutScene));

        var line1 = new CutScene.Line();
        line1.arg = door.gameObject;
        line1.verb = CutScene.Verb.WalkTo;

        var line2 = new CutScene.Line();
        line2.arg = door.gameObject;
        line2.verb = CutScene.Verb.DisplayInsight;

        var line3 = new CutScene.Line();
        line3.arg = door.gameObject;
        line3.verb = CutScene.Verb.DoAction;

        c.script = new List<CutScene.Line>();
        c.script.Add(line3);
        c.script.Add(line1);
        //c.script.Add(line2);

        return c.MakeState();
    }
}

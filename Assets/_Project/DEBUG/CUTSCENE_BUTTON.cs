using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUTSCENE_BUTTON : Thing 
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject loc2;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject doorPos;
    [SerializeField] private GameObject fadeInPanel;
    [SerializeField] private GameObject fadeOutPanel;
    [SerializeField] private GameObject clockSetter;

    public override State Action(StateManager.Env env, ref Player player)
    {
        return Cutscene();
    }

    public State Cutscene()
    {
        CutScene cutscene = (CutScene) ScriptableObject.CreateInstance(typeof(CutScene));
        List<CutScene.Line> cutsceneScript = new List<CutScene.Line>();

        CutScene.Line line0 = new CutScene.Line();
        line0.arg = clockSetter;
        line0.verb = CutScene.Verb.DoAction;

        cutsceneScript.Add(line0);

        CutScene.Line line1 = new CutScene.Line();
        line1.arg = target;
        line1.verb = CutScene.Verb.WalkTo;

        cutsceneScript.Add(line1);

        CutScene.Line line1andAHalf = new CutScene.Line();
        line1andAHalf.arg = loc2;
        line1andAHalf.verb = CutScene.Verb.WalkTo;

        cutsceneScript.Add(line1andAHalf);

        var line2 = new CutScene.Line();
        line2.arg = target;
        line2.verb = CutScene.Verb.DisplayInsight;

        for (int i = 0; i < 7; i++)
        {
            cutsceneScript.Add(line2);
        }

        CutScene.Line line3 = new CutScene.Line();
        line3.arg = fadeInPanel;
        line3.verb = CutScene.Verb.DoAction;

        cutsceneScript.Add(line3);

        CutScene.Line line4 = new CutScene.Line();
        line4.arg = doorPos;
        line4.verb = CutScene.Verb.WalkTo;

        cutsceneScript.Add(line4);

        CutScene.Line line5 = new CutScene.Line();
        line5.arg = door;
        line5.verb = CutScene.Verb.DoAction;

        cutsceneScript.Add(line5);

        CutScene.Line line6 = new CutScene.Line();
        line6.arg = fadeOutPanel;
        line6.verb = CutScene.Verb.DoAction;

        cutsceneScript.Add(line6);

        cutscene.script = cutsceneScript;

        return cutscene.MakeState();
    }
}

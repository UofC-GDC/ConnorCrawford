using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUTSCENE_BUTTON : Thing 
{
    [Header("Intro")]
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject loc2;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject doorPos;
    [SerializeField] private GameObject fadeInPanel;
    [SerializeField] private GameObject fadeOutPanel;
    [SerializeField] private GameObject clockSetter;
    //[Header("Outro")]
    [SerializeField] private GameObject outroLines;
    [SerializeField] private GameObject credits;

    [SerializeField] private PlayAllTheSoundEffects playAllTheSoundEffects;

    private void Start()
    {
        
    }

    public override State Action(StateManager.Env env, ref Player player)
    {
        //return IntroCutscene();
        return OutroCutscene();
    }

    public State IntroCutscene()
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

    public State OutroCutscene()
    {
        #region Setup
        CutScene cutscene = (CutScene)ScriptableObject.CreateInstance(typeof(CutScene));
        List<CutScene.Line> cutsceneScript = new List<CutScene.Line>();
        #endregion

        #region Lines
        CutScene.Line line0 = new CutScene.Line();
        line0.arg = doorPos;
        line0.verb = CutScene.Verb.WalkTo;

        cutsceneScript.Add(line0);

        CutScene.Line line1 = new CutScene.Line();
        line1.arg = door;
        line1.verb = CutScene.Verb.DoAction;

        cutsceneScript.Add(line1);

        CutScene.Line line2 = new CutScene.Line();
        line2.arg = target;
        line2.verb = CutScene.Verb.WalkTo;

        cutsceneScript.Add(line2);

        CutScene.Line line3 = new CutScene.Line();
        line3.arg = loc2;
        line3.verb = CutScene.Verb.WalkTo;

        cutsceneScript.Add(line3);

        CutScene.Line line4 = new CutScene.Line();
        line4.arg = outroLines;
        line4.verb = CutScene.Verb.DisplayInsight;

        cutsceneScript.Add(line4);

        CutScene.Line line5 = new CutScene.Line();
        line5.arg = doorPos;
        line5.verb = CutScene.Verb.WalkTo;

        cutsceneScript.Add(line5);

        CutScene.Line line6 = new CutScene.Line();
        line6.arg = outroLines;
        line6.verb = CutScene.Verb.DoAction;

        cutsceneScript.Add(line6);

        CutScene.Line line7 = new CutScene.Line();
        line7.arg = target;
        line7.verb = CutScene.Verb.WalkTo;

        cutsceneScript.Add(line7);

        CutScene.Line line8 = new CutScene.Line();
        line8.arg = loc2;
        line8.verb = CutScene.Verb.WalkTo;

        cutsceneScript.Add(line8);

        CutScene.Line line9 = new CutScene.Line();
        line9.arg = outroLines;
        line9.verb = CutScene.Verb.DisplayInsight;

        cutsceneScript.Add(line9);

        // Tummy grumble
        // Mom sounds

        CutScene.Line line11 = new CutScene.Line();
        line11.arg = outroLines;
        line11.verb = CutScene.Verb.DisplayInsight;

        cutsceneScript.Add(line11);

        CutScene.Line line12 = new CutScene.Line();
        line12.arg = doorPos;
        line12.verb = CutScene.Verb.WalkTo;

        cutsceneScript.Add(line12);

        //Fade out Conner
        //Play sounds

        //Fade to black
        CutScene.Line line14 = new CutScene.Line();
        line14.arg = fadeOutPanel;
        line14.verb = CutScene.Verb.DoAction;

        cutsceneScript.Add(line14);

        //Play Credits
        CutScene.Line line15 = new CutScene.Line();
        line15.arg = credits;
        line15.verb = CutScene.Verb.DoAction;

        cutsceneScript.Add(line15);
        //Close game?
        #endregion

        #region UnSetup
        cutscene.script = cutsceneScript;

        return cutscene.MakeState();
        #endregion
    }
}

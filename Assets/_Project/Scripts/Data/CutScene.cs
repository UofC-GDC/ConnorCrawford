using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

[CreateAssetMenu(fileName = "New Cutscene", menuName = "new Cutscene")]
public class CutScene : ScriptableObject {

    public enum Verb
    {
        WalkTo, DisplayInsight, DoAction
    }

    [System.Serializable]
    public struct Line
    {
        public Verb verb;
        public GameObject arg;
    }

    public List<Line> script;

    public CutSceneState MakeState()
    {
        return new CutSceneState(this);
    }
}

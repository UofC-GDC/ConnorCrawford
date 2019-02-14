using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class InsightOption
{
    public List<string> insightOption;
}

[CreateAssetMenu(fileName = "Insight", menuName ="New Insight")]
public class Insight : ScriptableObject {

    public List<InsightOption> text = new List<InsightOption>();

    public TextMeshPro style;
}

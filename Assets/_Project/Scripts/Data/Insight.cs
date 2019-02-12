using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Insight", menuName ="New Insight")]
public class Insight : ScriptableObject {
    public List<List<string>> text = new List<List<string>>();

    public Text style;
}

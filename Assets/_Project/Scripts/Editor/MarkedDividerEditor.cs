using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MarkedDivider))]
[CanEditMultipleObjects]
public class MarkedDividerEditor : Editor
{
    private GUILayoutOption[] options = {
        GUILayout.ExpandWidth (true),
        GUILayout.ExpandHeight (true)
    };

    public override void OnInspectorGUI()
    {
        GUIStyle labelStyle = new GUIStyle(GUI.skin.GetStyle("label"));
        labelStyle.wordWrap = true;
        labelStyle.stretchWidth = true;
        labelStyle.fontStyle = FontStyle.Normal;

        EditorGUILayout.LabelField("This GameObject is marked as a divider. This means it's position, rotation, and scale are locked, no other components may be added, and it may not have any children.", labelStyle, options);
    }
}

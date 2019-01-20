using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MarkedFolder))]
[CanEditMultipleObjects]
public class MarkedFolderEditor : Editor
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

        EditorGUILayout.LabelField("This GameObject is marked as a folder. This means it's position, rotation, and scale are locked and no other components may be added.", labelStyle, options);
    }
}

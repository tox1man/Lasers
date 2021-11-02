using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RootScript))]
public class RootCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        RootScript rootScript = (RootScript)target;
        ModuleObjectView[] views = rootScript._moduleViews;

        base.OnInspectorGUI();

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Gameplay", EditorStyles.boldLabel);

        for (int i = 0; i < views.Length; i++)
        {
            if (rootScript._moduleAmounts == null || views[i] == null)
            {
                Debug.LogError("Some of ModuleObjectView elements hasn't been assigned.");
                continue;
            }
            int value = rootScript._moduleAmounts[i];

            EditorGUILayout.BeginVertical();
                EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField($"{views[i].name}s: {value}");
                    if(GUILayout.Button("+"))
                    {
                        if (value < 20) rootScript.OnModuleAmountChange(i, true);
                        value = Mathf.Clamp(value + 1, 0, 20);
                        rootScript._moduleAmounts[i] = value;
                    }
                    else if(GUILayout.Button("-"))
                    {
                        if (value > 0) rootScript.OnModuleAmountChange(i, false);
                        value = Mathf.Clamp(value - 1, 0, 20);
                        rootScript._moduleAmounts[i] = value;
                    }
                EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
        }
    }
}

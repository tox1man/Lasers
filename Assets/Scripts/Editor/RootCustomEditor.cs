using UnityEditor;
using UnityEngine;
using static UnityEditor.EditorGUILayout;
using static ModuleGUILayout;
using static Parameters;
using System.Collections.Generic;

[CustomEditor(typeof(RootScript))]
public class RootCustomEditor : Editor
{
    RootScript rootScript;
    ModuleObjectView[] views;
    bool[] foldoutsState;

    public void OnEnable()
    {
        rootScript = GetRoot();
        views = rootScript._moduleViews;
        foldoutsState = new bool[views.Length];
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Space();
        LabelField("Gameplay", EditorStyles.boldLabel);

        for (int i = 0; i < views.Length; i++)
        {
            if (rootScript.ModuleAmounts == null || views[i] == null )
            {
                Debug.LogError("Some of ModuleObjectView elements hasn't been assigned.");
                continue;
            }

            int moduleAmount = rootScript.ModuleAmounts[i];

            BeginVertical();
                DisplayModulesParameters(views[i].Type, i, moduleAmount);
            EndVertical();
        }
    }
    private void StageSettings()
    {
        Dictionary<ModuleType, int> dict = new Dictionary<ModuleType, int>();
        

    }
    private void CreateModuleButtons(int i, int moduleAmount)
    {
        LabelField("");
        BeginHorizontal();
        if (GUILayout.Button("+"))
        {
            if (moduleAmount < 20) rootScript.OnModuleAmountChange(i, true);
            moduleAmount = Mathf.Clamp(moduleAmount + 1, 0, 20);
            rootScript.ModuleAmounts[i] = moduleAmount;
        }
        else if (GUILayout.Button("-"))
        {
            if (moduleAmount > 0) rootScript.OnModuleAmountChange(i, false);
            moduleAmount = Mathf.Clamp(moduleAmount - 1, 0, 20);
            rootScript.ModuleAmounts[i] = moduleAmount;
        }
        EndHorizontal();
    }
    private void DisplayModulesParameters(ModuleType type, int moduleIndex, int amount)
    {
        string foldoutLabel = $"{type}s Settings";
        string moduleLabel;
        if (foldoutsState[moduleIndex] = Foldout(foldoutsState[moduleIndex], foldoutLabel))
        {
            CreateModuleButtons(moduleIndex, amount);
        
            switch (type)
            {
                case ModuleType.Absorber:
                    for (int i = 0; i < amount; i++)
                    {
                        moduleLabel = $"{type} {i + 1}";
                        BeginHorizontal();
                            Toggle(true);
                            LabelField($"{moduleLabel} color");
                            EditorGUI.BeginChangeCheck();
                            try { DisplayAbsorberTargetColor(GameObject.Find(moduleLabel).GetComponent<ModuleObjectView>()); }
                            catch { LabelField("Avaliable in Play."); }
                            if (EditorGUI.EndChangeCheck())
                            {
                                Debug.Log($"{moduleLabel} changed");
                            }
                        EndHorizontal();
                    }
                    break;
                case ModuleType.Disperser:
                    for (int i = 0; i < amount; i++)
                    {
                        moduleLabel = $"{type} {i + 1}";
                        EditorGUI.BeginChangeCheck();
                        try
                        {
                            BeginHorizontal();
                            LabelField(moduleLabel);
                            EndHorizontal();
                        }
                        catch { LabelField("Avaliable in Play."); }
                        if (EditorGUI.EndChangeCheck())
                        {
                            Debug.Log($"{moduleLabel} changed");
                        }
                    }
                    break;
                case ModuleType.Emitter:
                    for (int i = 0; i < amount; i++)
                    {
                        moduleLabel = $"{type} {i + 1}";
                        EditorGUI.BeginChangeCheck();
                        try 
                        {
                            BeginHorizontal();
                                LabelField($"{moduleLabel} color");
                                DisplayLaserColors(GameObject.Find(moduleLabel).GetComponent<ModuleObjectView>());
                            EndHorizontal();
                            BeginHorizontal();
                                LabelField($"{moduleLabel} direction");
                                DisplayLaserDirection(GameObject.Find(moduleLabel).GetComponent<ModuleObjectView>());
                            EndHorizontal();
                        }
                        catch { LabelField("Avaliable in Play."); EndHorizontal(); }
                        if (EditorGUI.EndChangeCheck())
                        {
                            Debug.Log($"{moduleLabel} changed");
                        }
                    }
                    break;
                case ModuleType.Reflector:
                    for (int i = 0; i < amount; i++)
                    {
                        moduleLabel = $"{type} {i + 1}";
                        EditorGUI.BeginChangeCheck();
                        try
                        {
                            BeginHorizontal();
                            LabelField(moduleLabel);
                            EndHorizontal();
                        }
                        catch { LabelField("Avaliable in Play."); }
                        if (EditorGUI.EndChangeCheck())
                        {
                            Debug.Log("reflector changed");
                        }
                    }
                    break;
                default: Debug.LogError($"There is no such ModuleType. {this}");
                    break;
            }
        }
    }
}

using UnityEditor;
using UnityEngine;
using static UnityEditor.EditorGUILayout;
using static UnityEditor.EditorGUI;
using static ModuleGUILayout;
using static Parameters;

[CustomEditor(typeof(RootScript))]
public class RootCustomEditor : Editor
{
    private RootScript _rootScript;
    private StageData _stage;
    private ModuleObjectView[] _views;
    private bool[] _foldoutsState;

    public void OnEnable()
    {
        _rootScript = GetRoot();
        _stage = _rootScript.CurrentStage;
        _views = _rootScript.ModuleViews;
        _foldoutsState = new bool[_views.Length];
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Space(10);
        LabelField("Modules settings", EditorStyles.boldLabel);
        for (int i = 0; i < _views.Length; i++)
        {
            if (_stage.ModuleAmounts == null || _views[i] == null )
            {
                Debug.LogError("Some of ModuleObjectView elements hasn't been assigned.");
                continue;
            }

            int moduleAmount = 0;
            try { moduleAmount = _stage.ModuleAmounts[i]; }
            catch { Debug.LogError("Module amount index is out of range."); }

            BeginVertical();
                DisplayModulesParameters(_views[i].Type, i, moduleAmount);
            EndVertical();
        }
        LabelField("");
        SaveStageButton();
    }
    private void SaveStageButton()
    {
        BeginHorizontal();
        if (GUILayout.Button("Save stage"))
        {
            SaveController.instance = new SaveController();
            SaveController.instance.SaveStage();
        }
        if (GUILayout.Button("Load stage"))
        {
            SaveController.instance = new SaveController();
            SaveController.instance.LoadStage();
        }
        EndHorizontal();
        if (GUILayout.Button("Load Default stage"))
        {
            _rootScript.CurrentStage.SetDefault();
        }
        if (GUILayout.Button("Open save folder"))
        {
            System.Diagnostics.Process.Start($"{Application.persistentDataPath}/");
        }
    }
    private void CreateModuleButtons(int i, int moduleAmount)
    {
        LabelField("");
        BeginHorizontal();
        if (GUILayout.Button("+"))
        {
            if (moduleAmount < 20) _rootScript.OnModuleAmountChange(i, true);
            moduleAmount = Mathf.Clamp(moduleAmount + 1, 0, 20);
            _stage.ModuleAmounts[i] = moduleAmount;
        }
        else if (GUILayout.Button("-"))
        {
            if (moduleAmount > 0) _rootScript.OnModuleAmountChange(i, false);
            moduleAmount = Mathf.Clamp(moduleAmount - 1, 0, 20);
            _stage.ModuleAmounts[i] = moduleAmount;
        }
        EndHorizontal();
    }
    private void DisplayModulesParameters(ModuleType type, int moduleIndex, int amount)
    {
        string foldoutLabel = $"{type}s ({_stage.ModuleAmounts[moduleIndex]})";
        string moduleLabel;
        if (_foldoutsState[moduleIndex] = Foldout(_foldoutsState[moduleIndex], foldoutLabel))
        {
            CreateModuleButtons(moduleIndex, amount);
        
            switch (type)
            {
                case ModuleType.Absorber:
                    for (int i = 0; i < amount; i++)
                    {
                        moduleLabel = $"{type} {i + 1}";
                        LabelField(moduleLabel);
                        BeginHorizontal();
                        try 
                        { 
                            ModuleObjectView module = GameObject.Find(moduleLabel).GetComponent<ModuleObjectView>();
                            DisplayAbsorberTargetColor(module);
                            DisplayPosition(module);
                            EndHorizontal();
                        }
                        catch 
                        {
                            LabelField("Avaliable in Play."); 
                            EndHorizontal();
                        }
                    }
                    break;
                case ModuleType.Disperser:
                    for (int i = 0; i < amount; i++)
                    {
                        moduleLabel = $"{type} {i + 1}";
                        LabelField(moduleLabel);
                        try
                        {
                            ModuleObjectView module = GameObject.Find(moduleLabel).GetComponent<ModuleObjectView>();
                            DisplayPosition(module);
                        }
                        catch 
                        { 
                            LabelField("Avaliable in Play."); 
                        }
                    }
                    break;
                case ModuleType.Emitter:
                    for (int i = 0; i < amount; i++)
                    {
                        moduleLabel = $"{type} {i + 1}";
                        LabelField($"{moduleLabel}");
                        BeginHorizontal();
                        try 
                        {
                            ModuleObjectView module = GameObject.Find(moduleLabel).GetComponent<ModuleObjectView>();
                                DisplayLaserDirection(module);
                                DisplayLaserColors(module);
                            EndHorizontal();
                            BeginHorizontal();
                                DisplayPosition(module);
                            EndHorizontal();
                        }
                        catch 
                        { 
                            LabelField("Avaliable in Play."); 
                            EndHorizontal(); 
                        }
                    }
                    break;
                case ModuleType.Reflector:
                    for (int i = 0; i < amount; i++)
                    {
                        moduleLabel = $"{type} {i + 1}";
                        LabelField(moduleLabel);
                        try
                        {
                            ModuleObjectView module = GameObject.Find(moduleLabel).GetComponent<ModuleObjectView>();
                            DisplayPosition(module);
                        }
                        catch 
                        { 
                            LabelField("Avaliable in Play."); 
                        }
                    }
                    break;
                default: Debug.LogError($"There is no such ModuleType. {this}");
                    break;
            }
        }
    }
}

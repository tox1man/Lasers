using UnityEditor;
using UnityEngine;
using static UnityEditor.EditorGUILayout;
using static UnityEditor.EditorGUI;
using static ModuleGUILayout;
using static Parameters;

[CustomEditor(typeof(RootScript))]
public class RootCustomEditor : Editor
{
    private RootScript rootScript;
    private StageData stage;
    private ModuleObjectView[] views;
    private bool[] foldoutsState;
    private bool levelMakerFoldoutState = true;

    public void OnEnable()
    {
        rootScript = GetRoot();
        stage = rootScript.CurrentStage;
        views = rootScript.ModuleViews;
        foldoutsState = new bool[views.Length];
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (levelMakerFoldoutState = Foldout(levelMakerFoldoutState, "Wall Maker"))
        {
            DisplayLevelMaker();
        }

        LabelField("Modules settings", EditorStyles.boldLabel);
        for (int i = 0; i < views.Length; i++)
        {
            if (stage.ModuleAmounts == null || views[i] == null)
            {
                Debug.LogError("Some of ModuleObjectView elements hasn't been assigned.");
                //EndVertical();
                continue;
            }
            int moduleAmount = 0;
            try { moduleAmount = stage.ModuleAmounts[i]; }
            catch { Debug.LogError("Module amount index is out of range."); }

            BeginVertical();
            DisplayModulesParameters(views[i].Type, i, moduleAmount);
            EndVertical();
        }
        LabelField("");
        SaveStageButton();
    }
    private void DisplayLevelMaker()
    {
        for (int i = stage.Level.LevelSize.y - 1; i >= 0; i--)
        {
            BeginHorizontal();
            for (int j = 0; j < stage.Level.LevelSize.x; j++)
            {
                if (Application.isPlaying) 
                { 
                    Texture tex = rootScript.Level.Tiles[new Vector2Int(j, i)].Elevated ? Resources.Load<Texture>("Button.svg") : null;
                        if (GUILayout.Button(tex, GUILayout.Width(30), GUILayout.Height(30)))
                        {
                            rootScript.Level.Tiles[new Vector2Int(j, i)].Elevated = !rootScript.Level.Tiles[new Vector2Int(j, i)].Elevated;
                        }
                }
                else
                {
                    GUI.enabled = false;
                    GUILayout.Button("", GUILayout.Width(30), GUILayout.Height(30));
                    GUI.enabled = true;
                }
            }
            EndHorizontal();
        }
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
            rootScript.CurrentStage.SetDefault();
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
            if (moduleAmount < 20) rootScript.OnModuleAmountChange(i, true);
            moduleAmount = Mathf.Clamp(moduleAmount + 1, 0, 20);
            stage.ModuleAmounts[i] = moduleAmount;
        }
        else if (GUILayout.Button("-"))
        {
            if (moduleAmount > 0) rootScript.OnModuleAmountChange(i, false);
            moduleAmount = Mathf.Clamp(moduleAmount - 1, 0, 20);
            stage.ModuleAmounts[i] = moduleAmount;
        }
        EndHorizontal();
    }
    private void DisplayModulesParameters(ModuleType type, int moduleIndex, int amount)
    {
        string foldoutLabel = $"{type}s ({stage.ModuleAmounts[moduleIndex]})";
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

using System.Collections.Generic;
using UnityEngine;
using static Parameters;

public class SaveController
{
    private StageData stageData;
    private StageSaver stageSaver;
    private RootScript root;

    public static SaveController instance { get; set; }

    public SaveController()
    {
        if (instance != null)
        {
            Debug.LogWarning(this + " instance already exists. Cant make multiple instances of " + this);
        }
        instance = this;

        root = GetRoot();

        stageData = new StageData();
        stageData.SetDefault();
    }
    public void NewStage()
    {
        stageData = new StageData();
        Debug.Log("Stage " + stageData.Name + " created");
        root.CurrentStage = stageData;
    }
    public void LoadStage()
    {
        stageData = new StageData();

        string path = UnityEditor.EditorUtility.OpenFilePanel("Choose stage to load", Application.persistentDataPath, "stage");
        stageSaver = new StageSaver(path);
        stageData = stageSaver.Load();

        root.CurrentStage.Name = stageData.Name;
        root.CurrentStage.Level = stageData.Level;
        root.CurrentStage.ModuleAmounts = stageData.ModuleAmounts;

        for (int i = 0; i < stageData.Modules.Count; i++)
        {
            StageData.Module module = stageData.Modules[i];
            root.CurrentStage.Modules.Add(module);
        }
        root.CurrentStage.Modules = stageData.Modules;
        Debug.Log(root.CurrentStage.ToString());

        if (stageData == null)
        {
            Debug.LogWarning("No stage to be loaded. Loading defaults.");
            NewStage();
            return;
        }
    }
    public void SaveStage()
    {
        Debug.Log(root.CurrentStage.ToString());

        stageSaver = new StageSaver(Application.persistentDataPath, GetStage().Name + ".stage");

        stageData.Name = root.CurrentStage.Name;
        stageData.Level = root.CurrentStage.Level;

        stageData.Level.Elevations = new List<bool>(stageData.Level.LevelSize.x * stageData.Level.LevelSize.y);
        foreach (TileObjectView tile in GetLevel().Tiles.Values)
        {
            stageData.Level.Elevations.Add(tile.Elevated);
        }

        stageData.ModuleAmounts = root.CurrentStage.ModuleAmounts;
        root.CurrentStage.Modules = new List<StageData.Module>();
        foreach (ModuleObjectView viewType in root.ModuleViews)
        {
            foreach (ModuleObjectView view in GetModulesByType(viewType))
            {
                StageData.Module moduleToSave = new StageData.Module();
                moduleToSave.GetModuleFromView(view);
                root.CurrentStage.Modules.Add(moduleToSave);
            }
        }
        stageData.Modules = root.CurrentStage.Modules;

        stageSaver.Save(stageData, root.CurrentStage.Rewrite);
    }
}

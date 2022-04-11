using System.Collections.Generic;
using UnityEngine;
using static Parameters;

public class ModuleController1 : IUpdatable
{
    private RootScript root;
    private StageData stage;
    private ModuleObjectView[] moduleViews;
    private GameObject[] modulePools;
    private List<Module>[] moduleListsArray;

    public ModuleController1()
    {
        root = GetRoot();
        stage = root.CurrentStage;
        moduleViews = root.ModuleViews;
        modulePools = new GameObject[moduleViews.Length];
        moduleListsArray = new List<Module>[moduleViews.Length];

        root.ModulesAmountChanged += HandleModulesAmountChange; // ADD ON DESTROY 

        for (int i = 0; i < modulePools.Length; i++)
        {
            stage.ModuleAmounts[i] = 0;
            if (modulePools[i] == null)
            {
                modulePools[i] = CreatePool(moduleViews[i]);
            }
            if (moduleListsArray[i] == null)
            {
                moduleListsArray[i] = new List<Module>();
            }

            for (int j = 0; j < stage.Modules.Count; j++)
            {
                StageData.Module stageModule = stage.Modules[j];
                if (stageModule.Type == moduleViews[i].Type)
                {
                    ModuleObjectView moduleView = moduleViews[i];
                    moduleView.GetViewFromStageModule(stageModule);
                    moduleView.Move(stageModule.Tile);

                    if (stageModule.LaserColorsIndecies.Count > 0)
                    {
                        for (int k = 0; k < stageModule.LaserColorsIndecies.Count; k++)
                        {
                            moduleView.LaserColors.Add(LaserColors.ColorsList[stageModule.LaserColorsIndecies[k]]);
                        }
                    }
                    Module module = CreateModule(moduleView, moduleListsArray[i], modulePools[i]);
                    stage.ModuleAmounts[i]++;
                }
            }
        }
    }
    public void Update()
    {
        for (int i = 0; i < moduleListsArray.Length; i++)
        {
            UpdateModules(moduleListsArray[i]);
        }
    }
    private void UpdateModules(List<Module> modules)
    {
        foreach (Module module in modules)
        {
            module.Update();
        }
    }
    private void HandleModulesAmountChange(int viewIndex, bool addAmount)
    {
        if (addAmount) 
        {
            ModuleObjectView view = root.ModuleViews[viewIndex];
            view.SetDefault();
            CreateModule(view, moduleListsArray[viewIndex], modulePools[viewIndex]);

            StageData.Module stageModule = new StageData.Module();
            stageModule.GetModuleFromView(view);

            root.CurrentStage.Modules.Add(stageModule);
            return;
        }
        RemoveModule(moduleListsArray[viewIndex]);
        root.CurrentStage.Modules.RemoveAt(root.CurrentStage.Modules.Count-1);
    }
    private GameObject CreatePool(ModuleObjectView view)
    {
        return new GameObject(GetModuleObjectPoolName(view.Type));
    }
    private Module CreateModule(ModuleObjectView view, List<Module> moduleList, GameObject parent)
    {
        GameObject moduleObject;
        Module module = new Module(view, out moduleObject);

        moduleObject.transform.SetParent(parent.transform);
        moduleObject.name = $"{view.Type.ToString()} {parent.transform.childCount}";
        moduleList.Add(module);

        return module;
    }
    private void RemoveModule(List<Module> moduleList)
    {
        Module module = moduleList[moduleList.Count - 1];
        if (module != null)
        {
            module.DeleteGameObject();
            moduleList.Remove(module);
        }
    }
}

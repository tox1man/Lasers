using System;
using System.Collections.Generic;
using UnityEngine;

public class ModuleControllerNEW : IUpdatable
{
    private RootScript _root;
    private LevelController _level;
    private ModuleObjectView[] _moduleViews;
    private GameObject[] _modulePools;
    private List<Module>[] _moduleListsArray;

    public ModuleControllerNEW(ModuleObjectView[] moduleViews)
    {
        _root = Parameters.GetRoot();
        _level = Parameters.GetLevel();
        _moduleViews = moduleViews;
        _modulePools = new GameObject[_moduleViews.Length];
        _moduleListsArray = new List<Module>[_moduleViews.Length];

        _root.ModulesAmountChanged += HandleModulesAmountChange;

        for (int i = 0; i < _modulePools.Length; i++)
        {

            if (_modulePools[i] == null)
            {
                _modulePools[i] = CreatePool(_modulePools[i], _moduleViews[i]);
            }
            if (_moduleListsArray[i] == null)
            {
                _moduleListsArray[i] = new List<Module>();
            }

            for(int j = 0; j < _root._moduleAmounts[i]; j++)
            {
                // RANDOM POSITIONING
                CreateModule(_moduleViews[i], _moduleListsArray[i], _modulePools[i], _level.GetRandomTile().Transform.position);
            }
        }
    }

    private void HandleModulesAmountChange(int viewIndex, bool addAmount)
    {
        if (addAmount)
        {
            // RANDOM POSITIONING
            CreateModule(_moduleViews[viewIndex], _moduleListsArray[viewIndex], _modulePools[viewIndex], _level.GetRandomTile().Transform.position);
        }
        else
        {
            RemoveModule(_moduleListsArray[viewIndex]);
        }
    }

    private GameObject CreatePool(GameObject poolObject, ModuleObjectView view)
    {
        return new GameObject($"{view.Type.ToString()}'s Pool");
    }

    private void CreateModule(ModuleObjectView view, List<Module> moduleList, GameObject parent, Vector3 pos)
    {
        GameObject moduleObject;
        view.Transform.position = pos;
        Module module = new Module(view, out moduleObject);
        moduleObject.transform.SetParent(parent.transform);
        moduleObject.name = $"{view.Type.ToString()} {parent.transform.childCount}";
        moduleList.Add(module);
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

    public void Update()
    {
        for (int i = 0; i < _moduleListsArray.Length; i++)
        {
            UpdateModules(_moduleListsArray[i]);
        }
    }

    private void UpdateModules(List<Module> modules)
    {
        foreach(Module module in modules)
        {
            module.Update();
        }
    }
}

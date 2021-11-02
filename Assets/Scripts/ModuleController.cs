using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using static Parameters;
using System;

public class ModuleController : IUpdatable
{
    public bool DoUpdate { get; set; }
    public ModuleObjectView[] ModuleViews { get; private set; }
    public List<Module> EmitterList { get; private set; }
    public List<Module> AbsorberList { get; private set; }
    public List<Module> ReflectorList { get; private set; }
    public List<Module> DisperserList { get; private set; }

    private Dictionary<Vector2Int, TileObjectView> _tiles;
    private RootScript _root;

    private GameObject _emittersPool;
    private GameObject _absorbersPool;
    private GameObject _reflectorsPool;
    private GameObject _dispersersPool;
    public ModuleController(ModuleObjectView[] moduleViews)
    {
        _root = GetRoot();
        _tiles = GameObject.Find(Parameters.ROOT_OBJECT_NAME).GetComponent<RootScript>()._level.Tiles;

        ModuleViews = moduleViews;

        //EmitterList   = new List<Module>(_root.EmittersAmount);
        //AbsorberList  = new List<Module>(_root.AbsorbersAmount);
        //ReflectorList = new List<Module>(_root.ReflectorsAmount);
        //DisperserList = new List<Module>(_root.DispersersAmount);

        CreateModulesPools();

        //_root.ModulesAmountChanged += HandleModulesChange;
    }
    private void HandleModulesChange(string fieldName)
    {
        var rootField = typeof(RootScript).GetField(fieldName);
        int targetValue = (int)rootField.GetValue(_root);
        List<Module> moduleList;

        switch (fieldName)
        {
            case "EmittersAmount":
                moduleList = EmitterList;
                if(moduleList.Count < targetValue)
                {
                    CreateEmitter();
                }
                else if(moduleList.Count > targetValue)
                {
                    RemoveEmitter(EmitterList);
                }
                else
                {
                    Debug.LogError($"Target value is equal to module list count. {this}.{nameof(HandleModulesChange)}");
                }
                break;
            case "AbsorbersAmount":
                moduleList = AbsorberList;
                if (moduleList.Count < targetValue)
                {
                    CreateAbsorber();
                }
                else if (moduleList.Count > targetValue)
                {
                    RemoveAbsorber(moduleList);
                }
                else
                {
                    Debug.LogError($"Target value is equal to module list count. {this}.{nameof(HandleModulesChange)}");
                }
                break;
            case "ReflectorsAmount":
                moduleList = ReflectorList;
                if (moduleList.Count < targetValue)
                {
                    CreateReflector();
                }
                else if (moduleList.Count > targetValue)
                {
                    RemoveReflector(moduleList);
                }
                else
                {
                    Debug.LogError($"Target value is equal to module list count. {this}.{nameof(HandleModulesChange)}");
                }
                break;
            case "DispersersAmount":
                moduleList = DisperserList;
                if (moduleList.Count < targetValue)
                {
                    CreateDisperser();
                }
                else if (moduleList.Count > targetValue)
                {
                    RemoveDisperser(moduleList);
                }
                else
                {
                    Debug.LogError($"Target value is equal to module list count. {this}.{nameof(HandleModulesChange)}");
                }
                break;
            default:
                Debug.LogError($"Unknown field name ({fieldName}). {this}.");
                return;
        }

        if (moduleList.Count < targetValue)
        {
            //AddModule(moduleType, parent);
        }
        else if (moduleList.Count > targetValue)
        {
            RemoveEmitter(moduleList);
        }
    }

    private void RemoveAbsorber(List<Module> moduleList)
    {
        throw new NotImplementedException();
    }

    private void RemoveReflector(List<Module> moduleList)
    {
        throw new NotImplementedException();
    }

    private void RemoveDisperser(List<Module> moduleList)
    {
        throw new NotImplementedException();
    }

    private EmitterView CreateEmitter()
    {
        GameObject emitter = GameObject.Instantiate(ModuleViews.FirstOrDefault(x => x.Type == ModuleType.Emitter).gameObject, _emittersPool.transform);
        EmitterView view = emitter.GetComponent<EmitterView>();
        
        return view;
    }    
    private AbsorberView CreateAbsorber()
    {
        GameObject absorber = GameObject.Instantiate(ModuleViews.FirstOrDefault(x => x.Type == ModuleType.Absorber).gameObject, _absorbersPool.transform);
        AbsorberView view = absorber.GetComponent<AbsorberView>();
        

        return view;
    }    
    private ReflectorView CreateReflector()
    {
        GameObject reflector = GameObject.Instantiate(ModuleViews.FirstOrDefault(x => x.Type == ModuleType.Reflector).gameObject, _reflectorsPool.transform);
        ReflectorView view = reflector.GetComponent<ReflectorView>();
        

        return view;
    }    
    private DisperserView CreateDisperser()
    {
        GameObject disperser = GameObject.Instantiate(ModuleViews.FirstOrDefault(x => x.Type == ModuleType.Disperser).gameObject, _dispersersPool.transform);
        DisperserView view = disperser.GetComponent<DisperserView>();
        

        return view;
    }

    private void AddModule(ModuleType type, ModuleObjectView moduleViewsList, Transform parent)
    {
        GameObject module;
        List<Module> listToAddTo;
        switch (type)
        {
            case ModuleType.Absorber:
                listToAddTo = AbsorberList;
                break;
            case ModuleType.Emitter:
                listToAddTo = EmitterList;
                break;
            case ModuleType.Reflector:
                listToAddTo = ReflectorList;
                break;
            case ModuleType.Disperser:
                listToAddTo = DisperserList;
                break;
            default:
                listToAddTo = null;
                Debug.LogError($"No such list to add module to. {this}.{nameof(AddModule)}");
                break;
        }

        //Vector3 tilePos = new Vector3(startTile.Transform.position.x, 25f, startTile.Transform.position.z); // CHANGE Y POS
        //string moduleName = $"{moduleView.Type.ToString()} {listToAddTo.Count}";
        //listToAddTo.Add(new Module(type, out module));

        //module.transform.SetParent(parent);
    }
    private void RemoveEmitter(List<Module> moduleList)
    {
        var module = moduleList[moduleList.Count - 1];
        var moduleGO = module.View.gameObject;
        moduleList.RemoveAt(moduleList.Count - 1);
        GameObject.Destroy(moduleGO);
    }

    public void Update()
    {
        foreach(Module emitter in EmitterList)
        {
            if (emitter != null && emitter.View)
            {
                emitter.Update();
            }
        }
        foreach(Module absorber in AbsorberList)
        {
            if (absorber != null && absorber.View)
            {
                absorber.Update();
            }
        }
        foreach(Module disperser in DisperserList)
        {
            if (disperser != null && disperser.View)
            {
                disperser.Update();
            }
        }
        foreach(Module reflector in ReflectorList)
        {
            if (reflector != null && reflector.View)
            {
                reflector.Update();
            }
        }
    }
    private void CreateModulesPools()
    {
        // Create module container object on the scene.
        _emittersPool = new GameObject(Parameters.EMITTER_POOL_OBJECT_NAME);
        _absorbersPool = new GameObject(Parameters.ABSORBER_POOL_OBJECT_NAME);
        _reflectorsPool = new GameObject(Parameters.REFLECTOR_POOL_OBJECT_NAME);
        _dispersersPool = new GameObject(Parameters.DISPERSER_POOL_OBJECT_NAME);

        //// Fill list with scripts that will create their own gameObjects.
        //for (int i = 0; i < _root.EmittersAmount; i++)
        //{
        //    AddModule(ModuleType.Emitter, ModuleViews.FirstOrDefault(x => x.Type == ModuleType.Emitter), _emittersPool.transform);
        //}        
        //for (int i = 0; i < _root.AbsorbersAmount; i++)
        //{
        //    AddModule(ModuleType.Absorber, ModuleViews.FirstOrDefault(x => x.Type == ModuleType.Absorber), _absorbersPool.transform);
        //}        
        //for (int i = 0; i < _root.ReflectorsAmount; i++)
        //{
        //    AddModule(ModuleType.Reflector, ModuleViews.FirstOrDefault(x => x.Type == ModuleType.Reflector), _reflectorsPool.transform);
        //}        
        //for (int i = 0; i < _root.DispersersAmount; i++)
        //{
        //    AddModule(ModuleType.Disperser, ModuleViews.FirstOrDefault(x => x.Type == ModuleType.Disperser), _dispersersPool.transform);
        //}
    }
}
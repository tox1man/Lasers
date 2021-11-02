using System.Collections.Generic;
using UnityEngine;
public class MainController
{
    private List<IUpdatable> _controllersUpdatable;
    private List<IFixedUpdatable> _controllersFixedUpdatable;

    private Player _playerController;
    private InputController _inputController;
    private ModuleControllerNEW _moduleController;

    private ModuleObjectView[] _moduleViews;

    public void Start()
    {
        _moduleViews = GameObject.Find(Parameters.ROOT_OBJECT_NAME).GetComponent<RootScript>()._moduleViews;

        _controllersUpdatable = new List<IUpdatable>();
        _controllersFixedUpdatable = new List<IFixedUpdatable>();
        LoadControllers();
    }

    public void Update()
    {
        UpdateControllers();
    }

    public void FixedUpdate()
    {
        FixedUpdateControllers();
    }

    public void OnDestroy()
    {
        _controllersUpdatable.Clear();
        _controllersFixedUpdatable.Clear();
    }

    private void LoadControllers()
    {
        _inputController = new InputController();
        AddController(_inputController);

        _moduleController = new ModuleControllerNEW(_moduleViews);
        AddController(_moduleController);
    }

    private void UpdateControllers()
    {
        foreach (IUpdatable controller in _controllersUpdatable)
        {
            if(controller != null)
            {
                controller.Update();
            }
        }
    }

    private void FixedUpdateControllers()
    {
        foreach (IFixedUpdatable controller in _controllersFixedUpdatable)
        {
            if (controller != null)
            {
                controller.FixedUpdate();
            }
        }
    }

    public void AddController(IUpdatable controller)
    {
        _controllersUpdatable.Add(controller);
    }

    private void RemoveController(IUpdatable controller)
    {
        _controllersUpdatable.Remove(controller);
    }
    public void AddFixedController(IFixedUpdatable fixedController)
    {
        _controllersFixedUpdatable.Add(fixedController);
    }

    private void RemoveFixedController(IFixedUpdatable fixedController)
    {
        _controllersFixedUpdatable.Remove(fixedController);
    }
}

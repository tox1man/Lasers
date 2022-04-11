using System.Collections.Generic;
using static Parameters;
public class MainController
{
    private List<IUpdatable> _controllersUpdatable;
    private List<IFixedUpdatable> _controllersFixedUpdatable;

    private RootScript _root;

    private InputController _inputController;
    private ModuleController1 _moduleController;
    private GoalController _goalController;

    private ModuleObjectView[] _moduleViews;

    public void Start()
    {
        _root = GetRoot();
        _moduleViews = _root.GetComponent<RootScript>().ModuleViews;

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
        // TODO - USE SINGLETONS LIKE IN SAVECONTROLLER?

        //_inputController = new InputController();
        //AddController(_inputController);

        _moduleController = new ModuleController1();
        AddController(_moduleController);

        _goalController = new GoalController();
        _root.GoalController = _goalController;
        AddController(_goalController);

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

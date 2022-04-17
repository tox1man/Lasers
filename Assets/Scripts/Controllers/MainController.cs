using System.Collections.Generic;
public class MainController
{
    private List<IUpdatable> controllersUpdatable;
    private List<IFixedUpdatable> controllersFixedUpdatable;

    //private InputController inputController;
    private CameraController cameraController;
    private ModuleController moduleController;
    private GoalController goalController;
    private SaveController saveController;

    public void Start()
    {
        controllersUpdatable = new List<IUpdatable>();
        controllersFixedUpdatable = new List<IFixedUpdatable>();
        LoadControllers();
    }
    private void LoadControllers()
    {
        // TODO - USE SINGLETONS LIKE IN SAVECONTROLLER?

        //_inputController = new InputController();
        //AddController(_inputController);

        moduleController = new ModuleController();
        AddController(moduleController);

        goalController = new GoalController();
        AddController(goalController);

        cameraController = new CameraController();
        AddController(cameraController);

        saveController = new SaveController();
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
        controllersUpdatable.Clear();
        controllersFixedUpdatable.Clear();
    }
    public void AddController(IUpdatable controller)
    {
        controllersUpdatable.Add(controller);
    }
    public void AddFixedController(IFixedUpdatable fixedController)
    {
        controllersFixedUpdatable.Add(fixedController);
    }

    private void UpdateControllers()
    {
        foreach (IUpdatable controller in controllersUpdatable)
        {
            if(controller != null)
            {
                controller.Update();
            }
        }
    }
    private void FixedUpdateControllers()
    {
        foreach (IFixedUpdatable controller in controllersFixedUpdatable)
        {
            if (controller != null)
            {
                controller.FixedUpdate();
            }
        }
    }
    private void RemoveController(IUpdatable controller)
    {
        controllersUpdatable.Remove(controller);
    }
    private void RemoveFixedController(IFixedUpdatable fixedController)
    {
        controllersFixedUpdatable.Remove(fixedController);
    }
}

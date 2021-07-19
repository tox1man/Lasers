using System.Collections.Generic;
using UnityEngine;
public class MainController
{
    private List<IUpdatable> _controllersUpdatable;
    private List<IFixedUpdatable> _controllersFixedUpdatable;

    private PlayerController _playerController;
    private InputController _inputController;
    //private EnemyController _enemyController;

    private readonly GameObjectView _playerView;

    public MainController(GameObjectView playerView)
    {
        _playerView = playerView;
    }
    public void Start()
    {
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

        _playerController = new PlayerController(_playerView, _inputController);
        AddController(_playerController);
        AddFixedController(_playerController);

    }

    private void UpdateControllers()
    {
        foreach (IUpdatable controller in _controllersUpdatable)
        {
            controller.Update();
        }
    }

    private void FixedUpdateControllers()
    {
        foreach (IFixedUpdatable controller in _controllersFixedUpdatable)
        {
            controller.FixedUpdate();
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

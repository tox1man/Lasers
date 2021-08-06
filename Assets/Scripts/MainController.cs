using System.Collections.Generic;
using UnityEngine;
public class MainController
{
    private List<IUpdatable> _controllersUpdatable;
    private List<IFixedUpdatable> _controllersFixedUpdatable;

    private Player _playerController;
    private InputController _inputController;
    private EnemyController _enemyController;
    private DamageController _damageController;

    private readonly GameObjectView _playerView;
    private readonly GameObjectView _enemyView;

    public MainController(GameObjectView playerView, GameObjectView enemyView)
    {
        _playerView = playerView;
        _enemyView = enemyView;
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

        _playerController = new Player(_playerView, _inputController, new Vector3(0f, 2f, 0f));
        AddController(_playerController);
        AddFixedController(_playerController);

        _enemyController = new EnemyController(_enemyView);
        AddController(_enemyController);

        foreach (Enemy enemy in _enemyController.EnemyArray)
        {
            AddController(enemy);
            AddFixedController(enemy);
        }

        _damageController = new DamageController();
    }

    private void UpdateControllers()
    {
        foreach (IUpdatable controller in _controllersUpdatable)
        {
            //if(controller.DoUpdate) 
            //{
                controller.Update();
            //}
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
        //controller.DoUpdate = true;
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

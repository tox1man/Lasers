using UnityEngine;
public class Enemy : IUpdatable, IFixedUpdatable
{
    public EnemyObjectView View { get; private set; }

    private GameObject _enemyGameObject;
    private ShootingController<EnemyObjectView> _shootingController;

    public Enemy(GameObject enemyPrefab, Vector3 position, out GameObject _enemyGameObject, string name)
    {
        _enemyGameObject = CreateEnemyGameobject(enemyPrefab, position, name);
        _shootingController = new ShootingController<EnemyObjectView>(View);
    }

    private GameObject CreateEnemyGameobject(GameObject enemyPrefab, Vector3 position, string name)
    {
        _enemyGameObject = GameObject.Instantiate(enemyPrefab, position, Quaternion.identity);
        _enemyGameObject.name = name;
        View = _enemyGameObject.GetComponent<EnemyObjectView>();
        return _enemyGameObject;
    }

    public void Update()
    {
        if (!View.IsActive)
        {
            return;
        }

        View.CheckHealth();
        _shootingController.Update();
    }

    public void FixedUpdate()
    {
        if (!View.IsActive)
        {
            return;
        }

        //MOVEMENT

        _shootingController.FixedUpdate();
    }
}
using UnityEngine;
public class Enemy : IUpdatable, IFixedUpdatable
{
    public GameObjectView View { get; private set; }

    private bool _doUpdate = true;
    private GameObject _enemyGameObject;
    private ShootingController _shootingController;


    public Enemy(GameObject enemyPrefab, Vector3 position, out GameObject _enemyGameObject, string name)
    {
        _enemyGameObject = CreateEnemyGameobject(enemyPrefab, position, name);
        _shootingController = new ShootingController(View);
    }

    private GameObject CreateEnemyGameobject(GameObject enemyPrefab, Vector3 position, string name)
    {
        _enemyGameObject = GameObject.Instantiate(enemyPrefab, position, Quaternion.identity);
        _enemyGameObject.name = name;
        View = _enemyGameObject.GetComponent<GameObjectView>();
        return _enemyGameObject;
    }

    public void Update()
    {
        if (!_enemyGameObject.activeSelf || !_doUpdate)
        {
            return;
        }

        if(!IsAlive())
        {
            Kill();
        }
        _shootingController.Update();
    }

    public void FixedUpdate()
    {
        if (!_enemyGameObject.activeSelf || !_doUpdate)
        {
            return;
        }

        //MOVEMENT

        _shootingController.FixedUpdate();
    }

    private bool IsAlive()
    {
        return View.Health > 0;
    }

    private void Kill()
    {
        View.gameObject.SetActive(false);
        _doUpdate = false;
    }
}
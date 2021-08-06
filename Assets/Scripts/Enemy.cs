using UnityEngine;
public class Enemy : IUpdatable, IFixedUpdatable
{
    public GameObjectView View { get; private set; }
    public bool doUpdate { get => true; set => doUpdate = value; } 

    private GameObject _enemyGameObject;


    public Enemy(GameObject enemyPrefab, Vector3 position, out GameObject _enemyGameObject)
    {
        _enemyGameObject = CreateEnemyGameobject(enemyPrefab, position);
    }

    private GameObject CreateEnemyGameobject(GameObject enemyPrefab, Vector3 position)
    {
        _enemyGameObject = GameObject.Instantiate(enemyPrefab, position, Quaternion.identity);
        View = _enemyGameObject.GetComponent<GameObjectView>();
        return _enemyGameObject;
    }

    public void Update()
    {
        if(!IsAlive())
        {
            Kill();
        }
    }

    public void FixedUpdate()
    {
        //MOVEMENT
    }

    private bool IsAlive()
    {
        return View.Health > 0;
    }

    private void Kill()
    {
        View.gameObject.SetActive(false);
    }
}
using UnityEngine;

public class EnemyController : IUpdatable
{
    public bool DoUpdate { get; set; }
    public GameObjectView EnemyView { get; private set; }
    public Enemy[] EnemyArray { get; private set; }
    private GameObject _enemyPool;
    public EnemyController(GameObjectView enemyView)
    {
        EnemyView = enemyView;
        EnemyArray = new Enemy[Parameters.ENEMY_NUMBER];
        CreateEnemyPool();
    }
    public void Update()
    {
        
    }

    private void CreateEnemyPool()
    {
        // Create enemies container object on the scene.
        _enemyPool = new GameObject(Parameters.ENEMY_POOL_OBJECT_NAME);

        // Fill enemy array with enemy scripts that will instantiate their own enemy gameObjects.
        for (int i = 0; i < EnemyArray.Length; i++)
        {
            GameObject enemy;
            string enemyName = $"{Parameters.ENEMY_TAG} {i}";
            EnemyArray[i] = new Enemy(EnemyView.ObjectPrefab, GetRandomPosition(), out enemy, enemyName);

            enemy.tag = Parameters.ENEMY_TAG;
            enemy.transform.SetParent(_enemyPool.transform);
        }
    }


    private Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-10f, 10f), 2f, Random.Range(-10f, 10f));
    }
}
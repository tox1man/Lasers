using System.Collections.Generic;
using UnityEngine;

public class ShootingController : IUpdatable, IFixedUpdatable
{
    public GameObjectView View { get; private set; }
    private BulletController _bulletController;

    private Rigidbody _viewRidigbody;

    private List<GameObject> _bullets;
    private List<Ray> _enemyHits;

    private GameObject _bulletsObjectInstance;
    private GameObject bulletPrefab;

    public ShootingController(GameObjectView view)
    {
        _bullets = new List<GameObject>(Utility.BULLET_POOL_CAPACITY);
        _bulletController = new BulletController(_bullets);
        _enemyHits = new List<Ray>();

        View = view;
        _viewRidigbody = View.GetComponent<Rigidbody>();

        CreateBulletsContainer();
    }

    private void CreateBulletsContainer()
    {
        bulletPrefab = View.BulletPrefab;
        _bulletsObjectInstance = new GameObject(Utility.BULLET_CONTATINER_OBJECT_NAME);
    }

    private Rigidbody CreateBullet()
    {
        var tempBullet = GameObject.Instantiate(bulletPrefab, _bulletsObjectInstance.transform);
        var bulletPosition = View.transform.Find(Utility.BARREL_OBJECT_NAME).transform.position;
        var bulletRigidbody = tempBullet.GetComponent<Rigidbody>();

        tempBullet.transform.position = bulletPosition;
        bulletRigidbody.angularDrag = Utility.BULLET_ANGULAR_DRAG;
        bulletRigidbody.drag = Utility.BULLET_DRAG;
        _bullets.Add(tempBullet);

        return tempBullet.GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (_viewRidigbody.velocity == Vector3.zero)
        {
            if (SearchEnemy(Utility.PLAYER_FOV, Utility.FOV_RAYCAST_STEP, Utility.FOV_RAYCAST_MAXDISTANCE))
            {
                int rayIndex = Mathf.RoundToInt(UnityEngine.Random.Range(0, _enemyHits.Count));
                Shoot(_enemyHits[rayIndex]);
            }
        }
    }
    public void FixedUpdate()
    {
       _bulletController.FixedUpdate();
    }

    /// <summary>
    /// Returns if enemy is inside cone-shaped area with given parameters.
    /// </summary>
    /// <param name="angleInDeg">Cone diameter in degrees.</param>
    /// <param name="stepSizeInDeg">Interval between rays cast.</param>
    /// <param name="maxRayDistance">Maximum ray magnitude.</param>
    /// <returns></returns>
    private bool SearchEnemy(int angleInDeg, float stepSizeInDeg, int maxRayDistance)
    {
        Vector3 origin = View.transform.position;
        RaycastHit hit;
        Vector3 forwardDir;

        _enemyHits.Clear();

        for (int i = -angleInDeg / 2; i <= angleInDeg / 2; i += (int)stepSizeInDeg)
        {
            forwardDir = View.gameObject.transform.forward;

            Quaternion rayRotation = Quaternion.Euler(0f, i, 0f);
            Vector3 rayDirection = rayRotation * forwardDir;

            Debug.DrawRay(origin, rayDirection.normalized * 10, Color.cyan); ///////////////////////////////////////////////////

            if (Physics.Raycast(origin, rayDirection, out hit, maxRayDistance))
            {
                if (hit.collider.gameObject.CompareTag(Utility.ENEMY_TAG))
                {
                    _enemyHits.Add(new Ray(origin, rayDirection));
                }
            }
        }
        return _enemyHits.Count > 0;
    }

    private void Shoot(Ray shootRay)
    {
        Debug.DrawRay(shootRay.origin, shootRay.direction.normalized * Utility.FOV_RAYCAST_MAXDISTANCE, Color.red); ///////////////////////////
        var bullet = CreateBullet();
        bullet.AddForce(shootRay.direction * Utility.BULLET_SHOOT_VELOCITY, ForceMode.Impulse);
    }

}

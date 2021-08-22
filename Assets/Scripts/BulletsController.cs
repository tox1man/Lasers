using UnityEngine;

public class BulletsController : IFixedUpdatable
{
    public Rigidbody[] Bullets { get; private set; }
    private GameObjectView _parentObjectView;

    public delegate void HitAction(Collider other, int damageAmount);
    public static event HitAction OnEnemyHit;

    public BulletsController(Rigidbody[] bullets, GameObjectView parentObjectView)
    {
        Bullets = bullets;
        _parentObjectView = parentObjectView;
    }

    public void FixedUpdate()
    {
        foreach (Rigidbody bullet in Bullets)
        {
            if (bullet != null && bullet.gameObject.activeSelf)
            {
                CheckBulletCollision(bullet);
                CheckBulletDistance(bullet);
            }
        }
    }

    /// <summary>
    /// Checks if bullet is out of render boundaries. If it is - disables it.
    /// </summary>
    /// <param name="bullet"></param>
    private void CheckBulletDistance(Rigidbody bullet)
    {
        var bulletPosition = bullet.transform.position;
        if (bulletPosition.sqrMagnitude > Parameters.MAX_RENDER_DIST_SQR || bulletPosition.y < Parameters.MAX_RENDER_Y_DIST)
        {
            DisableBullet(bullet.gameObject);
        }
    }

    /// <summary>
    /// Checks if bullet is colliding with an enemy. If it is - hits enemy.
    /// </summary>
    /// <param name="bullet"></param>
    private void CheckBulletCollision(Rigidbody bullet)
    {
        LayerMask collisionMask = LayerMask.GetMask("Default");
        Collider[] collidersArray = Physics.OverlapBox(bullet.gameObject.transform.position, bullet.gameObject.transform.localScale / 2, Quaternion.identity, collisionMask);

        if (bullet.gameObject.activeSelf && collidersArray.Length > 0)
        {
            for (int i = 0; i < collidersArray.Length; i++)
            {
                AgentObjectView tempView;
                var collider = collidersArray[i];
                if (collider.TryGetComponent<AgentObjectView>(out tempView) && tempView.Damagable)
                {
                    OnEnemyHit?.Invoke(collidersArray[i], 10);
                    DisableBullet(bullet.gameObject);
                }
            }
        }
    }

    private void DisableBullet(GameObject bullet)
    {
        bullet.SetActive(false);
    }
}
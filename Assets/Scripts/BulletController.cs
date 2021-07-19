using UnityEngine;
using System.Collections.Generic;
using System;

public class BulletController : IFixedUpdatable
{
    public List<GameObject> Bullets { get; private set; }
    public delegate void HitHandler(int damageAmount);
    public event HitHandler OnEnemyHit;

    public BulletController(List<GameObject> bullets)
    {
        Bullets = bullets;
        //OnEnemyHit += DamageController.DamageEnemy(GameObject enemy, int damage);
    }

    /// <summary>
    /// /////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// <param name="dmg"></param>
    private void DamageEnemy(int dmg)
    {
        Debug.Log($"Enemy hit for {dmg} dmg.");
    }

    public void FixedUpdate()
    {
        foreach (GameObject bullet in Bullets)
        {
            CheckBulletCollision(bullet);
        }
    }

    private void CheckBulletCollision(GameObject bullet)
    {
        Collider[] colliders = Physics.OverlapBox(bullet.gameObject.transform.position, bullet.gameObject.transform.localScale / 2);
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject.CompareTag(Utility.ENEMY_TAG))
                {
                    //OnEnemyHit?.Invoke(10);
                    //Bullets.Remove(bullet);
                    //DestroyBullet(bullet);
                    //Damage();
                }
            }
        }
    }

    private void DestroyBullet(GameObject bullet)
    {
        GameObject.Destroy(bullet);
    }

    public void OnDestroy()
    {

    }
}
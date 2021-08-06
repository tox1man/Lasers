using UnityEngine;
public class DamageController
{
    public DamageController()
    {
        BulletsController.OnEnemyHit += DamageEnemy;
    }

    /// <summary>
    /// /////////////////////////////////////////////////////////////////////////
    /// </summary>
    /// <param name="dmg"></param>
    public void DamageEnemy(Collider targetCollider, int dmg)
    {
        var target = targetCollider.gameObject.GetComponent<GameObjectView>();
        target.Health = Mathf.Max(0, target.Health - dmg);
        Debug.Log($"{targetCollider.gameObject.name} hit for {dmg} dmg. {target.Health} HP left.");
    }
}

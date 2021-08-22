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
        if (targetCollider != null)
        {
            AgentObjectView target;
            if (targetCollider.gameObject.TryGetComponent<AgentObjectView>(out target))
            {
                target.Health = Mathf.Max(0, target.Health - dmg);
                //Debug.Log($"{targetCollider.gameObject.name} hit for {dmg} dmg. {target.Health} HP left.");
            }
        }
        else
        {
            Debug.LogError($"Target for inflicting damage is null. {this}");
        }
    }
}

using UnityEngine;

public class GameObjectView : MonoBehaviour
{
    public GameObject ObjectPrefab;
    public Transform Transform;
    public GameObject BulletPrefab;

    [Header("Object parameters")]
    public int Health;
    public int Damage;                  // Amount of damage every bullet deals.
    public int Ammo;                    // Amount of availiable bullets.
    public float ShootingRate = 5f;     // Number of shots per second.
    public float Speed;                 // Speed at which object moves.
    public float RotationSpeed;         // Speed at which object rotates.
}

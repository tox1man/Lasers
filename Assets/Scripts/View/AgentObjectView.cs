using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class AgentObjectView : GameObjectView
{
    [HideInInspector] public Rigidbody ViewRigidbody;
    public GameObject BulletPrefab;
    public bool IsAlive { get => Health > 0; set => IsAlive = value; }

    [Header("Object parameters")]
    public int MaxHealth;               // Max health
    public int Health;                  // Current health
    public int Damage;                  // Amount of damage every bullet deals.
    public int Ammo;                    // Amount of availiable bullets.
    public float ShootingRate = 5f;     // Number of shots per second.
    public float Speed;                 // Speed at which object moves.
    public float RotationSpeed;         // Speed at which object rotates.

    public void Start()
    {
        Health = MaxHealth;
        ViewRigidbody = GetComponent<Rigidbody>();
    }
    public void CheckHealth()
    {
        if (!IsAlive)
        {
            SetActive(false);
        }
    }

    /// <summary>
    /// Moves this agent in direction.
    /// </summary>
    /// <param name="direction">Direction to move towerds.</param>
    public void Move(Vector3 direction)
    {
        ViewRigidbody.velocity = direction.normalized * Speed * Time.fixedDeltaTime;
    }

    /// <summary>
    /// Performs gradual rotation towards target direction.
    /// </summary>
    /// <param name="direction">Direction to rotate towards.</param>
    public void Rotate(Vector3 direction)
    {
        Quaternion currentRotation = transform.rotation.normalized;
        if (direction.normalized != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction.normalized);

            if (currentRotation != targetRotation)
            {
                transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, RotationSpeed);
            }
        }
    }
}

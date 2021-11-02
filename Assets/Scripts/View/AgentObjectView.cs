using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class AgentObjectView : GameObjectView
{
    public GameObject BulletPrefab;
    public bool IsAlive { get => Health > 0; set => IsAlive = value; }


    [Header("Object parameters")]

    [Tooltip("Maximum health")] 
    public int MaxHealth;     
    
    [Tooltip("Current health")] 
    public int Health;    
    
    [Tooltip("Amount of damage every bullet deals.")] 
    public int Damage;  
    
    [Tooltip("Amount of availiable bullets.")] 
    public int Ammo;   
    
    [Tooltip("Number of shots per second.")] 
    public float ShootingRate = 5f;      
    
    [Tooltip("Speed at which object moves.")] 
    [Range(1f, 10f)] public float Speed;   
        

    public void Start()
    {
        Health = MaxHealth;
    }
    public void CheckHealth()
    {
        if (!IsAlive)
        {
            SetActive(false);
        }
    }
}

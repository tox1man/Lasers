using System.Collections.Generic;
using UnityEngine;

public class GameObjectView : MonoBehaviour
{
    public GameObject ObjectPrefab;
    public Transform Transform;
    public GameObject BulletPrefab;
    [Header("Object parameters")]
    public int Health;
    public int Damage;
    public float Speed;
    public float RotationSpeed;
}

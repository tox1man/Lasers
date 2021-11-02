using System.Collections.Generic;
using UnityEngine;

public class GameObjectView : MonoBehaviour
{

    [Header("Object View Parameters")]
    public GameObject ObjectPrefab;
    public Transform Transform;
    public bool IsActive { get => gameObject.activeSelf && DoUpdate; set => IsActive = value; }
    public bool Damagable = false;
    public bool DoUpdate = true;
    public bool DoAnimate = false;
    public KeyValuePair<Vector2Int, TileObjectView> CurrentTile { get; private set; }
        
    [Tooltip("Speed at which object rotates.")] 
    [Range(1f, 10f)] public float RotationSpeed; 

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
        DoUpdate = value;
    }

    /// <summary>
    /// Moves this agent in direction.
    /// </summary>
    /// <param name="direction">Direction to move towards.</param>
    //public void Move(Vector3 direction)
    //{
    //    Transform.position = new Vector3(direction.x, Transform.position.y, direction.z);
    //}
    //public void Move(KeyValuePair<Vector2Int, TileObjectView> kvp)
    //{
    //    CurrentTile = kvp;
    //    Move(CurrentTile.Value.Transform.position);
    //}

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

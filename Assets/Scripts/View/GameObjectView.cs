using UnityEngine;
using static Parameters;

public class GameObjectView : MonoBehaviour
{
    [Header("Object View Parameters")]
    public GameObject ObjectPrefab;
    public Transform Transform;
    public Canvas UICanvas;
    public bool IsActive { get => gameObject.activeSelf && DoUpdate; set => IsActive = value; }
    public bool DoUpdate = true;
    public bool DoAnimate;
    public bool Selected { get; set; }
    [HideInInspector] public Vector2Int Tile;

    //public bool Damagable = false;
    //[Tooltip("Speed at which object rotates.")] 
    //[Range(1f, 10f)] public float RotationSpeed; 
    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
        DoUpdate = value;
    }
    /// <summary>
    /// Moves this agent in direction.
    /// </summary>
    /// <param name="pos">Direction to move towards.</param>
    private void Move(Vector3 pos)
    {
        Transform.position = new Vector3(pos.x, Transform.position.y, pos.z);
    }
    public void Move(Vector2Int tilePos)
    {
        TileObjectView tile = GetLevel().Tiles[tilePos];
        Move(tile.Transform.position);
        Tile = tilePos;
    }
    public void Select(GameObjectView view)
    {
        //Debug.Log($"{view.gameObject.name}, {this.gameObject.name}");
        if (view != this) return;
        Selected = true;
        Light halo = this.GetComponent<Light>();
        halo.enabled = true;
    }
    public void Deselect(GameObjectView view)
    {
        if (view != this) return;
        Selected = false;
        Light halo = this.GetComponent<Light>();
        halo.enabled = false;
    }
    /// <summary>
    /// Performs gradual rotation towards target direction.
    /// </summary>
    /// <param name="direction">Direction to rotate towards.</param>
    //public void RotateTowards(Vector3 direction)
    //{
    //    Quaternion currentRotation = transform.rotation.normalized;
    //    if (direction.normalized != Vector3.zero)
    //    {
    //        Quaternion targetRotation = Quaternion.LookRotation(direction.normalized);

    //        if (currentRotation != targetRotation)
    //        {
    //            transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, 10f);
    //        }
    //    }
    //}
}

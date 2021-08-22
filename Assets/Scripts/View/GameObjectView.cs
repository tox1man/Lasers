using UnityEngine;

public class GameObjectView : MonoBehaviour
{
    public bool IsActive { get => gameObject.activeSelf && DoUpdate; set => IsActive = value; }
    public bool Damagable = false;
    public bool DoUpdate = true;
    public bool DoAnimate = false;
    public GameObject ObjectPrefab;
    public Transform Transform;

    public void SetActive(bool value)
    {
        gameObject.SetActive(value);
        DoUpdate = value;
    }
}

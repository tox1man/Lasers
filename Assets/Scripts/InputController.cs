using UnityEngine;

public class InputController : IUpdatable
{
    public bool DoUpdate { get; set; }
    private float _speedX;
    private float _speedZ;

    private Vector3 _direction = Vector3.zero;
    private Vector3 _lastDirection;
    public Vector3 Direction { get => _direction; }
    public Vector3 LastDirection { get => _lastDirection; set => _lastDirection = value; }

    public void Update()
    {
        _speedX = Input.GetAxisRaw("Horizontal");
        _speedZ = Input.GetAxisRaw("Vertical");

        _direction = new Vector3(_speedX, 0f, _speedZ).normalized;
    }
}

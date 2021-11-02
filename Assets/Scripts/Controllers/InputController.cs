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
        _direction = Vector3.zero;
        _speedX = 0f;
        _speedZ = 0f;
        
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            _speedX = Input.GetAxisRaw("Horizontal");
        }
        else if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            _speedZ = Input.GetAxisRaw("Vertical");
        }

        _direction = Mathf.Abs(_speedX) > 0.5f || Mathf.Abs(_speedZ) > 0.5f ? new Vector3(_speedX, 0f, _speedZ).normalized : Vector3.zero;
    }
}

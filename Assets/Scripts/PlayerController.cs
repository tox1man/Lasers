using UnityEngine;

public class PlayerController : IUpdatable, IFixedUpdatable
{
    private GameObjectView _playerView;
    private InputController _inputController;
    private ShootingController _shootingController;
    private Rigidbody _playerRigidbody;

    public PlayerController(GameObjectView playerView, InputController inputController)
    {
        _inputController = inputController;
        _playerView = playerView;
        _playerRigidbody = _playerView.GetComponent<Rigidbody>();

        _shootingController = new ShootingController(_playerView);
    }

    public void Update()
    {
       _shootingController.Update();
    }

    public void FixedUpdate()
    {
        if (_playerRigidbody.velocity != Vector3.zero)
        {
            if(_inputController.Direction != Vector3.zero)
            {
                _inputController.LastDirection = _inputController.Direction;
            }
        }
        RotatePlayer(_inputController.LastDirection);
        MovePlayer(_inputController.Direction);

        _shootingController.FixedUpdate();
    }

    private void MovePlayer(Vector3 direction)
    {
        _playerRigidbody.velocity = direction.normalized * _playerView.Speed * Time.fixedDeltaTime;
    }

    private void RotatePlayer(Vector3 direction)
    {
        Quaternion currentRotation = _playerView.transform.rotation.normalized;
        if (direction.normalized != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction.normalized);

            if(currentRotation != targetRotation)
            {
                _playerView.transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, _playerView.RotationSpeed);
            }
        }


        //Debug.DrawRay(_playerView.transform.position, _playerView.transform.forward * 10);
        //Debug.DrawRay(_playerView.transform.position, direction * 10, Color.yellow);
    }
}

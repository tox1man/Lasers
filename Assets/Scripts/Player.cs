using UnityEngine;

public class Player : IUpdatable, IFixedUpdatable
{
    public bool DoUpdate { get; set; }
    private PlayerObjectView View;
    private InputController _inputController;
    private ShootingController<PlayerObjectView> _shootingController;
    private Rigidbody _playerRigidbody;

    public Player(PlayerObjectView playerView, InputController inputController, Vector3 position)
    {
        _inputController = inputController;
        View = playerView;
        _playerRigidbody = View.GetComponent<Rigidbody>();
        _playerRigidbody.MovePosition(position);

        _shootingController = new ShootingController<PlayerObjectView>(View);
    }

    public void Update()
    {
        if (!View.IsActive)
        {
            return;
        }

        View.CheckHealth();

        _shootingController.Update();
    }

    public void FixedUpdate()
    {
        if (!View.IsActive)
        {
            return;
        }

        if (_playerRigidbody.velocity != Vector3.zero)
        {
            if(_inputController.Direction != Vector3.zero)
            {
                _inputController.LastDirection = _inputController.Direction;
            }
        }
        if (View.DoAnimate)
        {
            View.Rotate(_inputController.LastDirection);
            View.Move(_inputController.Direction);
        }

        _shootingController.FixedUpdate();
    }


}

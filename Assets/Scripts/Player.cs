using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Player : IUpdatable, IFixedUpdatable
{
    public bool DoUpdate { get; set; }
    private Dictionary<Vector2Int, TileObjectView> _tiles;
    private PlayerObjectView View;
    private InputController _inputController;
    private ShootingController<PlayerObjectView> _shootingController;

    public Player(PlayerObjectView playerView, InputController inputController, Vector3 position)
    {
        View = playerView;
        _inputController = inputController;
        _tiles = GameObject.Find(Parameters.ROOT_OBJECT_NAME).GetComponent<RootScript>()._level.Tiles;
        //View.Move(_tiles.First());

        _shootingController = new ShootingController<PlayerObjectView>(View);
    }

    public void Update()
    {
        if (!View.IsActive)
        {
            return;
        }
        View.CheckHealth();

        if (_inputController.Direction != Vector3.zero)
        {
            _inputController.LastDirection = _inputController.Direction;
        }

        if (View.DoAnimate)
        {
            Vector3 dir = _inputController.Direction;
            Vector2Int coord = View.CurrentTile.Key + new Vector2Int(Mathf.RoundToInt(dir.x), Mathf.RoundToInt(dir.z));

            if (_tiles.ContainsKey(coord))
            {
                //View.Move(new KeyValuePair<Vector2Int, TileObjectView>(coord, _tiles[coord]));
            }
            View.Rotate(_inputController.LastDirection);
        }

        _shootingController.Update();
    }
    
    public void FixedUpdate()
    {
        if (!View.IsActive)
        {
            return;
        }
        _shootingController.FixedUpdate();
    }


}

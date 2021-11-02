using System.Collections.Generic;
using UnityEngine;
using static Parameters;
public class Module : IUpdatable, IFixedUpdatable
{
    public ModuleObjectView View { get;  private set; }
    public ModuleType Type { get; private set; }
    private GameObject _moduleGameObject;
    private Laser _laser;

    public Module(ModuleObjectView view, out GameObject _moduleGameObject)
    {
        View = view;
        _moduleGameObject = CreateModuleGameobject(View.Transform.position, Direction.East);

        if (View.Type == ModuleType.Emitter)
        {
            CreateLaser();
        }
    }
    private GameObject CreateModuleGameobject(Vector3 pos, Direction dir)
    {
        _moduleGameObject = GameObject.Instantiate(View.ObjectPrefab, pos, Quaternion.identity);
        _moduleGameObject.transform.Translate(Vector2.up * LEVEL_TILE_HEIGHT / 2);
        _moduleGameObject.transform.Translate(Vector2.up * View.Transform.localScale.y);

        View = _moduleGameObject.GetComponent<ModuleObjectView>();
        View.LaserDirection = dir;

        return _moduleGameObject;
    }

    public void CreateLaser()
    {
        View.Laser = GameObject.Instantiate(View.laserPrefab, _moduleGameObject.transform).GetComponent<LineRenderer>();
        View.indexColor = Random.Range(1, LASER_COLORS.Length);
        _laser = new Laser(View);
    }

    public void Update()
    {
        if (!View || !View.IsActive)
        {
            return;
        }
        _laser?.Shoot();

        View.ApplyColor(View.MixColors(View.InputColors.ToArray()));
    }
    public void FixedUpdate()
    {
        if (!View.IsActive)
        {
            return;
        }
    }

    public void DeleteGameObject()
    {
        View = null;
        GameObject.Destroy(_moduleGameObject);
    }
}
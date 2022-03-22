using UnityEngine;
using static Parameters;
public class Module : IUpdatable
{
    public ModuleObjectView View { get;  private set; }
    private GameObject _moduleGameObject;

    public Module(ModuleObjectView view, out GameObject _moduleGameObject)
    {
        View = view;
        _moduleGameObject = CreateModuleGameobject(View.Transform.position);

        switch (View.Type)
        {
            case ModuleType.Absorber:
                break;
            case ModuleType.Disperser:
                CreateLaser(false, Direction.East, LaserColors.White);
                CreateLaser(false, Direction.East, LaserColors.White);
                CreateLaser(false, Direction.East, LaserColors.White);
                break;
            case ModuleType.Reflector:
                break;
            case ModuleType.Emitter:
                CreateLaser(true, GetRandomLaserDirection(), GetRandomLaserColor()); //RANDOM DIR AND COLOR!
                break;
        }
    }
        
    public void Update()
    {
        if (!View || !View.IsActive) return;

        foreach(Laser laser in View.Lasers)
        {
            if (View.Type != ModuleType.Emitter) View.ToggleLaserFromEditor(laser, false);
            if (laser.Line.enabled)
            {
                laser.Shoot(GetVectorFromDir(View.LaserDirection), 100f);
            }
        }
        if (View.ApplyColor(View.MixColors(View.InputColors.ToArray())))
        {
            GetRoot().GoalController.OnAbsorberColorChanged(GetModulesByType(View.Type));
        }
    }
    public Laser CreateLaser(bool isEnabled, Direction direction, LaserColor laserColor)
    {
        GameObject laserObject = GameObject.Instantiate(View.laserPrefab, _moduleGameObject.transform);
        Laser laser = laserObject.GetComponent<Laser>();

        laser.ToggleFromEditor = isEnabled;
        laser.Line = laserObject.GetComponent<LineRenderer>();
        laser.Line.enabled = laser.ToggleFromEditor;

        View.LaserDirection = direction;

        laser.View = View;
        laser.LaserColor = laserColor;
        laser.Direction = GetVectorFromDir(direction);

        View.Lasers.Add(laser);

        return laser;
    }
    public void DeleteGameObject()
    {
        View = null;
        GameObject.Destroy(_moduleGameObject);
    }
    private GameObject CreateModuleGameobject(Vector3 pos)
    {
        _moduleGameObject = GameObject.Instantiate(View.ObjectPrefab, pos, Quaternion.identity);
        _moduleGameObject.transform.Translate(Vector2.up * LEVEL_TILE_HEIGHT / 2);
        _moduleGameObject.transform.Translate(Vector2.up * View.Transform.localScale.y);

        View = _moduleGameObject.GetComponent<ModuleObjectView>();

        return _moduleGameObject;
    }
}
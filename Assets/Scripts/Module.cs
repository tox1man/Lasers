using UnityEngine;
using static Parameters;
public class Module : IUpdatable
{
    public ModuleObjectView View;
    private GameObject _moduleGameObject;

    public Module(ModuleObjectView view, out GameObject _moduleGameObject)
    {
        View = view;
        _moduleGameObject = CreateModuleGameobject();

        switch (View.Type)
        {
            case ModuleType.Absorber:
                View.TargetColor = view.TargetColor;
                break;
            case ModuleType.Disperser:
                CreateLaser(false, Direction.North, LaserColors.White);
                CreateLaser(false, Direction.North, LaserColors.White);
                CreateLaser(false, Direction.North, LaserColors.White);
                break;
            case ModuleType.Reflector:
                break;
            case ModuleType.Emitter:
                View.LaserColors = view.LaserColors;
                View.LaserDirection = view.LaserDirection;
                if (View.LaserColors == null || View.LaserColors.Count == 0) 
                {
                    View.LaserColors = new System.Collections.Generic.List<LaserColor>();
                    View.LaserColors.Add(LaserColors.White);
                }
                CreateLaser(true, View.LaserDirection, View.LaserColors[0]);
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
            GoalController.instance.OnAbsorberColorChanged(GetModulesByType(View.Type));
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
    private GameObject CreateModuleGameobject()
    {
        _moduleGameObject = GameObject.Instantiate(View.ObjectPrefab, View.Transform.position, Quaternion.identity);

        float scaleValue = GetStage().Level.GridSize;
        Vector3 moduleScale = new Vector3(scaleValue / 2 * View.Transform.localScale.x, 
                                    scaleValue / 2 * View.Transform.localScale.y, 
                                    scaleValue / 2 * View.Transform.localScale.z);
        _moduleGameObject.transform.localScale = moduleScale;
        _moduleGameObject.transform.Translate(Vector2.up * View.Transform.localScale.y);

        View = _moduleGameObject.GetComponent<ModuleObjectView>();

        return _moduleGameObject;
    }
}
using System.Collections.Generic;
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
                break;
            case ModuleType.Disperser:
                AddLaser(CreateLaser(LaserColors.White));
                AddLaser(CreateLaser(LaserColors.White));
                AddLaser(CreateLaser(LaserColors.White));
                break;
            case ModuleType.Reflector:
                break;
            case ModuleType.Emitter:
                // reference to "view" is fine, but reference to "View" doesnt save laserColor. why?
                AddLaser(CreateLaser(view.LaserColors[0], view.LaserDirection, true));
                break;
            case ModuleType.Portal:
                CreatePortalPair();
                break;
        }
    }
    public void Update()
    {
        if (!View || !View.IsActive) return;
        // Perfom actions based on current GameState.
        CheckGameState();
        // Shoot every availiable laser.
        foreach (Laser laser in View.Lasers)
        {
            if (View.Type != ModuleType.Emitter) View.ToggleLaserFromEditor(laser, false);
            if (laser.Line.enabled)
            {
                laser.Shoot(GetVectorFromDir(View.LaserDirection), LASER_MAX_DIST);
            }
        }
        // Invoke event after absorbers color has been changed.
        if (View.Type == ModuleType.Absorber && View.ApplyColor(View.MixColors(View.InputColors.ToArray())))
        {
            GoalController.instance.OnAbsorberColorChanged(GetModulesByType(View));
        }
    }
    private void CheckGameState()
    {
        switch (GetRoot().GameMode)
        {
            case GameMode.ItemSelect:
                if (View.Selected)
                {
                    View.DisplayItemProperties();
                }
                break;
            default:
                View.Deselect();
                break;
        }
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
    private Laser CreateLaser(LaserColor laserColor, Direction direction = Direction.North, bool isEnabled = false)
    {
        GameObject laserObject = GameObject.Instantiate(View.laserPrefab, _moduleGameObject.transform);
        Laser laser = new Laser(View, laserColor, GetVectorFromDir(direction), laserObject.GetComponent<LineRenderer>());
        laser.Enabled = isEnabled;

        return laser;
    }
    private void AddLaser(Laser laser)
    {
        if (View.Lasers == null) { View.Lasers = new List<Laser>(); }
        View.Lasers.Add(laser);
    }
    private void CreatePortalPair()
    {
        PortalView portalView = (PortalView)View;
        portalView.PortalPair = new PortalPair(portalView, portalView.Tile, portalView.Tile);

        GameObject laserObject1 = GameObject.Instantiate(portalView.laserPrefab, _moduleGameObject.transform);
        Laser laser1 = new Laser(portalView, LaserColors.White, GetVectorFromDir(Direction.North), laserObject1.GetComponent<LineRenderer>());
        laserObject1.transform.SetParent(portalView.gameObject.transform.Find(PORTAL1_NAME));
        laser1.Enabled = false;
        AddLaser(laser1);

        GameObject laserObject2 = GameObject.Instantiate(portalView.laserPrefab, _moduleGameObject.transform);
        Laser laser2 = new Laser(portalView, LaserColors.White, GetVectorFromDir(Direction.North), laserObject2.GetComponent<LineRenderer>());
        laserObject2.transform.SetParent(portalView.gameObject.transform.Find(PORTAL2_NAME));
        laser2.Enabled = false;
        AddLaser(laser2);
    }
    public void DeleteGameObject()
    {
        View = null;
        GameObject.Destroy(_moduleGameObject);
    }
}
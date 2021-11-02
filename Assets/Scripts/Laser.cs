using System;
using UnityEngine;

public class Laser
{
    public ModuleObjectView View { get; private set; }
    private LineRenderer _line;
    public Color Color { get; private set; }
    public Laser(ModuleObjectView view)
    {
        View = view;
        Color = Parameters.LASER_COLORS[View.indexColor];
        _line = View.Laser;
    }

    public void Shoot()
    {
        Vector3 dir = View.GetVectorFromDir(View.LaserDirection);
        Debug.Log("PEW");
    }
}
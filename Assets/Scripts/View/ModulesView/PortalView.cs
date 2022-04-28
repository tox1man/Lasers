using System.Collections.Generic;
using UnityEngine;
using static Parameters;

public sealed class PortalView : ModuleObjectView
{
    public override void SetDefault()
    {
        Tile.Set(0, 0);
        Move(Tile);
    }
    public override void GetViewFromStageModule(StageData.Module module)
    {
        Tile = module.Tile;
        Type = module.Type;
        TargetColor = Parameters.LaserColors.ColorsList[module.TargetColorIndex];
        LaserDirection = module.LaserDirection;
        LaserColors = new List<LaserColor>();
        foreach (int index in module.LaserColorsIndecies)
        {
            LaserColors.Add(Parameters.LaserColors.ColorsList[index]);
        }
    }
    public override void TryAddColor(Color other)
    {
        if (!InputColors.Contains(other)) InputColors.Add(other);
    }
    public override void ToggleLaserFromEditor(Laser laser, bool isEnabled)
    {
        laser.Enabled = isEnabled;
        laser.Line.enabled = isEnabled;
    }
    public override bool ApplyColor(Color color)
    {
        throw new System.NotImplementedException();
    }
    public override Color MixColors(Color[] colors)
    {
        throw new System.NotImplementedException();
    }
    public override bool CheckTargetColor()
    {
        throw new System.NotImplementedException();
    }
}
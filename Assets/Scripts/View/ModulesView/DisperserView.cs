using System.Collections.Generic;
using UnityEngine;
using static Parameters;

public sealed class DisperserView : ModuleObjectView
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
        LaserColors = new List<LaserColor>();
        foreach (int index in module.LaserColorsIndecies)
        {
            LaserColors.Add(Parameters.LaserColors.ColorsList[index]);
        }
    }
    public override void ToggleLaserFromEditor(Laser laser, bool isEnabled)
    {
        laser.Enabled = isEnabled;
        laser.Line.enabled = isEnabled;
    }
    /// <summary>
    /// Not implemented for Disperser type modules.
    /// </summary>
    /// <param name="other"></param>
    public override void TryAddColor(Color other)
    {
        throw new System.NotImplementedException();
    }
    /// <summary>
    /// Not implemented for Disperser type modules.
    /// </summary>
    /// <param name="color"></param>
    /// <returns></returns>
    public override bool ApplyColor(Color color)
    {
        throw new System.NotImplementedException();
    }
    /// <summary>
    /// Not implemented for Disperser type modules.
    /// </summary>
    /// <param name="colors"></param>
    /// <returns></returns>
    public override Color MixColors(Color[] colors)
    {
        throw new System.NotImplementedException();
    }
    /// <summary>
    /// Not implemented for Disperser type modules.
    /// </summary>
    /// <returns></returns>
    public override bool CheckTargetColor()
    {
        throw new System.NotImplementedException();
    }
}
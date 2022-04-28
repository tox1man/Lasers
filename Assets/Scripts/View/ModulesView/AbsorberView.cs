using System.Collections.Generic;
using UnityEngine;

public sealed class AbsorberView : ModuleObjectView
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
    }
    public override void TryAddColor(Color other)
    {
        if (!InputColors.Contains(other)) InputColors.Add(other);
    }
    public override Color MixColors(Color[] colors)
    {
        if (colors.Length == 0) return Color.white;

        InputColors = new List<Color>();
        float r = 0;
        float g = 0;
        float b = 0;

        foreach (Color color in colors)
        {
            r += color.r;
            g += color.g;
            b += color.b;
        }
        return new Color(r, g, b);
    }
    public override bool ApplyColor(Color color)
    {
        Material material = GetComponent<Renderer>().material;
        if (material.color != color)
        {
            material.color = color;
            return true;
        }
        return false;
    }
    public override bool CheckTargetColor()
    {
        return GetComponent<Renderer>().material.color == TargetColor.Color;
    }
    /// <summary>
    /// Not implemented for Absorber type modules.
    /// </summary>
    /// <param name="laser"></param>
    /// <param name="isEnabled"></param>
    public override void ToggleLaserFromEditor(Laser laser, bool isEnabled)
    {
        throw new System.NotImplementedException();
    }
}

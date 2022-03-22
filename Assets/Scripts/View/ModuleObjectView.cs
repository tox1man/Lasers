using System.Collections.Generic;
using UnityEngine;
using static Parameters;

public class ModuleObjectView : GameObjectView
{
    [Header("Module Object Parameters")]
    public ModuleType Type;
    public GameObject laserPrefab;
    public Renderer Renderer;

    public List<Laser> Lasers = new List<Laser>();
    [HideInInspector] public List<Color> InputColors = new List<Color>();   // Displayed in Editor only for Absorber and Disperser
    [HideInInspector] public LaserColor TargetColor = LaserColors.White;    // Displayed in Editor only for Absorber
    [HideInInspector] public Direction LaserDirection;                      // Displayed in Editor only for Emitter

    public void TryAddColor(Color other)
    {
        if (!InputColors.Contains(other)) InputColors.Add(other);
    }
    public void ToggleLaserFromEditor(Laser laser, bool isEnabled)
    {
        laser.ToggleFromEditor = isEnabled;
        laser.enabled = isEnabled;
        laser.Line.enabled = isEnabled;
    }    
    public void TryToggleLaserInPlaymode(Laser laser, bool isEnabled)
    {
        if (laser.ToggleFromEditor == isEnabled)
        {
            laser.enabled = isEnabled;
            laser.Line.enabled = isEnabled;
        }
    }
    public Color MixColors(Color[] colors)
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
    public bool ApplyColor(Color color)
    {
        if (Renderer.material.color != color)
        {
            Renderer.material.color = color;
            return true;
        }
        return false;
    }
    public bool CheckTargetColor()
    {
        return Renderer.material.color == TargetColor.Color;
    }
}

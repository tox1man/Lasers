using System.Collections.Generic;
using UnityEngine;
using static Parameters;

public abstract class ModuleObjectView : GameObjectView
{
    [Header("Module Object Parameters")]
    public ModuleType Type;
    public GameObject laserPrefab;

    public PortalPair PortalPair;
    public List<LaserColor> LaserColors = new List<LaserColor> { Parameters.LaserColors.White };
    public List<Laser> Lasers = new List<Laser>();
    [HideInInspector] public Direction LaserDirection = Direction.North;                 // Displayed in Editor only for Emitter
    [HideInInspector] public List<Color> InputColors = new List<Color>();                // Displayed in Editor only for Absorber and Disperser
    [HideInInspector] public LaserColor TargetColor = Parameters.LaserColors.White;      // Displayed in Editor only for Absorber

    /// <summary>
    /// Sets default parameters of the Module.
    /// </summary>
    public abstract void SetDefault();
    /// <summary>
    /// Change module parameters from Stage.Module object.
    /// </summary>
    /// <param name="module"></param>
    public abstract void GetViewFromStageModule(StageData.Module module);
    /// <summary>
    /// Tries to add color to InputColors list.
    /// </summary>
    /// <param name="other"></param>
    public abstract void TryAddColor(Color other);
    /// <summary>
    /// Toggles the enable field of the Laser.
    /// </summary>
    /// <param name="laser"></param>
    /// <param name="isEnabled"></param>
    public abstract void ToggleLaserFromEditor(Laser laser, bool isEnabled);
    /// <summary>
    /// Mixes all InputColors and return resulting color.
    /// </summary>
    /// <param name="colors">Colors to mix</param>
    /// <returns></returns>
    public abstract Color MixColors(Color[] colors);
    /// <summary>
    /// Applies color to module Material.
    /// </summary>
    /// <param name="color">Color to apply.</param>
    /// <returns></returns>
    public abstract bool ApplyColor(Color color);
    /// <summary>
    /// Returns if current material color identical to TargetColor of the Module.
    /// </summary>
    /// <returns></returns>
    public abstract bool CheckTargetColor();

}

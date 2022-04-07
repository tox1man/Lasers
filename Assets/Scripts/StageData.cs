using System;
using System.Collections.Generic;
using UnityEngine;
using static Parameters;

[Serializable]
public class StageData
{
    public string Name;
    public bool Rewrite = false;
    public LevelParameters Level;
    [HideInInspector]
    [Range(0, 20)]
    public int[] ModuleAmounts;
    [HideInInspector] public List<Module> Modules;

    [Serializable]
    public class LevelParameters
    {
        [Range(1, 5)] public int GridSize;
        [Range(0f, 1f)] public float OffsetSize;
        public Vector2Int LevelSize;
        public WaveMode AnimationMode;
    }
    [Serializable]
    public class Module
    {
        public Vector2Int Tile;
        public ModuleType Type;
        public List<int> LaserColorsIndecies;
        public int TargetColorIndex;
        public Direction LaserDirection;

        public void GetModuleFromView(ModuleObjectView view)
        {
            Tile = view.Tile;
            Type = view.Type;
            TargetColorIndex = view.TargetColor.ColorIndex;
            LaserDirection = view.LaserDirection;
            LaserColorsIndecies = new List<int>();
            foreach(Laser laser in view.Lasers)
            {
                LaserColorsIndecies.Add(laser.LaserColor.ColorIndex);
            }
        }
    }
    public void SetDefault()
    {
        Name = "Default stage";
        ModuleAmounts = new int[4];
        Level = new LevelParameters()
        {
            GridSize = 2,
            OffsetSize = 0.2f,
            LevelSize = new Vector2Int(20, 20),
            AnimationMode = WaveMode.Horizontal
        };
        Modules = new List<Module>();
    }
    public override string ToString()
    {
        string str = "";
        str += $"Name: {Name}\n";
        str += $"AnimationMode: {Level.AnimationMode.ToString()}\n";
        str += $"GridSize:{Level.GridSize}\n";
        str += $"LevelSize:{Level.LevelSize.ToString()}\n";
        str += $"OffsetSize:{Level.OffsetSize}\n";
        str += $"ModuleAmounts:\n";
        for (int i = 0; i < ModuleAmounts.Length; i++)
        {
            str += $"{ModuleAmounts[i]} ";
        }
        return str;
    }
}

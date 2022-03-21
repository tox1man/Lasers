﻿using System;
using UnityEngine;

public static class Parameters
{
    // Gameplay Parameters
    public const int LASER_MAX_REFLECTIONS = 20;
    public const float MAX_RENDER_Y_DIST = -5f;     // vertical distance, below which object is disabled
    public const float MAX_RENDER_DIST_SQR = 1000f; // distance squared, behind which object is disabled

    // Tags & names
    public const string ROOT_OBJECT_NAME = "Root";
    public const string LEVEL_GAMEOBJECT_NAME = "Level";

    // Level Parameters
    public const float LEVEL_TILE_HEIGHT = 50f;     // height of the level tile

    public enum WaveMode                            // type of level animation
    {
        Horizontal,
        Vertical,
        Diagonal,
        Fall,
        Random
    }
    public enum Direction 
    { 
        North = 0, 
        East = 1,  
        South = 2, 
        West = 3 
    }
    public enum ModuleType
    {
        Absorber,
        Emitter,
        Reflector,
        Disperser
    }
    public struct LaserColor
    {
        public string Name;
        public Color Color;
        public int ColorIndex;
    }
    // Avaliable laser colors
    public struct LaserColors
    {
        public static LaserColor Black = new LaserColor()
        { Name = "Black", Color = Color.black, ColorIndex = 0 };

        public static LaserColor Red = new LaserColor()
        { Name = "Red", Color = Color.red, ColorIndex = 1 };

        public static LaserColor Green = new LaserColor()
        { Name = "Green", Color = Color.green, ColorIndex = 2 };

        public static LaserColor Blue = new LaserColor()
        { Name = "Blue", Color = Color.blue, ColorIndex = 3 };

        public static LaserColor White = new LaserColor()
        { Name = "White", Color = Color.white, ColorIndex = 4 };

        public static LaserColor[] ColorsList = new LaserColor[]
        { 
            Black, Red, Green, Blue, White
        };
    }
    public static RootScript GetRoot()
    {
        return GameObject.FindObjectOfType<RootScript>();
    }
    public static LevelController GetLevel()
    {
        return GetRoot().Level;
    }
    public static LaserColor GetRandomLaserColor()
    {
        return LaserColors.ColorsList[UnityEngine.Random.Range(0, LaserColors.ColorsList.Length)];
    }
    public static Direction GetRandomLaserDirection()
    {
        Array values = Enum.GetValues(typeof(Direction));
        return (Direction)values.GetValue(UnityEngine.Random.Range(0, values.Length));
    }
    public static Vector3 GetVectorFromDir(Direction dir)
    {
        Vector3 result = Vector3.zero;
        switch (dir)
        {
            case Direction.North:
                result = Vector3.forward;
                break;
            case Direction.East:
                result = Vector3.right;
                break;
            case Direction.South:
                result = Vector3.back;
                break;
            case Direction.West:
                result = Vector3.left;
                break;
        }
        return result;
    }
    public static Quaternion GetQuaternionFromDir(Direction dir)
    {
        Quaternion result = Quaternion.identity;
        Vector3 resultVector = Vector3.zero;
        switch (dir)
        {
            case Direction.North:
                result = Quaternion.LookRotation(Vector3.forward);
                resultVector = Vector3.forward;
                break;
            case Direction.East:
                result = Quaternion.LookRotation(Vector3.right);
                resultVector = Vector3.right;
                break;
            case Direction.South:
                result = Quaternion.LookRotation(Vector3.back);
                resultVector = Vector3.back;
                break;
            case Direction.West:
                result = Quaternion.LookRotation(Vector3.left);
                resultVector = Vector3.left;
                break;
        }
        return result;
    }
    public static string GetModuleObjectName(ModuleType type)
    {
        return $"{type.ToString()}";
    }
    public static string GetModuleObjectPoolName(ModuleType type)
    {
        return $"{type.ToString()}'s Pool";
    }    
    public static ModuleObjectView[] GetModulesByType(ModuleType type)
    {
        return GameObject.Find(GetModuleObjectPoolName(type)).GetComponentsInChildren<ModuleObjectView>();
    }
    public static string[] GetColorNamesArray()
    {
        string[] colorNames = new string[LaserColors.ColorsList.Length];
        for (int i = 0; i < LaserColors.ColorsList.Length; i++)
        {
            colorNames[i] = LaserColors.ColorsList[i].Name;
        }
        return colorNames;
    }
}

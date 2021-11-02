using System.Collections.Generic;
using UnityEngine;

public static class Parameters
{
    // Gameplay Parameters
    public const int PLAYER_FOV = 90;               // in degrees
    public const int ENEMY_NUMBER = 10;
    public const float MAX_RENDER_Y_DIST = -5f;     // vertical distance, below which object is disabled
    public const float MAX_RENDER_DIST_SQR = 1000f; // distance squared, behind which object is disabled

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

    public enum LaserColor
    {
        Red = 0,
        Green = 1,
        Blue = 2,
        White = 3          
    }

    public static Color[] LASER_COLORS = new Color[]
    {
        Color.black,
        Color.red,
        Color.green,
        Color.blue,
        Color.white
    };
    public static string[] LASER_COLORS_NAMES = new string[]
    {   "Black",
        "Red",
        "Green",
        "Blue",
        "White" 
    };

    // Shooting Parameters
    public const int LASER_MAX_REFLECTIONS = 20;
    public const int FOV_RAYCAST_MAXDISTANCE = 10;
    public const int FOV_RAYCAST_STEP = 5;          // in degrees

    // Bullet Parameters
    public const int BULLET_SHOOT_VELOCITY = 15;
    public const int BULLET_POOL_CAPACITY = 100;
    public const float BULLET_DRAG = 0f;
    public const float BULLET_ANGULAR_DRAG = 0f;
    public const float BULLET_VELOCITY_THRESHOLD = 0.1f;
    public const string BARREL_OBJECT_NAME = "Barrel";
    public const string BULLET_POOL_OBJECT_NAME = "Bullets";

    // Enemy parameters
    public const string ENEMY_POOL_OBJECT_NAME = "Enemies";
    public const string EMITTER_POOL_OBJECT_NAME = "Emitters";
    public const string ABSORBER_POOL_OBJECT_NAME = "Absorbers";
    public const string REFLECTOR_POOL_OBJECT_NAME = "Reflectors";
    public const string DISPERSER_POOL_OBJECT_NAME = "Dispersers";

    // Tags & names
    public const string ROOT_OBJECT_NAME = "Root";
    public const string PLAYER_TAG = "Player";
    public const string ENEMY_TAG = "Enemy";
    public const string EMITTER_TAG = "Emitter";
    public const string BULLET_TAG = "Bullet";
    public const string LEVEL_GAMEOBJECT_NAME = "Level";

    public static RootScript GetRoot()
    {
        return GameObject.Find(ROOT_OBJECT_NAME).GetComponent<RootScript>();
    }
    public static LevelController GetLevel()
    {
        return GetRoot()._level;
    }
}

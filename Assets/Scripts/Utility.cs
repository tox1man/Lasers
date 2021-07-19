using System;
public static class Utility
{
    // Gameplay Parameters
    public const int PLAYER_FOV = 90; // in degrees

    // Shooting Parameters
    public const int FOV_RAYCAST_STEP = 5; // in degrees
    public const int FOV_RAYCAST_MAXDISTANCE = 10;

    // Tags
    public const string PLAYER_TAG = "Player";
    public const string ENEMY_TAG = "Enemy";

    // Bullet 
    public const string BULLET_CONTATINER_OBJECT_NAME = "Bullets";
    public const string BARREL_OBJECT_NAME = "Barrel";
    public const int BULLET_POOL_CAPACITY = 10;
    public const int BULLET_SHOOT_VELOCITY = 20;
    public const float BULLET_DRAG = 0f;
    public const float BULLET_ANGULAR_DRAG = 0f;
}

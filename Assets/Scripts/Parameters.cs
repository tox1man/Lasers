using UnityEngine;

public static class Parameters
{
    // Gameplay Parameters
    public const int PLAYER_FOV = 90;               // in degrees
    public const int ENEMY_NUMBER = 10;
    public const float MAX_RENDER_Y_DIST = -5f;     // vertical distance, below which object is disabled
    public const float MAX_RENDER_DIST_SQR = 1000f; // distance squared, behind which object is disabled

    // Shooting Parameters
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

    // Tags
    public const string PLAYER_TAG = "Player";
    public const string ENEMY_TAG = "Enemy";
    public const string BULLET_TAG = "Bullet";
}

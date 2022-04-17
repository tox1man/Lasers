using UnityEngine;
using static Parameters;

public class CameraController : IUpdatable
{
    public static CameraController instance;

    public Camera MainCamera { get; private set; }

    public CameraController() 
    {
        if (instance != null)
        {
            Debug.LogWarning(this + " instance already exists. Cant make multiple instances of " + this);
        }
        instance = this;

        MainCamera = Camera.main;
        SetDefaultCameraPos(MainCamera);
    }
    public void SetDefaultCameraPos(Camera camera)
    {
        camera.transform.rotation = Quaternion.Euler(45f, 0f, 0f);
        RootScript root = GetRoot();
        LevelController level = GetLevel();
        Vector3 pos = Vector3.zero;

        Vector2 levelBordersX = new Vector2(
            level.Tiles[new Vector2Int(0, 0)].Transform.position.x - root.CurrentStage.Level.GridSize / 2f,
            level.Tiles[new Vector2Int(root.CurrentStage.Level.LevelSize.x - 1, 0)].Transform.position.x + root.CurrentStage.Level.GridSize / 2f);

        Vector2 levelBordersZ = new Vector2(
            level.Tiles[new Vector2Int(0, 0)].Transform.position.z - root.CurrentStage.Level.GridSize / 2f,
            level.Tiles[new Vector2Int(0, root.CurrentStage.Level.LevelSize.y - 1)].Transform.position.z + root.CurrentStage.Level.GridSize / 2f);

        pos.Set(levelBordersX.y / 2f, 0f, levelBordersZ.y / 2f * Mathf.Cos(45f) + root.CurrentStage.Level.GridSize);
        camera.transform.position = pos;

        float localZ = Mathf.Max(levelBordersX.y, levelBordersZ.y) * -(1 / Mathf.Tan(camera.fieldOfView / 2));
        camera.transform.Translate(0f, 0f, localZ * 2f, Space.Self);
    }
    public void Update()
    {
        RootScript root = GetRoot();
        LevelController level = GetLevel();

        Vector2 levelBordersX = new Vector2(
            level.Tiles[new Vector2Int(0, 0)].Transform.position.x - root.CurrentStage.Level.GridSize / 2f,
            level.Tiles[new Vector2Int(root.CurrentStage.Level.LevelSize.x - 1, 0)].Transform.position.x + root.CurrentStage.Level.GridSize / 2f);

        Vector2 levelBordersZ = new Vector2(
            level.Tiles[new Vector2Int(0, 0)].Transform.position.z - root.CurrentStage.Level.GridSize / 2f,
            level.Tiles[new Vector2Int(0, root.CurrentStage.Level.LevelSize.y - 1)].Transform.position.z + root.CurrentStage.Level.GridSize / 2f);

        MainCamera.transform.RotateAround(new Vector3(levelBordersX.y / 2f, 0f, levelBordersZ.y / 2f), Vector3.up, Input.GetAxisRaw("Horizontal") * Time.deltaTime * 120f);
        MainCamera.transform.Translate(0f, 0f, Input.GetAxisRaw("Vertical") * Time.deltaTime * 60f);
    }
} 

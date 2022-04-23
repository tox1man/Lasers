using UnityEngine;
using static Parameters;

public class CameraController : IUpdatable
{
    public static CameraController instance;

    private RootScript root = GetRoot();
    private LevelController level = GetLevel();

    private Vector3 levelCenterPoint;

    public Camera MainCamera { get; private set; }

    public CameraController() 
    {
        if (instance != null)
        {
            Debug.LogWarning(this + " instance already exists. Cant make multiple instances of " + this);
        }
        instance = this;

        MainCamera = Camera.main;
        levelCenterPoint = new Vector3(level.BordersX.y / 2f, 0f, level.BordersZ.y / 2f);

        SetDefaultCameraPos(MainCamera);
    }
    public void SetDefaultCameraPos(Camera camera)
    {
        camera.transform.rotation = Quaternion.Euler(CAMERA_ANGLE, 0f, 0f);
        Vector3 pos = Vector3.zero;

        pos.Set(level.BordersX.y / 2f, 0f, level.BordersZ.y / 2f * Mathf.Cos(CAMERA_ANGLE) + root.CurrentStage.Level.GridSize);
        camera.transform.position = pos;

        float localZ = Mathf.Max(level.BordersX.y, level.BordersZ.y) * -(1 / Mathf.Tan(camera.fieldOfView / 2));

        camera.transform.Translate(0f, 0f, localZ * 2f, Space.Self);
    }
    public void Update()
    {
        MainCamera.transform.RotateAround(levelCenterPoint, Vector3.up, Input.GetAxisRaw("Horizontal") * Time.deltaTime * 120f);
        MainCamera.transform.Translate(0f, 0f, Input.GetAxisRaw("Vertical") * Time.deltaTime * 60f);
    }
} 

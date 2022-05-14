using UnityEngine;
using static Parameters;

public class CameraController : IUpdatable
{
    public static CameraController instance;

    private RootScript root = GetRoot();
    private LevelBuilder level = GetLevel();

    private Vector3 levelCenterPoint;

    private float cameraZoomSpeed = 10f;
    private float cameraRotateSpeed = 50f;
    private bool wasZoomingLastFrame;
    private Vector2[] lastFrameTouchPos;

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

        InputController.instance.onTouches.EventAction += CameraHandleTouch;
        InputController.instance.onVerticalAxis.EventAction += CameraHandleVerticalAxis;
        InputController.instance.onHorizontalAxis.EventAction += CameraHandleHorizontalAxis;
    }
    public void Update()
    {
        ////
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
    private void CameraHandleTouch(Touch[] touches)
    {
        switch (touches.Length)
        {
            case 1: // Rotate camera
                RotateCamera(touches[0].deltaPosition.x);
                break;
            case 2: // Zoom camera
                Vector2[] currentTouchPos = new Vector2[] { touches[0].position, touches[1].position};
                if (!wasZoomingLastFrame)
                {
                    wasZoomingLastFrame = true;
                    lastFrameTouchPos = currentTouchPos;
                }
                else
                {
                    float newTouchDist = Vector2.Distance(currentTouchPos[0], currentTouchPos[1]);
                    float oldTouchDist = Vector2.Distance(lastFrameTouchPos[0], lastFrameTouchPos[1]);
                    float deltaTouchDist = newTouchDist - oldTouchDist;
                    TranslateCamera(deltaTouchDist);
                    lastFrameTouchPos = currentTouchPos;
                }
                break;
            default:
                wasZoomingLastFrame = false;
                break;
        }
    }
    private void CameraHandleVerticalAxis(float amount)
    {
        TranslateCamera(amount * cameraZoomSpeed);
        Debug.Log(amount * cameraZoomSpeed);
    }
    private void CameraHandleHorizontalAxis(float amount)
    {
        RotateCamera(amount * cameraRotateSpeed);
        Debug.Log(amount * cameraRotateSpeed);
    }
    private void RotateCamera(float angle)
    {
        MainCamera.transform.RotateAround(levelCenterPoint, Vector3.up, Time.deltaTime * angle);
    }    
    private void TranslateCamera(float amount)
    {
        MainCamera.transform.Translate(0f, 0f, Time.deltaTime * amount);
    }
} 

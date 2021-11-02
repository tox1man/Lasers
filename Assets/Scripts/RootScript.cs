using UnityEngine;
using UnityEditor;
using System.Reflection;

public class RootScript : MonoBehaviour
{
    [Header("View components")]
    [SerializeField] private PlayerObjectView _playerView;
    //[SerializeField] private EnemyObjectView _enemyView;
    [SerializeField] public ModuleObjectView[] _moduleViews;

    [Header("Level")]
    [SerializeField] public GameObject FloorTilePrefab;
    [SerializeField] public Vector2Int LevelSize;
    [SerializeField] [Range(1, 5)] public int GridSize = 2;
    [SerializeField] [Range(0f, 1f)] public float OffsetSize = 0.1f;
    [SerializeField] public Parameters.WaveMode AnimationMode;

    [Header("Gizmos parameters")]
    [SerializeField] private bool _drawRenderSphere;
    [SerializeField] private bool _drawRenderPlane;
    [SerializeField] private bool _drawVisionCone;

    public LevelController _level;
    private MainController _mainController;
    [HideInInspector] public int[] _moduleAmounts;

    float deltaTime = 0.0f;

    public delegate void Action(int viewIndex, bool addAmount);
    public event Action ModulesAmountChanged;
    public virtual void OnModuleAmountChange(int viewIndex, bool addAmount)
    {
        ModulesAmountChanged?.Invoke(viewIndex, addAmount);
    }

    public void Awake()
    {
        gameObject.name = Parameters.ROOT_OBJECT_NAME;

        _level = new LevelController();
        _level.Start();

        _mainController = new MainController();
        _mainController.Start();
    }

    public void Update()
    {
        _level.Update();
        _mainController.Update();
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    public void FixedUpdate()
    {
        _mainController.FixedUpdate();
    }

    public void OnDestroy()
    {
        _mainController.OnDestroy();
    }

    public void OnDrawGizmos()
    {
        if (_drawRenderSphere)
        { 
            Gizmos.DrawWireSphere(Vector3.zero, Mathf.Sqrt(Parameters.MAX_RENDER_DIST_SQR));
        }
        if (_drawRenderPlane)
        {
            Gizmos.DrawCube(new Vector3(0f, Parameters.MAX_RENDER_Y_DIST, 0f), new Vector3(100f, 1f, 100f));
        }
        if (_drawVisionCone)
        {
            //Vector3 leftRayDirection = Quaternion.Euler(0f, -Parameters.PLAYER_FOV / 2, 0f) * _playerView.transform.forward;
            //Vector3 rightRayDirection = Quaternion.Euler(0f, Parameters.PLAYER_FOV / 2, 0f) * _playerView.transform.forward;

            //Debug.DrawRay(_playerView.transform.position, leftRayDirection.normalized * 10, Color.cyan);
            //Debug.DrawRay(_playerView.transform.position, rightRayDirection.normalized * 10, Color.cyan);

        }
    }

    void OnGUI()
    {
        ShowFPS();
    }

    private void ShowFPS()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }
}
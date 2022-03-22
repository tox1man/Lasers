using UnityEngine;

public class RootScript : MonoBehaviour
{
    [Header("View components")]
    [SerializeField] public ModuleObjectView[] _moduleViews;

    [Header("Level")]
    [SerializeField] public GameObject FloorTilePrefab;
    [SerializeField] public Vector2Int LevelSize;
    [SerializeField] [Range(1, 5)] public int GridSize = 2;
    [SerializeField] [Range(0f, 1f)] public float OffsetSize = 0.1f;
    [SerializeField] public Parameters.WaveMode AnimationMode;

    public LevelController Level;
    public GoalController GoalController;
    public StageConfigurator StageConfig;
    private MainController _mainController;
    /*[HideInInspector]*/ public int[] ModuleAmounts;
     
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

        Level = new LevelController();
        Level.Start();

        _mainController = new MainController();
        _mainController.Start();
    }
    public void Update()
    {
        Level.Update();
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
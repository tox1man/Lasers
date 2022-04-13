using UnityEngine;

public class RootScript : MonoBehaviour
{
    [Header("View components")]
    //ORDER OF MODULES MATTERS!
    public ModuleObjectView[] ModuleViews;
    [Header("Stage Settings")]
    [SerializeField] public GameObject FloorTilePrefab;
    public bool EncryptSaveFiles;
    [SerializeField] public StageData CurrentStage;

    public LevelController Level;
    public GoalController GoalController;
    private MainController mainController;
    private SaveController saveController;
     
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

        saveController = new SaveController();

        Level = new LevelController();
        Level.Start();

        mainController = new MainController();
        mainController.Start();
    }
    public void Update()
    {
        deltaTime = Time.deltaTime;

        Level.Update();
        mainController.Update();
    }
    public void FixedUpdate()
    {
        mainController.FixedUpdate();
    }
    public void OnDestroy()
    {
        mainController.OnDestroy();
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
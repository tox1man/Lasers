using UnityEngine;
using static Parameters;

public class RootScript : MonoBehaviour
{
    [Header("View components")]
    // Order of modules views in array affects functionality.
    // Emitter should be last in the list.
    public ModuleObjectView[] ModuleViews;

    [Header("Stage Settings")]
    [SerializeField] public GameObject FloorTilePrefab;
    [SerializeField] public StageData CurrentStage;
    public bool EncryptSaveFiles;

    public LevelBuilder Level { get; private set; }
    private MainController mainController;
    public GameMode GameMode { get; set; }

    // Disable this and all subscribers on build
    public delegate void Action(int viewIndex, bool addAmount);
    public event Action ModulesAmountChanged;
    public virtual void OnModuleAmountChange(int viewIndex, bool addAmount)
    {
        ModulesAmountChanged?.Invoke(viewIndex, addAmount);
    }

    public void Awake()
    {
        gameObject.name = ROOT_OBJECT_NAME;

        Level = new LevelBuilder();
        Level.Start();

        mainController = new MainController();
        mainController.Start();
    }
    public void Update()
    {
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
        GUIController.instance.OnGUI();
    }
}
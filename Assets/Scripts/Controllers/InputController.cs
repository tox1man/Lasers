using UnityEngine;

public class InputAction<T>
{
    public delegate void Action(T value);
    public event Action EventAction;
    public virtual void OnAction(T value)
    {
        EventAction?.Invoke(value);
    }
}
public class InputController : IUpdatable
{
    public static InputController instance { get; set; }
    public GameObjectView SelectedItem;

    // Mobile Input
    private float lastTouchTime;
    private int lastFrameTouchCount;
    public InputAction<Touch> onTap = new InputAction<Touch>();
    public InputAction<Touch[]> onTouches = new InputAction<Touch[]>();
    // Desktop Input
    public InputAction<float> onVerticalAxis = new InputAction<float>();
    public InputAction<float> onHorizontalAxis = new InputAction<float>();

    public InputController()
    {
        if (instance != null)
        {
            Debug.LogWarning(this + " instance already exists. Cant make multiple instances of " + this);
        }
        instance = this;
        onTap.EventAction += SelectItemOnTap;
    }
    public void Update()
    {
        //CheckVerticalAxis();
        //CheckHorizontalAxis();
        CheckTouches();
        CheckPauseKey();
    }
    private void SelectItemOnTap(Touch touch)
    {
        RaycastHit hit;
        if (Physics.Raycast(CameraController.instance.MainCamera.ScreenPointToRay(touch.position), out hit, 100f))
        {
            GameObjectView hitObjectView = hit.collider.gameObject.GetComponentInParent<GameObjectView>();
            if (hitObjectView != null)
            {
                switch (hitObjectView)
                {
                    case ModuleObjectView module:
                        Parameters.ChangeGameMode(Parameters.GameMode.ItemSelect);
                        if(SelectedItem != null)
                        {
                            SelectedItem.Deselect();
                        }
                        module.Select();
                        SelectedItem = module;
                        break;
                    default:
                    Parameters.ChangeGameMode(Parameters.GameMode.Play);
                        break;
                }
            }
            return;
        }
        Parameters.ChangeGameMode(Parameters.GameMode.Play);
    }
    private void CheckPauseKey()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Parameters.GetRoot().GameMode == Parameters.GameMode.Pause)
            {
                Debug.Log(Parameters.ChangeGameMode(Parameters.GameMode.Play));
            }
            else
            {
                Debug.Log(Parameters.ChangeGameMode(Parameters.GameMode.Pause));
            }
        }
    }
    private void CheckHorizontalAxis()
    {
        onHorizontalAxis.OnAction(Input.GetAxisRaw("Horizontal"));
    }
    private void CheckVerticalAxis()
    {
        onVerticalAxis.OnAction(Input.GetAxisRaw("Vertical"));
    }
    private void CheckTouches()
    {
        Touch[] touches = Input.touches;
        // Short single tap
        if (IsSingleTap(touches))
        {
            onTap.OnAction(touches[0]);
            lastTouchTime = 0f;
        }
        else
        // Multiple touches OR no touches OR long touches
        {
            onTouches.OnAction(touches);
            lastTouchTime += Time.deltaTime;
        }
        lastFrameTouchCount = touches.Length;
    }
    private bool IsSingleTap(Touch[] touches)
    {
        return touches.Length == 1 && touches[0].tapCount == 1 && touches[0].phase == TouchPhase.Ended;
    }
}

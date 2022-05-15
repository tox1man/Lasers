using System;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    public static GUIController instance { get; set; }
    [SerializeField] private Sprite pauseButton;
    [SerializeField] private Sprite playButton;

    private RootScript root;
    private float deltaTime = 0.0f;

    public void Start()
    {
        if (instance != null)
            {
                Debug.LogWarning(this + " instance already exists. Cant make multiple instances of " + this);
        }
        instance = this;

        root = Parameters.GetRoot();
        InputController.instance.OnItemSelect.EventAction += ShowItemSelection;
        InputController.instance.OnItemDeselect.EventAction += HideItemSelection;
    }
    public void Update()
    {
        deltaTime = Time.deltaTime;
    }
    public void OnGUI()
    {
        ShowFPS();

        if (root.GameMode == Parameters.GameMode.ItemSelect)
        {

        }
    }
    private void ShowFPS()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 4 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }
    public void OnPauseButtonClick(Image buttonIcon)
    {
        if (Parameters.GetRoot().GameMode == Parameters.GameMode.Pause)
        {
            Parameters.ChangeGameMode(Parameters.GameMode.Play);
            buttonIcon.sprite = pauseButton;
        }
        else
        {
            Parameters.ChangeGameMode(Parameters.GameMode.Pause);
            buttonIcon.sprite = playButton;
        }
    }
    public void ShowItemSelection(GameObjectView view)
    {
         
    }
    public void HideItemSelection(GameObjectView view)
    {

    }
}

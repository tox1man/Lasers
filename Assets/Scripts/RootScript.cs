using UnityEngine;

public class RootScript : MonoBehaviour
{
    [Header("View components")]
    [SerializeField] private GameObjectView _playerView;

    private MainController _mainController;

    public void Start()
    {
        _mainController = new MainController(_playerView);
        _mainController.Start();
    }

    public void Update()
    {
        _mainController.Update();
    }

    public void FixedUpdate()
    {
        _mainController.FixedUpdate();
    }

    public void OnDestroy()
    {
        _mainController.OnDestroy();
    }
}
using UnityEngine;

public class RootScript : MonoBehaviour
{
    [Header("View components")]
    [SerializeField] private PlayerObjectView _playerView;
    [SerializeField] private EnemyObjectView _enemyView;

    [Header("Gizmos parameters")]
    [SerializeField] private bool _drawRenderSphere;
    [SerializeField] private bool _drawRenderPlane;
    [SerializeField] private bool _drawVisionCone;

    private MainController _mainController;

    public void Start()
    {
        _mainController = new MainController(_playerView, _enemyView);
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
            Vector3 leftRayDirection = Quaternion.Euler(0f, -Parameters.PLAYER_FOV / 2, 0f) * _playerView.transform.forward;
            Vector3 rightRayDirection = Quaternion.Euler(0f, Parameters.PLAYER_FOV / 2, 0f) * _playerView.transform.forward;

            Debug.DrawRay(_playerView.transform.position, leftRayDirection.normalized * 10, Color.cyan);
            Debug.DrawRay(_playerView.transform.position, rightRayDirection.normalized * 10, Color.cyan);

        }
    }
}
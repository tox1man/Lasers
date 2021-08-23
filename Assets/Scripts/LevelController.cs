using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject _floorTilePrefab;
    [SerializeField] private Vector2Int _levelSize;

    [SerializeField] [Range(1, 5)] private int _gridSize = 2;
    [SerializeField] [Range(0f, 1f)] private float _offsetSize;
    [SerializeField] private WaveMode _animationMode;

    private Dictionary<Vector2Int, Vector3> LevelGrid;
    private Dictionary<Vector2Int, TileObjectView> Tiles;

    private GameObject _level;

    public enum WaveMode
    {
        Horizontal,
        Vertical,
        Diagonal,
        Fall,
        Random
    }

    public void Start()
    {
        LevelGrid = new Dictionary<Vector2Int, Vector3>();
        Tiles = new Dictionary<Vector2Int, TileObjectView>();

        BuildLevel(new Vector2Int(_levelSize.x, _levelSize.y), _gridSize);
    }

    public void Update()
    {
        foreach (KeyValuePair<Vector2Int, TileObjectView> kvp in Tiles)
        {
            var tile = kvp.Value;
            tile.Phase += Time.deltaTime;
            if (tile.DoAnimate)  
            {
                AnimateTile(tile, tile.Frequency, tile.WaveAmplitude, tile.Phase, CalculatePhase(tile, _animationMode));
            }
        }
    }
    /// <summary>
    /// Animate tile in sin-wave.
    /// </summary>
    /// <param name="frequency"></param>
    /// <param name="amplitude"></param>
    /// <param name="offset"></param>
    /// <param name="phase"></param>
    private void AnimateTile(TileObjectView tile, float frequency, float amplitude, float offset, float phase)
    {
            float value = Mathf.Sin((offset + phase) * frequency) * amplitude;
            var newPos = new Vector3(tile.Transform.position.x, value - Parameters.LEVEL_TILE_HEIGHT / 2, tile.Transform.position.z);
            tile.Transform.position = newPos;
    }
    /// <summary>
    /// Animate tile in sin-wave.
    /// </summary>
    /// <param name="parameters">Vector4 with wave parameters. x - frequency, y - amplitude, z - offset, w - phase.</param>
    private void AnimateTile(TileObjectView tile, Vector4 parameters)
    {
        AnimateTile(tile, parameters.x, parameters.y, parameters.z, parameters.w);
    }

    public void BuildLevel(Vector2Int levelSize, int gridSize)
    {
        _level = new GameObject(Parameters.LEVEL_GAMEOBJECT_NAME);
        var offset = new Vector2(_gridSize * _offsetSize, _gridSize * _offsetSize);

        for (int i = 0; i < levelSize.x; i+=gridSize)
        {
            for(int j = 0; j < levelSize.y; j+=gridSize)
            {
                CreateTile(gridSize, i, j, offset);
            }
        }
    }

    private void CreateTile(int gridSize, int xRow, int yRow, Vector2 offset)
    {
        Vector2Int coord = new Vector2Int(xRow, yRow);
        Vector3 pos = new Vector3(xRow + offset.x * xRow, 0f, yRow + offset.y * yRow);

        var tileObject = GameObject.Instantiate(_floorTilePrefab, pos, Quaternion.identity, _level.transform);
        tileObject.transform.localScale = new Vector3(gridSize, Parameters.LEVEL_TILE_HEIGHT, gridSize);
        tileObject.transform.position += Vector3.down * (Parameters.LEVEL_TILE_HEIGHT / 2);
        tileObject.name = $"{_floorTilePrefab.name} {xRow}.{yRow}";

        var tileView = tileObject.GetComponent<TileObjectView>();
        tileView.Coordinates = coord;
        tileView.DoAnimate = true;

        LevelGrid.Add(coord, pos);
        Tiles.Add(coord, tileView);
    }

    private float CalculatePhase(TileObjectView tile, WaveMode mode)
    {
        float phase;
        switch (mode)
        {
            case WaveMode.Horizontal:
                phase = tile.Coordinates.x;
                break;
            case WaveMode.Vertical:
                phase = tile.Coordinates.y;
                break;
            case WaveMode.Diagonal:
                phase = tile.Coordinates.x + tile.Coordinates.y;
                break;
            case WaveMode.Fall:
                phase = tile.Transform.position.sqrMagnitude / 10;
                tile.WaveAmplitude = 0.1f;
                tile.Frequency = 2;
                break;
            case WaveMode.Random:
                phase = UnityEngine.Random.Range(0f, 1f) * 10f;
                break;
            default:
                phase = 0f;
                break;
        }
        return phase;
    }
}
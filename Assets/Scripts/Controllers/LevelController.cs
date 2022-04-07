using System.Collections.Generic;
using UnityEngine;
using static Parameters;

public class LevelController
{
    private RootScript _root;
    private StageData _stage;
    public Dictionary<Vector2Int, TileObjectView> Tiles { get; private set; }
    private GameObject _level;
    public void Start()
    {
        _root = GetRoot();
        _stage = _root.CurrentStage;

        Tiles = new Dictionary<Vector2Int, TileObjectView>();
        BuildLevel(new Vector2Int(_stage.Level.LevelSize.x, _stage.Level.LevelSize.y), _stage.Level.GridSize, _stage.Level.OffsetSize);
        ColorTiles(GetOuterTiles(), Color.blue);
    }
    public void Update()
    {
        foreach (KeyValuePair<Vector2Int, TileObjectView> kvp in Tiles)
        {
            var tile = kvp.Value;
            tile.Phase += Time.deltaTime;
            if (tile.DoAnimate)  
            {
                AnimateTile(tile, tile.Frequency, tile.WaveAmplitude, tile.Phase, CalculatePhase(tile, _stage.Level.AnimationMode));
            }
        }
    }
    public void BuildLevel(Vector2Int levelSize, int gridSize, float offsetSize)
    {
        string levelName = $"{LEVEL_GAMEOBJECT_NAME} {levelSize.x / gridSize}x{levelSize.y / gridSize}";
        var offset = new Vector2(offsetSize, offsetSize);
        _level = new GameObject(levelName);

        for (int i = 0; i < levelSize.x / gridSize; i++)
        {
            for(int j = 0; j < levelSize.y / gridSize; j++)
            {
                CreateTile(gridSize, i, j, offset);
            }
        }
    }
    private void CreateTile(int gridSize, int xRow, int yRow, Vector2 offset)
    {
        Vector2Int coord = new Vector2Int(xRow, yRow);
        Vector3 pos = new Vector3(xRow * (offset.x + 1), 0f, yRow * (offset.y + 1)) * gridSize;

        var tileObject = GameObject.Instantiate(_root.FloorTilePrefab, pos, Quaternion.identity, _level.transform);
        tileObject.transform.localScale = new Vector3(gridSize, LEVEL_TILE_HEIGHT, gridSize);
        tileObject.name = $"{_root.FloorTilePrefab.name} {xRow}.{yRow}";

        var tileView = tileObject.GetComponent<TileObjectView>();
        tileView.Coordinates = coord;
        tileView.Transform.position = pos;
        tileView.DoAnimate = true;
        
        Tiles.Add(coord, tileView);
    }
    public void ElevateTile(Vector2Int tileCoordinates, float elevation) 
    {
        Tiles[tileCoordinates].Elevation = elevation;
    }
    public void ElevateTile(int tileX, int tileY, float elevation) 
    {
        ElevateTile(new Vector2Int(tileX, tileY), elevation);
    }
    public TileObjectView GetRandomTile()
    {
        TileObjectView[] arr = new TileObjectView[_root.Level.Tiles.Values.Count];
        _root.Level.Tiles.Values.CopyTo(arr, 0);
        return arr[Random.Range(0, arr.Length)];
    }
    public TileObjectView[] GetOuterTiles()
    {
        Vector2Int mapSize = _stage.Level.LevelSize / _stage.Level.GridSize;
        TileObjectView[] outerTiles = new TileObjectView[(mapSize.x + mapSize.y) * 2 - 4]; // number of outer tiles is perimeter minus 4 corners.
        int index = 0;
        foreach (TileObjectView tile in Tiles.Values)
        {
            if(tile.Coordinates.x == 0 || tile.Coordinates.x == mapSize.x - 1)
            {
                outerTiles[index] = tile;
                index++;
                continue;
            }
            else if (tile.Coordinates.y == 0 || tile.Coordinates.y == mapSize.y - 1)
            {
                outerTiles[index] = tile;
                index++;
                continue;
            }
        }
        return outerTiles;
    }
    public TileObjectView GetRandomOuterTile()
    {
        TileObjectView[] outerTiles = GetOuterTiles();
        return outerTiles[Random.Range(0, outerTiles.Length)];
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
            var newPos = new Vector3(tile.Transform.position.x, /*tile.Elevation +*/ value, tile.Transform.position.z);
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
    private void ColorTiles(TileObjectView[] tiles, Color color)
    {
        foreach (var tile in tiles)
        {
            tile.GetComponent<Renderer>().material.color = color;
        }
    }
    private float CalculatePhase(TileObjectView tile, WaveMode mode)
    {
        float phase;
        switch (mode)
        {
            case WaveMode.Horizontal:
                phase = tile.Coordinates.x;
                tile.WaveAmplitude = 0.2f;
                tile.Frequency = 4;
                break;
            case WaveMode.Vertical:
                phase = tile.Coordinates.y;
                tile.WaveAmplitude = 0.2f;
                tile.Frequency = 4;
                break;
            case WaveMode.Diagonal:
                phase = tile.Coordinates.x + tile.Coordinates.y;
                tile.WaveAmplitude = 0.2f;
                tile.Frequency = 4;
                break;
            case WaveMode.Fall:
                phase = tile.Transform.position.sqrMagnitude / 10;
                tile.WaveAmplitude = 0.1f;
                tile.Frequency = 2;
                break;
            case WaveMode.Random:
                phase = Random.Range(0f, 1f) * 10f;
                tile.WaveAmplitude = 1f;
                tile.Frequency = 0.1f;
                break;
            default:
                phase = 0f;
                break;
        }
        return phase;
    }
}
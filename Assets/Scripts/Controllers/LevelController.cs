﻿using System.Collections.Generic;
using UnityEngine;
using static Parameters;

public class LevelController
{
    private RootScript root;
    private StageData stage;
    public Dictionary<Vector2Int, TileObjectView> Tiles { get; private set; }
    private GameObject level;
    public void Start()
    {
        root = GetRoot();
        stage = root.CurrentStage;

        Tiles = new Dictionary<Vector2Int, TileObjectView>();
        BuildLevel(new Vector2Int(stage.Level.LevelSize.x, stage.Level.LevelSize.y), stage.Level.GridSize, stage.Level.OffsetSize);
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
                tile.AnimateTile(CalculatePhase(tile, stage.Level.AnimationMode));
            }
        }
    }
    public void BuildLevel(Vector2Int levelSize, int gridSize, float offsetSize)
    {
        string levelName = $"{LEVEL_GAMEOBJECT_NAME} {levelSize.x}x{levelSize.y}";
        var offset = new Vector2(offsetSize, offsetSize);
        level = new GameObject(levelName);

        for (int i = 0; i < levelSize.x; i++)
        {
            for(int j = 0; j < levelSize.y; j++)
            {
                CreateTile(gridSize, i, j, offset);
            }
        }
    }
    private void CreateTile(int gridSize, int xRow, int yRow, Vector2 offset)
    {
        Vector2Int coord = new Vector2Int(xRow, yRow);
        Vector3 pos = new Vector3(xRow * (offset.x + 1), 0f, yRow * (offset.y + 1)) * gridSize;

        var tileObject = GameObject.Instantiate(root.FloorTilePrefab, pos, Quaternion.identity, level.transform);
        tileObject.transform.localScale = new Vector3(gridSize, LEVEL_TILE_HEIGHT, gridSize);
        tileObject.name = $"{root.FloorTilePrefab.name} {xRow}.{yRow}";

        var tileView = tileObject.GetComponent<TileObjectView>();
        tileView.Coordinates = coord;
        tileView.Transform.position = pos;
        tileView.DoAnimate = true;

        int tileNumber = xRow * stage.Level.LevelSize.y + yRow;
        if (tileNumber > stage.Level.Elevations.Count-1)
        {
            stage.Level.Elevations.Add(false);
        }
        tileView.Elevated = stage.Level.Elevations[tileNumber];
        
        Tiles.Add(coord, tileView);
    }
    public TileObjectView GetRandomTile()
    {
        TileObjectView[] arr = new TileObjectView[root.Level.Tiles.Values.Count];
        root.Level.Tiles.Values.CopyTo(arr, 0);
        return arr[Random.Range(0, arr.Length)];
    }
    public TileObjectView[] GetOuterTiles()
    {
        Vector2Int mapSize = stage.Level.LevelSize;
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
    public void ColorTiles(TileObjectView[] tiles, Color color)
    {
        foreach (var tile in tiles)
        {
            tile.ColorTile(color);
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
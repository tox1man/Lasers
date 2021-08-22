using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] private GameObject _floorTilePrefab;
    [SerializeField] private Vector2Int _levelSize;

    [SerializeField] [Range(1, 5)] private int _gridSize = 2;
    [SerializeField] [Range(0f, 1f)] private float _offsetSize;
    
    public Dictionary<Vector2Int, Vector3> LevelGrid;
    public Dictionary<Vector2Int, LevelTileObjectView> Tiles;
    
    private Vector2 _offset;
    private GameObject _level;
    
    public void Start()
    {
        _offset = new Vector2(_gridSize * _offsetSize, _gridSize * _offsetSize);
        LevelGrid = new Dictionary<Vector2Int, Vector3>();

        BuildLevel(new Vector2Int(_levelSize.x, _levelSize.y), _gridSize, out Tiles);
        StartCoroutine(Anim());
    }

    public void Update()
    {
       
    }

    public IEnumerator Anim()
    {
        foreach (KeyValuePair<Vector2Int, LevelTileObjectView> kvp in Tiles)
        {
            yield return new WaitForSeconds(0.1f);
            Debug.Log(Time.realtimeSinceStartup);
            kvp.Value.DoAnimate = true;
        }
        StopCoroutine(Anim());
    }

    public void BuildLevel(Vector2Int levelSize, int gridSize, out Dictionary<Vector2Int, LevelTileObjectView> tiles)
    {
        tiles = new Dictionary<Vector2Int, LevelTileObjectView>();
        _level = new GameObject(Parameters.LEVEL_GAMEOBJECT_NAME);

        for(int i = 0; i < levelSize.x; i+=gridSize)
        {
            for(int j = 0; j < levelSize.y; j+=gridSize)
            {
                Vector3 pos = new Vector3(j + _offset.x * j, 0f, i + _offset.y * i);

                var tileObject = GameObject.Instantiate(_floorTilePrefab, pos, Quaternion.identity, _level.transform);
                var tileView = tileObject.GetComponent<LevelTileObjectView>();
                tileObject.transform.localScale = new Vector3(gridSize, Parameters.LEVEL_TILE_HEIGHT, gridSize);
                tileObject.transform.position += Vector3.down * (Parameters.LEVEL_TILE_HEIGHT / 2);
                tileObject.name = $"{_floorTilePrefab.name} {i}.{j}";

                LevelGrid.Add(new Vector2Int(i, j), pos);
                tiles.Add(new Vector2Int(i, j), tileView);
            }
        }
    }
}
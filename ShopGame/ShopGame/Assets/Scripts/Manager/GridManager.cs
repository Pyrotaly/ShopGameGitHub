using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;

    [SerializeField] private int width, height;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Transform cam;

    //JustToOrganizeTiles
    public Transform TileFolder;

    private Dictionary<Vector2, Tile> tiles;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
    }

    public void GenerateGrid()
    {
        tiles = new Dictionary<Vector2, Tile>();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Tile spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.x = x; 
                spawnedTile.y = y;
                spawnedTile.name = $"Tile {x} {y}";
                spawnedTile.transform.SetParent(TileFolder, true);

                bool isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);      //Every other tile will have diff color

                spawnedTile.Init(isOffset);
                tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
    }
    
    public Tile GetTileAtPosition(Vector2 pos)
    {
        if (tiles.TryGetValue(pos, out Tile tile)) return tile;
        return null;
    }
}
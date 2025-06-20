using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMap : MonoBehaviour
{
    public GameObject tilePrefab;
    public TileData grassTileData;
    public TileData waterTileData;

    public int MapWidth = 25;
    public int MapHeight = 25;

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        for (int x = 0; x < MapWidth; x++)
        {
            for (int y = 0; y < MapHeight; y++)
            {
                Vector2 position = new Vector2(x, y);
                GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity, transform);
                tile.name = $"Tile_{x}_{y}";

                Tile tileComponent = tile.GetComponent<Tile>();
                if (tileComponent != null)
                {
                    // Edge = Water, Inner = Grass
                    bool isEdge =
                        x == 0 || y == 0 ||
                        x == MapWidth - 1 || y == MapHeight - 1;

                    TileData selectedData = isEdge ? waterTileData : grassTileData;

                    tileComponent.data = selectedData;

                    // Apply the correct sprite
                    SpriteRenderer sr = tile.GetComponent<SpriteRenderer>();
                    if (sr != null)
                    {
                        sr.sprite = selectedData.sprite;
                    }
                }
            }
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMap : MonoBehaviour
{
    public GameObject tilePrefab;
    public TileData defaultTileData;
    
    
    
    //Map Size
    public int MapWidth = 25;
    public int MapHeight = 25;
    
    // Start is called before the first frame update
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
                Vector2 postion = new Vector2(x, y);
                GameObject tile = Instantiate(tilePrefab, postion, Quaternion.identity, transform);

                Tile tileComponent = tile.GetComponent<Tile>();
                if (tileComponent != null)
                {
                    tileComponent.data = defaultTileData;
                }
            }
        }
    }
}

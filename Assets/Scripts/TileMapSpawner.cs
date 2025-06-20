using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapSpawner : MonoBehaviour
{
    public int mapWidth = 25;
    public int mapHeight = 25;
    public float tileSize = 1f;
    public GameObject tilePrefab;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                spawnTile(i,j);
            }

        }
    }



    private void spawnTile(int i,int j)
    {
        //Calculate the tile's position in the world
        Vector2 position = new Vector2(i * tileSize, j * tileSize);
        //Make the new tile apear
        GameObject newTile = Instantiate(tilePrefab, position, Quaternion.identity);
        //Set the parent of the new tile to "TileMapSpawner" the public class that this script is attached too.
        newTile.transform.parent = transform;
        // Assign a unique name using (i, j) format
        newTile.name = $"Tile ({i}, {j})";
    }
    

}

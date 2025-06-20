//this script is to be used in the prefab of the tile spawner. 
//It will be where I store all of the data for each tile.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData : MonoBehaviour
{
    //Basic data for each tile
    public Vector2Int gridPos;
    public bool isWalkable;
    public bool hasBuilding;
    public bool canConstruct;
    public TileType tileType;

    //Tile Types
    public enum TileType
    {
        Grass,
        Forest,
        Mountain,
        Water
    }
    

    public int chosenTileIndex = -1; //start with a value that can't be a tile.
    // Array to store different sprites for different tile types
    public Sprite[] tileSprites;


    void Start()
    {

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>(); // Access SpriteRenderer component
        //finds the number of sprites available
        int numTileTypes = tileSprites.Length;
        //choose a random tile to place
        int randTileNum = Random.Range(0, tileSprites.Length);
        spriteRenderer.sprite = tileSprites[randTileNum];
        chosenTileIndex = randTileNum;
        tileType = (TileType)randTileNum;

        
        //fill in the data for each tile type based on the tile chosen.
        switch (tileType)
        {
            case TileType.Grass:
                isWalkable = true;
                canConstruct = true;
                break;
            case TileType.Forest:
                isWalkable = true;
                canConstruct = false;
                break;
            case TileType.Mountain:
                isWalkable = false;
                canConstruct = false;
                break;
            case TileType.Water:
                isWalkable = false;
                canConstruct = false;
                break;
        }
        // Add more conditions as needed for other tile types
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RTS/TileData")]

public class TileData : ScriptableObject
{
    public string tileName;
    public Sprite sprite;
    public bool walkable;
    public int movementCost;
    public Color minimapColor;
}

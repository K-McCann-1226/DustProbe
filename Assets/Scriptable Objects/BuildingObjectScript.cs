using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RTS/BuildingData")]

public class BuildingObjectScript : ScriptableObject
{
    public string buildingName;
    public GameObject prefab;    
    public int cost;
    public float buildTime;
    public int HP;

}

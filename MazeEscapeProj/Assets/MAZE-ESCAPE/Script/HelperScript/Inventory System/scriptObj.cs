using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Floor", menuName = "kg/FloorTile", order = 0)]

public class scriptObj : ScriptableObject
{
    string ItemName;
    string ItemID;
    string ItemDesc;
    Sprite ItemIcon;
    GameObject ItemPrefab;
    int MaxStack;
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tile", menuName = "Tile")]
public class TileScriptable : ScriptableObject
{
    public enum ResourceType
    {
        Wood, Rock, Gold, Wheat, Cattle
    }

    public ResourceType _resourceType = 0;

    public bool hasBonus = false;
    public bool hasBulding = false;
    public int howMuchCanProduce;
}

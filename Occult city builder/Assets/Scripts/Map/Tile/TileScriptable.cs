using System.Collections;
using System.Collections.Generic;
using Recources;
using UnityEditor.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tile", menuName = "Tile")]
public class TileScriptable : ProductionScriptable
{

    public enum TileResourceType
    {
        Wood, Rock, Gold, Wheat, Cattle
    }
    public ResourceType _tileResourceType = 0;
}

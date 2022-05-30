using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Building")]
public class BuildingScriptable : ScriptableObject
{
    public enum ResourceType
    {
        Wood, Rock, Gold, Wheat, Cattle
    }

    public ResourceType _resourceType = 0;
    public bool hasWorker = false;

}

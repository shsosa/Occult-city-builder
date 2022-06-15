using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "New Resource Type Data", fileName = "ResourceTypeData")]
public class ResourceTypeData : ScriptableObject
{
    public enum ResourceType
    {
        Wood, Gold, Vilagers, ResearchPoints, Cattle
    }
    public ResourceType _resourceType,resourceTypeToBuild;
    public int bonus,priceToBuild;
}

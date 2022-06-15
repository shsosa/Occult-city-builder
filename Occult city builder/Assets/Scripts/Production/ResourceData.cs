using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "New Resource Data", fileName = "ResourceData")]
public class ResourceData : ScriptableObject
{
    public int wood;
    public int gold;
    public int vilagers;
    public int researchPoints;
    public int cattle;
    public void IncreaseResource(ResourceTypeData.ResourceType resourceType, int resourcesTAdd)
    {
        Debug.Log("resource: "+ resourceType);
        switch (resourceType)
        {
            case ResourceTypeData.ResourceType.Wood:
                wood += resourcesTAdd;
                break;
            case ResourceTypeData.ResourceType.Gold:
                gold += resourcesTAdd;
                break;
            case ResourceTypeData.ResourceType.Vilagers:
                vilagers += resourcesTAdd;
                break;
            case ResourceTypeData.ResourceType.ResearchPoints:
                researchPoints += resourcesTAdd;
                break;
            case ResourceTypeData.ResourceType.Cattle:
                cattle += resourcesTAdd;
                break;
            default:
                Debug.Log("Incorrect resource");
                break; 
        }
    }
}

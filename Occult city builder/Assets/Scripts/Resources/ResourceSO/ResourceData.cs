using System.Collections;
using System.Collections.Generic;
using Game_managment;
using UnityEngine;
[CreateAssetMenu(menuName = "New Resource Data", fileName = "ResourceData")]
public class ResourceData : ScriptableObject
{
    #region int Resources
    
    public int wood;
    public int gold;
    public int vilagers;
    public int researchPoints;
    public int cattle;
    

    #endregion
    
    //todo check possibility to make a scriptable for tile also so it can produce some other resources
    
  
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

    public void SpendReasource(ReasourcePrice reasourcePrice)
    {
        wood -= reasourcePrice.wood;
        gold -= reasourcePrice.gold;
        cattle -= reasourcePrice.cattle;
        researchPoints -= reasourcePrice.researchPoints;
        vilagers -= reasourcePrice.vilagers;
    }
    
    
    
    
}

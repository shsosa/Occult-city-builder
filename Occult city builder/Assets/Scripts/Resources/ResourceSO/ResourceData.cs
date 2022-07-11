using System;
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
    private void OnEnable()
    {
        
    }

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

    public  string  CheckIfHasSpesificResource(ReasourcePrice reasourcePrice)
    {
        string price = null;


        if (reasourcePrice.wood != 0)
        {
            if (reasourcePrice.wood > wood)
                price += "<color=red>Wood: " + reasourcePrice.wood +"</color>"+" \n";
            else
            {
                price += "Wood: " + reasourcePrice.wood + " \n";
            }
           
        }



        if (reasourcePrice.cattle != 0)
        {
            if (reasourcePrice.cattle > cattle)
                price += "<color=red>Cattle: " + reasourcePrice.cattle +"</color>"+ " \n";
            else
            {
                price += "Cattle: " + reasourcePrice.cattle + " \n";
            }
            
        }

        if (reasourcePrice.researchPoints != 0)
        {
            if (reasourcePrice.researchPoints > researchPoints)
                price += "<color=red>Research: " + reasourcePrice.researchPoints +"</color>"+ " \n";
            else
            {
                price += "Research: " + reasourcePrice.researchPoints + " \n";
            }
           
        }

        if (reasourcePrice.gold != 0)
        {
            
            if (reasourcePrice.gold > gold)
                price += "<color=red>Gold: " + reasourcePrice.gold +"</color>"+ " \n";
            else
            {
                price += "Gold: " + reasourcePrice.gold+ " \n";
            }
           
        }

        if (reasourcePrice.vilagers != 0)
        {
            if (reasourcePrice.vilagers > vilagers)
                price += "<color=red>Villagers : " + reasourcePrice.vilagers +"</color>"+ " \n";
            else
            {
                price += "Villagers: " + reasourcePrice.vilagers + " \n";
            }
            
        }
            
        Debug.Log("Price: " + price);
        return price;
    }
}

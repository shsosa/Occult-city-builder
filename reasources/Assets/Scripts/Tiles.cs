using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    [SerializeField] ResourceTypeData type;
    public ResourceTypeData building;
    private bool hasBuilding;
    public int amountOfReasourceProdused;
    private void Start()
    {
        building = GetComponentInChildren<ResourceTypeData>();    
    }
    public void TileProduction()
    {
        if (hasBuilding)
        {
            amountOfReasourceProdused = 1;
            if (building._resourceType == type._resourceType)
            {
                amountOfReasourceProdused += building.bonus;
            }
        }
        else
        { 
            amountOfReasourceProdused = 0;
        }
    }
}

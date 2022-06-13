using System;
using System.Collections;
using System.Collections.Generic;
using InputMouse;
using Unity.VisualScripting;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    [SerializeField] ResourceTypeData type;
    public ResourceTypeData building;
    public bool hasBuilding =false;
    public int amountOfReasourceProdused;
    private void Start()
    {
  
            if(building!= null)
                building = GetComponentInChildren<Building>()._resourceTypeData;
        
    }

    

    private void OnCollisionStay2D(Collision2D col)
    {
        
       
        
        
    }

    public void TileProduction()
    {
        if (hasBuilding)
        {
            building = GetComponentInChildren<Building>()._resourceTypeData;
            Debug.Log("calls production");
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

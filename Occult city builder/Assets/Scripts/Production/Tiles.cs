using System;
using System.Collections;
using System.Collections.Generic;
using InputMouse;
using Unity.VisualScripting;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    public ResourceTypeData type;
    public ResourceTypeData building;
    public bool hasBuilding =false;
    public int amountOfReasourceProdused;
    private PolygonCollider2D _polygonCollider2D;
    private void Start()
    {

        _polygonCollider2D = GetComponent<PolygonCollider2D>();
            if(building!= null)
                building = GetComponentInChildren<Building>()._resourceTypeData;
        
    }

    private void Update()
    {
        if (hasBuilding)
        {
            _polygonCollider2D.isTrigger = false;
            building = GetComponentInChildren<Building>()._resourceTypeData;
            
        }
        else
        {
            _polygonCollider2D.isTrigger = true;
        }
            
        
        
    }

    

    public void TileProduction()
    {
        if (hasBuilding)
        {
           
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

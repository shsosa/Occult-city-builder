using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProductionMono : MonoBehaviour
{
    [SerializeField] ResourceManager resourceManager;
    Tile[] listOfTiles;
    
   
    public int howMuchCanProduce;
    private int totalProductionOfResorcePerUnitOfTime;

    private void Start()
    {
        Debug.Log("start method " + gameObject.name);
        listOfTiles = GetComponentsInChildren<Tile>();
    }
   
   private void ResourceProduction(string resourceTipe)
    {
        for (int i = 0; i < listOfTiles.Length; ++i)
        {
            listOfTiles[i].TileProduction();
            
        }
    }
    private void ResourceReduction()
    { 
    
    }
    
}

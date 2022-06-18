using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Production : MonoBehaviour
{
    [SerializeField] ResourceData resourceData;
   // [SerializeField] ResourceTypeData typeData;
    [SerializeField] private int secondsToWait = 3;
    [SerializeField]Tiles[] tile;
    private int resource;

    private void Start()
    {
        tile = GetComponentsInChildren<Tiles>();
       // StartCoroutine(ProductionTimer());
    }
    private void Update()
    {

       
    }

    private void ResourceProduction()
    {
        Debug.Log("prouction");
        for (int i = 0; i < tile.Length; ++i)
        {
           
            tile[i].TileProduction();
            resource += tile[i].amountOfReasourceProdused;
            switch (tile[i].building._resourceType)
            {
                case ResourceTypeData.ResourceType.Wood:
                    resourceData.wood += resource;
                    break;
                case ResourceTypeData.ResourceType.Gold:
                    resourceData.gold += resource;
                    break;
                case ResourceTypeData.ResourceType.Vilagers:
                    resourceData.vilagers += resource;
                    break;
                case ResourceTypeData.ResourceType.ResearchPoints:
                    resourceData.researchPoints += resource;
                    break;
                case ResourceTypeData.ResourceType.Cattle:
                    resourceData.cattle += resource;
                    break;
                default:
                    Debug.Log("Incorrect resource");
                    break;
            }
            resource = 0;
        }
    }
    private void ResourceReduction()
    {

    }
    private IEnumerator ProductionTimer()
    {
        ResourceProduction();
        yield return new WaitForSeconds(secondsToWait);
        
        StartCoroutine(ProductionTimer());
        
    }
}
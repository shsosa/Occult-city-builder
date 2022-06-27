using System;
using System.Collections.Generic;
using Game_managment;
using InputMouse;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{

    //todo maybe build from here if i get tile and building from mouse
    [Header("Event channels: ")]
    public VoidEventChannelSO BuildEventChannelSo;
    public VoidEventChannelSO buildUIEventChannelSo;
    
    [Header("Active objects to build: ")]
    public GameObject tile;
    public GameObject building;
    
    [Header("Building manager objects: ")]
    [SerializeField]  private Transform map;
    [SerializeField] private SecreficeManager SecrificeManager;
    [SerializeField] private ReserchManager reserchManager;
   

    public bool hasInstantiatedBuilding = false;

    private void OnEnable()
    {
        BuildEventChannelSo.OnEventRaised += SetBuildingNull;
    }

    private void OnDisable()
    {
        BuildEventChannelSo.OnEventRaised -= SetBuildingNull;
    }

    private void Update()
    {
        

        if (building != null && tile != null)
        {
            Building currentBuilding = building.GetComponent<Building>();
            Tiles currentTile = tile.GetComponent<Tiles>();
            
            currentBuilding.tile = tile;

          
            if(!currentTile.hasBuilding && !currentTile.isCursed) 
                    currentBuilding.PlaceBuildingOnTile();
            
        }

        
    }


    #region Resource Data - SO

    public ResourceData _resourceData;
    public List<ReasourcePrice> _reasourcePrices;

    #endregion

    #region Checks if current resources allows to build

    /// <summary>
    /// Checks if can build , list of buildings are SO and set from inspector
    /// </summary>
    /// <param name="uiObject"></param>
    /// <returns></returns>
    public bool CheckIfCanBuild(UIObject uiObject)
    {
        bool canBuild = false;
        {
           
            for (int i = 0; i < _reasourcePrices.Count; i++)
            {
                //todo change logic to something else not name
                if (uiObject._reasourcePrice == _reasourcePrices[i])
                {

                    canBuild =
                        (_reasourcePrices[i].cattle <= _resourceData.cattle) && 
                        (_reasourcePrices[i].gold <= _resourceData.gold) && 
                        (_reasourcePrices[i].vilagers <= _resourceData.vilagers) &&
                        (_reasourcePrices[i].wood <= _resourceData.wood) &&
                        (_reasourcePrices[i].researchPoints <= _resourceData.researchPoints); 
                       
                    goto ExitLoop;
                        
                }
                    
            }
                
            ExitLoop:
            return canBuild;


        }

    }

    #endregion

    public void Build(GameObject buildingPB, Transform uiButtonPos)
    {
        building = Instantiate(buildingPB, uiButtonPos.position, Quaternion.identity);
        
        AttachBuildingToManager();
        
        
        //Instantiate Event
        buildUIEventChannelSo.RaiseEvent();
        
        if(building.CompareTag("Building"))
            hasInstantiatedBuilding = true;
        

    }

    private void AttachBuildingToManager()
    {
        Building buildingInstance = building.GetComponent<Building>();
        building.transform.SetParent(map);
        switch (buildingInstance._typeOfDraggableItem)
        {
            case Building.TypeOfDraggableItem.Building:
               
                break;

            case Building.TypeOfDraggableItem.Secrifice:
                SecrificeManager.listOfActiveSacrificeBuildings.Add(buildingInstance);
                break;

            case Building.TypeOfDraggableItem.Research:
                reserchManager.listOfActiveResearchBuildings.Add(buildingInstance);
                break;
        }
    }

    public void DetachBuildingFromManager(Building building)
    {
        switch (building._typeOfDraggableItem)
        {
            case Building.TypeOfDraggableItem.Building:
               
                break;

            case Building.TypeOfDraggableItem.Secrifice:
                SecrificeManager.listOfActiveSacrificeBuildings.Remove(building);
                break;

            case Building.TypeOfDraggableItem.Research:
                reserchManager.listOfActiveResearchBuildings.Remove(building);
                break;
        }
    }

    void SetBuildingNull()
    {
        building = null;
        tile = null;
        hasInstantiatedBuilding = false;
    }

}

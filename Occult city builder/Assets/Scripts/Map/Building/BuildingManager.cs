using System;
using System.Collections.Generic;
using Game_managment;
using InputMouse;
using UI.Tooltip;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{

    //todo maybe build from here if i get tile and building from mouse
    [Header("Event channels: ")]
    public VoidEventChannelSO buildEventChannelSo;
    public VoidEventChannelSO buildUIEventChannelSo;
    
  
    
    [Header("Active objects to build: ")]
    public GameObject tile;
    public GameObject building;
    
    [Header("Building manager objects: ")]
    [SerializeField]  private MapObjects map;
    [SerializeField] private SecreficeManager SecrificeManager;
    [SerializeField] private ReserchManager reserchManager;
    private UIManager _uiManager;

    public TooltipTextSO toolTipHasBonus;
   

    public static bool hasInstantiatedBuilding = false;
   

    private void OnEnable()
    {
        buildEventChannelSo.OnEventRaised += SetBuildingNull;
       
        _uiManager = FindObjectOfType<UIManager>();

    }

    private void OnDisable()
    {
        buildEventChannelSo.OnEventRaised -= SetBuildingNull;
      
    }

    private void Update()
    {
        var isObjectsActive = building != null && tile != null && !GameManager.isEventUIActive;
        
        if (isObjectsActive)
        {
            //Set current active objects scripts
            Building currentBuilding = building.GetComponent<Building>();
            Tiles currentTile = tile.GetComponent<Tiles>();
            currentBuilding.tile = tile;

            
            Build(currentBuilding, currentTile);
               
            BlessCursedTile(currentBuilding, currentTile);

            ActivateHolySite(currentTile, currentBuilding);
        }
    }

    private static void Build(Building currentBuilding, Tiles currentTile)
    {
        if (currentBuilding.CompareTag("Building"))
        {
            TileHasBuildingFeedback(currentTile, currentBuilding);
            
            HoverOnTileWithBuildingFeedback(currentTile, currentBuilding);
            
            if (!currentTile.CompareTag("HolyTile"))
                PlaceBuildingOnTile(currentTile, currentBuilding);
        }
    }
    private static void PlaceBuildingOnTile(Tiles currentTile, Building currentBuilding)
    {
        if (!currentTile.hasBuilding && !currentTile.isCursed)
            currentBuilding.PlaceBuildingOnTile();
        
       
    }
    private static void HoverOnTileWithBuildingFeedback(Tiles currentTile, Building currentBuilding)
    {
        if (!currentTile.hasBuilding && !currentTile.isCursed)
        {
            if (currentBuilding.CompareTag("Building"))
            {
                if (currentBuilding.CheckIfGetsResourceBonus(currentTile, currentBuilding) &&
                    !currentTile.CompareTag("HolyTile"))
                {
                    currentTile.ChangeTileColor(Color.green);
                   
                }
                   
                if(currentBuilding._typeOfDraggableItem == Building.TypeOfDraggableItem.Research && currentTile.isHoly)
                    currentTile.ChangeTileColor(Color.green);
                currentTile.TileHoverEffect();
            }
        }
    }
    private static void TileHasBuildingFeedback(Tiles currentTile , Building currentBuilding)
    {
        if (currentTile.hasBuilding && currentBuilding.CompareTag("Building") || currentBuilding.CompareTag("Building")&& currentTile.CompareTag("HolyTile") )
        {
            currentTile.ChangeTileColor(Color.red);
            if(!currentBuilding.isDragged && currentTile.isCursed || !currentBuilding.isDragged && currentTile.CompareTag("HolyTile"))
                Destroy(currentBuilding.gameObject);
            if(!currentBuilding.isDragged&& currentTile.hasBuilding ||  !currentBuilding.isDragged && currentTile.CompareTag("HolyTile"))
                Destroy(currentBuilding.gameObject);
        }
    }
    
    

    private static void BlessCursedTile(Building currentBuilding, Tiles currentTile)
    {
        if (currentBuilding._typeOfDraggableItem == Building.TypeOfDraggableItem.Secrifice && currentTile.isCursed)
        {
            if (currentBuilding.CompareTag("Spell")&& currentTile!= null)
            {
                if (currentBuilding.isDragged && currentTile.isCursed)
                {
                    currentTile.TileHoverEffect();
                    currentTile.ChangeTileColor(Color.blue);
                }
                    
               else if (!currentBuilding.isDragged)
                {
                   
                    currentBuilding.DecreaseReasourceCost();
                    currentTile.SetNotCursed();
                    if(!currentTile.isCursed)
                        Destroy(currentBuilding.gameObject);
                }
                
            }
        }

        if (!currentBuilding.isDragged && !currentTile.isCursed && currentBuilding.CompareTag("Spell") && currentBuilding._typeOfDraggableItem == Building.TypeOfDraggableItem.Secrifice)
        {
            Destroy(currentBuilding.gameObject);
        }
        
        
    }
    private static void ActivateHolySite(Tiles currentTile, Building currentBuilding)
    {
        if (currentTile.CompareTag("HolyTile") && !currentBuilding.CompareTag("Building"))
        {
            if (currentBuilding._typeOfDraggableItem == Building.TypeOfDraggableItem.Research &&
                !currentTile.hasBuilding)
            {
                if (currentBuilding.isDragged && !currentTile.hasBuilding)
                    currentTile.TileHoverEffect();
                if (!currentBuilding.isDragged && !currentTile.hasBuilding)
                {
                    currentTile.ActivateSacredSite();
                    currentBuilding.PlaceBuildingOnTile();
                }
            }
        }

        if (currentBuilding._typeOfDraggableItem == Building.TypeOfDraggableItem.Research &&
            currentTile.CompareTag("Tile") && !currentBuilding.isDragged && !currentBuilding.CompareTag("Building"))
        {
            Destroy(currentBuilding.gameObject);
        }
    }


   


    #region Resource Data - SO

    public ResourceData _resourceData;
    [SerializeField] List<ReasourcePrice> _reasourcePrices;

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

    public void InstantiateBuilding(GameObject buildingPB, Transform uiButtonPos)
    {
        building = Instantiate(buildingPB, uiButtonPos.position, Quaternion.identity);
        hasInstantiatedBuilding = true;
        AttachBuildingToManager();
        
        
        //Instantiate Event
        buildUIEventChannelSo.RaiseEvent();
        
      
           
        

    }

    private void AttachBuildingToManager()
    {
        Building buildingInstance = building.GetComponent<Building>();
       // building.transform.SetParent(map);
        switch (buildingInstance._typeOfDraggableItem)
        {
            case Building.TypeOfDraggableItem.Building:
               map.activeBuildingsOnmap.Add(buildingInstance);
                break;

            case Building.TypeOfDraggableItem.Secrifice:
                SecrificeManager.listOfActiveSacrificeBuildings.Add(buildingInstance);
                map.activeBuildingsOnmap.Add(buildingInstance);
                break;

            case Building.TypeOfDraggableItem.Research:
                if(!buildingInstance.gameObject.CompareTag("Spell"))
                    reserchManager.listOfActiveResearchBuildings.Add(buildingInstance);
                map.activeBuildingsOnmap.Add(buildingInstance);
                break;
        }
    }

    public void DetachBuildingFromManager(Building building)
    {
        switch (building._typeOfDraggableItem)
        {
            case Building.TypeOfDraggableItem.Building:
                map.activeBuildingsOnmap.Remove(building);
               
                break;

            case Building.TypeOfDraggableItem.Secrifice:
                SecrificeManager.listOfActiveSacrificeBuildings.Remove(building);
                map.activeBuildingsOnmap.Remove(building);
                break;

            case Building.TypeOfDraggableItem.Research:
                if(!building.gameObject.CompareTag("Spell"))
                    reserchManager.listOfActiveResearchBuildings.Remove(building);
                map.activeBuildingsOnmap.Remove(building);
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

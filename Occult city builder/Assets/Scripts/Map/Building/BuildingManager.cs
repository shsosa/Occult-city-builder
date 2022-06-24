using System;
using System.Collections.Generic;
using Game_managment;
using InputMouse;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{

    //todo maybe build from here if i get tile and building from mouse

    public GameObject tile;
    [SerializeField] private GameObject building;
    [SerializeField]  private Transform map;
    public VoidEventChannelSO BuildEventChannelSo;

    public bool hasInstantiatedBuilding = false;

    private void OnEnable()
    {
        BuildEventChannelSo.OnEventRaised += SetBuildingNull;
    }

    private void Update()
    {
        

        if (building != null && tile != null)
        {
            building.GetComponent<Building>().tile = tile;
            
               if(!tile.GetComponent<Tiles>().hasBuilding) 
                    building.GetComponent<Building>().Build();
            
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
        building.transform.SetParent(map);
        
    }

    void SetBuildingNull()
    {
        building = null;
        tile = null;
    }

}

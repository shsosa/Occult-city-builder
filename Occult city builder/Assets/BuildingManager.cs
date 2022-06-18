using System;
using System.Collections;
using System.Collections.Generic;
using Game_managment;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    
    //todo id for resource types
    //todo ask richter when does he build a class with in a class what are the use cases
    
    public ResourceData _resourceData;
    public List<ReasourcePrice> _reasourcePrices;
    
    
    public bool CheckIfCanBuild(UIObject uiObject)
    {
        bool canBuild = false;
        {
           
                for (int i = 0; i < _reasourcePrices.Count; i++)
                {
                    //todo change logic to something else not name
                    if (uiObject.name == _reasourcePrices[i].name)
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

    

   
}

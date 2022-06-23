using System.Collections.Generic;
using Game_managment;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    

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
   
    
   
}

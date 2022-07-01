using System;
using System.Collections.Generic;
using Game_managment;
using InputMouse;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIObjectInfo : MonoBehaviour
{
    
    
    private bool _canIstantiateNewBuilding = true;
   
    private UIObject _currentObjectFromMouse;

    #region Mono
    

    void Update()
    {
        CheckIfMouseOverObject();
        CheckIfCanInstantiateBuilding();
        
        
            GetBuildingPrice();
        
           
    }

    public string GetBuildingPrice()
    {
        if (_currentObjectFromMouse != null)
        {
            ReasourcePrice building = _currentObjectFromMouse._reasourcePrice;
            Debug.Log("Price " + "Wood :" + building.wood + " " + "Cattle: " + building.cattle + " " + "Gold :" +
                      building.gold + " " + "Villegers :" + building.vilagers + " " + "Research points :" +
                      building.researchPoints);
            return "Price " + "Wood :" + building.wood + " " + "Cattle: " + building.cattle + " " + "Gold :" +
                   building.gold + " " + "Villegers :" + building.vilagers + " " + "Research points :" +
                   building.researchPoints;
        }

        return null;
    }

    #endregion
    
    #region Mouse position
    
    private void CheckIfMouseOverObject()
    {
        MouseHoverUIHighlight();
      
    }
    private void MouseHoverUIHighlight()
    {
        if (_currentObjectFromMouse != null)
        {
            if (_currentObjectFromMouse == CurrentObjectFromMouse())
            {
                _currentObjectFromMouse.ChangeScale();
            }

            if (_currentObjectFromMouse != CurrentObjectFromMouse())
            {
                _currentObjectFromMouse.RevertScaleToOG();
            }
        }

        if (GetMousePos())
            _currentObjectFromMouse = CurrentObjectFromMouse();
    }

    private static UIObject CurrentObjectFromMouse()
    {
        return MouseHover.GetUIObject("BuildingUI")?.GetComponent<UIObject>();
    }

    bool GetMousePos()
    {
        return  EventSystem.current.IsPointerOverGameObject();
    }
    
    
    
    /*
   public GameObject GetUIObject(string tagName)
   {
       return MouseHover.GetUIObject(tagName);

   }
    */

    #endregion

    #region Check if can build

    void CheckIfCanInstantiateBuilding()
    {
        
        if (GetMousePos() && Input.GetMouseButtonDown(0))
        {
            
            if (_currentObjectFromMouse != null && _currentObjectFromMouse.canBuild)
            {
                _currentObjectFromMouse.CreateBuldingFromUI();
                _currentObjectFromMouse.GetComponent<MMFeedbacks>().PlayFeedbacks();
                
                _canIstantiateNewBuilding = false;
            }
        }
        else
        {
            _canIstantiateNewBuilding = true;
        }
    }

    #endregion
   

   

   

   
    
}
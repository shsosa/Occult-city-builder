using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIObjectInfo : MonoBehaviour
{
    
    //todo get tile and building - no collision - raycast
    
    private bool _canIstantiateNewBuilding = true;
    private UIObject _currentObjectFromMouse;

    #region Mono

    void Update()
    {
        CheckIfMouseOverObject();
        CheckIfCanInstantiateBuilding();
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
            if (_currentObjectFromMouse == GetUIObject())
            {
                _currentObjectFromMouse.ChangeScale();
            }

            if (_currentObjectFromMouse != GetUIObject())
            {
                _currentObjectFromMouse.RevertScaleToOG();
            }
        }

        if (GetMousePos())
            _currentObjectFromMouse = GetUIObject();
    }

    bool GetMousePos()
    {
        return  EventSystem.current.IsPointerOverGameObject();
    }
   public UIObject GetUIObject()
    {
        var eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        for (int i = 0; i < results.Count; i++)
        {
            if (results[i].gameObject.CompareTag("BuildingUI"))
            {
               
                return results[i].gameObject.GetComponent<UIObject>();
            }
            
            
        }
       
        return null;
       
        
        
    }

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
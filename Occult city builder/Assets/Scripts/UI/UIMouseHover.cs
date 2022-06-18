using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIMouseHover : MonoBehaviour
{
    [SerializeField] private bool isCursorOverObject;
    private GameObject currentObject;
    private bool canIstantiateNewBuilding = true;
    

    void Update()
    {
        CheckIfMouseOverObject();
        CheckIfCanTakeBuilding();
        if(isCursorOverObject)
            GetUIObject();
        
    }

    #region Mouse position
    
    private void CheckIfMouseOverObject()
    {
        if (GetMousePos())
        {
        
            isCursorOverObject = true;
            
        }
        else
        {
            isCursorOverObject = false;
        }
    }

    bool GetMousePos()
    {
        return  EventSystem.current.IsPointerOverGameObject();
    }
    

    #endregion
    
    void CheckIfCanTakeBuilding()
    {
        
       
        if (isCursorOverObject && Input.GetMouseButtonDown(0))
        {
            currentObject = GetUIObject();
            currentObject.GetComponent<UIObject>().CreateBuldingFromUI();
            canIstantiateNewBuilding = false;
            
        }
        else
        {
            canIstantiateNewBuilding = true;
            
        }
    }
    
    GameObject GetUIObject()
    {
        var eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        Debug.Log("Get UI "+ results[0].gameObject.name);
        return results[0].gameObject;
        
    }
    
}
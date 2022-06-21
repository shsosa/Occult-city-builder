using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIMouseHover : MonoBehaviour
{
    [SerializeField] private bool isCursorOverObject;
    private bool _canIstantiateNewBuilding = true;
    
    private GameObject _currentObjectFromMouse;
    

    void Update()
    {
        CheckIfMouseOverObject();
        CheckIfCanInstantiateBuilding();
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
    
    void CheckIfCanInstantiateBuilding()
    {
        Instantiate_Building_From_UI_WIthMouse();
    }

    private void Instantiate_Building_From_UI_WIthMouse()
    {
        if (isCursorOverObject && Input.GetMouseButtonDown(0))
        {
            _currentObjectFromMouse = GetUIObject();
            if (_currentObjectFromMouse.GetComponent<UIObject>() != null)
            {
                _currentObjectFromMouse.GetComponent<UIObject>().CreateBuldingFromUI();
                _canIstantiateNewBuilding = false;
            }
             
        }
        else
        {
            _canIstantiateNewBuilding = true;
        }
    }

    GameObject GetUIObject()
    {
        var eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        for (int i = 0; i < results.Count; i++)
        {
            if (results[i].gameObject.CompareTag("BuildingUI"))
            {
                return results[i].gameObject;
            }
            
        }
        Debug.Log("Get UI "+ results[0].gameObject.name);
        return null;
       
        
        
    }
    
}
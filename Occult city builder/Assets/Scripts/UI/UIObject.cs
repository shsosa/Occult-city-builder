using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIObject : MonoBehaviour
{
    [SerializeField] private bool isCursorOverObject;
    [SerializeField] private GameObject buildingToCreate;
    private bool canIstantiateNewBuilding = true;
    
   
    void Update()
    {
        CheckIfMouseOverObject();
        CheckIfCanTakeBuilding();
    }

    private void CheckIfMouseOverObject()
    {
        if (GetMousePos())
        {
            isCursorOverObject = true;
            Debug.Log("IAMUI");
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

    void CheckIfCanTakeBuilding()
    {
        if (isCursorOverObject && Input.GetMouseButtonDown(0))
        {
            Instantiate(buildingToCreate, transform.position, quaternion.identity);
            canIstantiateNewBuilding = false;
        }
        else
        {
            canIstantiateNewBuilding = true;
        }
    }
}

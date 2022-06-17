using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIObject : MonoBehaviour
{
   
    [SerializeField] private GameObject buildingToCreate;
    
    

    public void CreateBuldingFromUI()
    {
        Instantiate(buildingToCreate, transform.position, quaternion.identity);
    }

   
}

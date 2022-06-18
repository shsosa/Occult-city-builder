using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIObject : MonoBehaviour
{
   
    [SerializeField] private GameObject buildingToCreate;
    public bool canBuild =false;
    
    

    public void CreateBuldingFromUI()
    {
        if(canBuild)
            Instantiate(buildingToCreate, transform.position, quaternion.identity);
    }

   
}

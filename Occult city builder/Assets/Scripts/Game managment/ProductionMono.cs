using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProductionMono : MonoBehaviour
{
    public enum ResourceType
    {
        Wood, Rock, Gold, Wheat, Cattle
    }

     
     
     

    public ResourceType _resourceType = 0;
    public int howMuchCanProduce;

    private void Start()
    {
        
       
        Debug.Log("start method " + gameObject.name);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Recources;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    
    private void OnMouseOver()
    {
        ProductionMono production = GetComponent<ProductionMono>();
        Debug.Log("mouse hover " + production._resourceType +" "+ production.howMuchCanProduce + " " + gameObject.name);
    }
    

    
      
}

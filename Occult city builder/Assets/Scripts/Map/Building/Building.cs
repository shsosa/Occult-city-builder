using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
   public BuildingScriptable buildingScriptable;

   private void Start()
   {
      GetComponent<SpriteRenderer>().sortingOrder = 1;
      Debug.Log(buildingScriptable._resourceType);
   }
}

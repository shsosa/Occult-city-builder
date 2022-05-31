using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
   /*
    * snap to tile center or other
    */
   public BuildingScriptable buildingScriptable;

   private void Start()
   {
      GetComponent<SpriteRenderer>().sortingOrder = 1;
      Debug.Log(buildingScriptable._resourceType);
   }

   // collision for UIManager - visual feedback
   private void OnCollisionStay(Collision collisionInfo)
   {
       throw new NotImplementedException();
   }

   private void OnCollisionExit2D(Collision2D other)
   {
       throw new NotImplementedException();
   }
}

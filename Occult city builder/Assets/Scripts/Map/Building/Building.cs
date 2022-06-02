using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : ProductionMono
{
   /*
    * snap to tile center or other
    */
  
    
   private void Start()
   {
      GetComponent<SpriteRenderer>().sortingOrder = 1;
      
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

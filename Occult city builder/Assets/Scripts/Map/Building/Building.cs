using System;
using UnityEngine;

//namespace Map.Building
//{
    public class Building : ProductionMono
    {
        /*
    * snap to tile center or other
    */   
        [SerializeField] BuildingScriptable buildingData; 
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
//}

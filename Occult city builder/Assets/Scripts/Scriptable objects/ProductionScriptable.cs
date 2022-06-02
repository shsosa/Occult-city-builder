using UnityEngine;

namespace Recources
{
   
    public class ProductionScriptable : ScriptableObject
    {
        public enum ResourceType
        {
            Wood, Rock, Gold, Wheat, Cattle
        }

        public ResourceType _resourceType = 0;
        public int howMuchCanProduce;
        public int sortingLayerOrder;
        
        
    }
}



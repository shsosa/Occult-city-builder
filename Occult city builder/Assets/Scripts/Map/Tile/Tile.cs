using UnityEngine;

namespace Map.Tile
{
    public class Tile : ProductionMono
    {
    
        /*
     * visual feedback when mouse hovers with building
     * info on tile when mouse hovers
     */
        [SerializeField] bool hasBonus = false;
        [SerializeField] bool hasBulding = false;
        public ResourceManager ResourceManager;
        private void OnCollisionEnter2D(Collision2D col)
        {
            hasBulding = true;
        
        }

        private void OnCollisionExit(Collision other)
        {
            hasBulding = false;
        }

        private void Update()
        {
            if (hasBulding)
            {
            
            }
        }
    }
}

using UnityEngine;

//namespace Map.Tile
//{
    public class Tile : MonoBehaviour
    {
        ProductionMono production;
        /*
     * visual feedback when mouse hovers with building
     * info on tile when mouse hovers
     */
        [SerializeField] bool hasBonus = false;
        [SerializeField] bool hasBulding = false;
        public int productionOnThisTile;
        BuildingScriptable building;
    TileScriptable tile;
        private void Start()
        {
        tile = GetComponent<TileScriptable>();
            building = GetComponentInChildren<BuildingScriptable>();
            production = GetComponentInParent<ProductionMono>();
        }

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
        public void TileProduction()
        {
            if (hasBulding)
            {
                
            }
        }
    private void ProductionFromBuilding(BuildingScriptable.ResourceType resourceType,TileScriptable.TileResourceType tileResourceType)
    {
        if (resourceType==tileResourceType)
        {
            productionOnThisTile ++;
        }
    }
        
    }
//}

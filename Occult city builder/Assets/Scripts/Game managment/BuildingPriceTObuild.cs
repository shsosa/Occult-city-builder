using UnityEngine;

namespace Game_managment
{
    [CreateAssetMenu(fileName = "Bulilding Price")]
    public class BuildingPriceTObuild : ScriptableObject
    {
        public int FarmPrice;
        public int housePice;
        public int minePrice;
        public int witchHutPrice;

    }
}
using Unity.VisualScripting;
using UnityEngine;

namespace Game_managment
{
    [CreateAssetMenu(fileName = "Resource Price")]
    public class ReasourcePrice : ScriptableObject
    {
        
        // could be used for banishing or other magic stuff
        [Header("Price to build")]
            public  int wood;
            public  int gold;
            public  int vilagers;
            public   int researchPoints;
            public  int cattle;


            [Header("Sacrifice To monster amount:")]
            public int secrificeAmountHunger;

            public int secrificeAddPower;


            public string GetBuildingPrice()
            {
                string price = null;
                if (wood != 0)
                    price += "Wood: " + wood.ToString() +" \n" ;
                if (cattle != 0)
                    price += "Cattle: " + cattle.ToString()+ " \n";
                if (researchPoints != 0)
                    price += "Research: " + researchPoints.ToString()+ " \n";
                if (gold != 0)
                    price += "Gold: " + gold.ToString()+ " \n";
                if (vilagers != 0)
                    price += "Villagers: " + vilagers.ToString()+ " \n";
                

                return price;
            }
    }
}
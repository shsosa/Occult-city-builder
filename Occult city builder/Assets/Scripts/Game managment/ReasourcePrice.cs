using UnityEngine;

namespace Game_managment
{
    [CreateAssetMenu(fileName = "Resource Price")]
    public class ReasourcePrice : ScriptableObject
    {
        // could be used for banishing or other magic stuff
        [Header("Price to build")]
            public int wood;
            public int gold;
            public int vilagers;
            public int researchPoints;
            public int cattle;


            [Header("Sacrifice To monster amount:")]
            public int secrificeAmountHunger;

            public int secrificeAddPower;

        public bool isCorectForRendomSecrafice;
    }
}
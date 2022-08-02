using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Monster;
using UnityEngine;

public class SecreficeManager : MonoBehaviour
{
    private bool isVilagers;
    [SerializeField] MonsterManager monster;
    
    public List<Building> listOfActiveSacrificeBuildings;
   

    public void Sacrifice(int secrificeAmountHunger, int secrificePowerAdd, int researchPointAdd)
    {
       monster.MonsterEat();
        Debug.Log("Secrificed amount " + secrificeAmountHunger);
        monster.monsterHunger -= secrificeAmountHunger;
        monster.monsterPower += secrificePowerAdd;
        monster.ResourceData.researchPoints += researchPointAdd;


    } 
}

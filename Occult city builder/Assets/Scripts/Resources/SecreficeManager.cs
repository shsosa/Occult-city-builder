using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecreficeManager : MonoBehaviour
{
    private bool isVilagers;
    [SerializeField] MonsterManager monster;
   

    public void Sacrifice(int secrificeAmountHunger, int secrificePowerAdd)
    {
        
        Debug.Log("Secrificed amount " + secrificeAmountHunger);

        monster.monsterHunger -= secrificeAmountHunger;
        monster.monsterPower += secrificePowerAdd;
    }
    
}

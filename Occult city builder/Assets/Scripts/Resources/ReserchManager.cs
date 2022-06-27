using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReserchManager : MonoBehaviour
{

    [SerializeField] MonsterManager monster;
    [SerializeField] private int powerOfRitual;

    private void RitualForPowerOfMonster()
    {
        monster.monsterPower -= powerOfRitual;
    }

    
    //todo tile cleaning 
    //todo power reduction 
   
    public void BanishingRitual()
    {
        monster.isBanished = true;
    }

}
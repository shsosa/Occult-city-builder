using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReserchManager : MonoBehaviour
{

    [SerializeField] MonsterManager monster;
    [SerializeField] private ResourceData _resourceData;
    [SerializeField] private int powerOfRitual;

    public List<Building> listOfActiveResearchBuildings;
    
    // maybe Event that lets the manager know how many buildings there are
    //that decreases the monster power by that number
    //
  
    //todo node to line renderer 
    
    
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
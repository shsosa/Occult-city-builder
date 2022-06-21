using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecreficeManager : MonoBehaviour
{
    private bool isVilagers;
    [SerializeField] MonsterManager monster;
    [SerializeField] ResourceData resourceData;
    [SerializeField] private int amountOfReasourcesToSacrefice;
    [SerializeField] private float hungerReductionPerUnitOfResorce, powerIncreasePerUnitOfReasorce;
    [SerializeField] private float hungerReductionPerUnitOfCattle, powerIncreasePerUnitOfCattle;
    [SerializeField] private float hungerReductionPerUnitOfVilagers, powerIncreasePerUnitOfVilagers;
    public void Sacrifice(int secrificeAmount)
    {
        
        //todo what to do here consult with artium
        
        monster.monsterHunger -= amountOfReasourcesToSacrefice * hungerReductionPerUnitOfResorce;
        monster.monsterPower += amountOfReasourcesToSacrefice * powerIncreasePerUnitOfReasorce;
        if (isVilagers)
        {
            resourceData.vilagers -= amountOfReasourcesToSacrefice;
        }
        else
        {
            resourceData.cattle -= amountOfReasourcesToSacrefice;
        }
        amountOfReasourcesToSacrefice = 0;
        isVilagers = false;
    }
    public void ButtonForCattle()
    {
        hungerReductionPerUnitOfResorce = hungerReductionPerUnitOfCattle;
        powerIncreasePerUnitOfReasorce = powerIncreasePerUnitOfCattle;
        isVilagers = false;
    }
    public void ButtonForVilagers()
    {
        hungerReductionPerUnitOfResorce = hungerReductionPerUnitOfVilagers;
        powerIncreasePerUnitOfReasorce = powerIncreasePerUnitOfVilagers;
        isVilagers = true;
    }
}

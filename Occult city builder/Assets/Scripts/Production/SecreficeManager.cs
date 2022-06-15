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
    private void Sacrifice()
    {
        //to be called from UI Button

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
    private void ButtonForCattle()
    {
        hungerReductionPerUnitOfResorce = hungerReductionPerUnitOfCattle;
        powerIncreasePerUnitOfReasorce = powerIncreasePerUnitOfCattle;
        isVilagers = false;
    }
    private void ButtonForVilagers()
    {
        hungerReductionPerUnitOfResorce = hungerReductionPerUnitOfVilagers;
        powerIncreasePerUnitOfReasorce = powerIncreasePerUnitOfVilagers;
        isVilagers = true;
    }
}

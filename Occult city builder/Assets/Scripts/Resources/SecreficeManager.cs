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
    public void Sacrifice()
    {
        //to be called from UI Button
        //todo make it from UI serifice button for villegers and cattle (draggable). to a UI object or noraml of monster? maybe get a script of monster on object
        // todo events? - text and choose what to drag  - UI constant size with text choose from 2 options - buy fonts. make the SO for events
        // todo make the hover tooltip - last
        //todo shader of clouds or smoke for background - check if intractable ca make it
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

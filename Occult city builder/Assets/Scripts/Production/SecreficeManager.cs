using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecreficeManager : MonoBehaviour
{
    [SerializeField] MonsterManager monster;
    [SerializeField] ResourceData resourceData;
    [SerializeField] private int amountOfReasourcesToSacrefice;
    [SerializeField] private float hungerReductionPerUnitOfResorce, powerIncreasePerUnitOfReasorce;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Sacrifice()
    {
        //to be called from UI Button
        monster.monsterHunger -= amountOfReasourcesToSacrefice * hungerReductionPerUnitOfResorce;
        monster.monsterPower += amountOfReasourcesToSacrefice * powerIncreasePerUnitOfReasorce;
    }
    private void ReasorcesToSacrifice()
    {
        //will need a sacrifice UI,
        //will decide based on button which resorce to take from ResourceData
        //will decide based on resorce the value of hungerReductionPerUnitOfResorce && powerIncreasePerUnitOfReasorce
    }
}

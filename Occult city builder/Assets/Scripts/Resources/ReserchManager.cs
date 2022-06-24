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
    // Start is called before the first frame update
    void Start()

    {
       
    }
    public void BanishingRitual()
    {
        monster.isBanished = true;
    }

}
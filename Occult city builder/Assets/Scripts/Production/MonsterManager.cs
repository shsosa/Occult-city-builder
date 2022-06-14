using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public float monsterHunger,monsterPower;
    public float monsterHungerGrowth,monsterPowerGrowth;
    private void Update()
    {
        HungerGrowth();
    }
    private void HungerGrowth()
    {
        monsterHunger += monsterHungerGrowth * Time.deltaTime;
    }

}

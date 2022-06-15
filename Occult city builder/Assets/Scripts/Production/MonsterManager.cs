using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MonsterManager : MonoBehaviour
{
    public float monsterHunger, monsterPower;
    public float monsterHungerGrowth, monsterPowerGrowth;
    public float hungerTime;
    [SerializeField] private float maxRangeToTrigerEvent, maxRangeToTrigerEventConstant, hungerEventTriger;
    [SerializeField] VoidEventChannelSO monsterHungerEventChannel;
    private void Start()
    {
        maxRangeToTrigerEvent = maxRangeToTrigerEventConstant;
        StartCoroutine(HungerTimer());
    }
    private void HungerGrowth()
    {
        monsterHunger += monsterHungerGrowth;
    }
    private IEnumerator HungerTimer()
    {
        yield return new WaitForSeconds(hungerTime);
        HungerGrowth();
        HungerEventProbability();
        StartCoroutine(HungerTimer());
    }
    private void HungerEventFlag()
    {
        monsterHungerEventChannel.RaiseEvent();
    }
    private void HungerEventProbability()
    {
        maxRangeToTrigerEvent -= monsterHunger;
        hungerEventTriger = Random.Range(0, maxRangeToTrigerEventConstant);
        if (hungerEventTriger >= maxRangeToTrigerEvent)
        {
            HungerEventFlag();
            maxRangeToTrigerEvent = maxRangeToTrigerEventConstant;
            monsterHunger = 0;
        }
    }
}

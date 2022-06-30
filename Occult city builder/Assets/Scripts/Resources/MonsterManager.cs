using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterManager : MonoBehaviour
{
    public float monsterHunger, monsterPower;
    public float monsterHungerGrowth, monsterPowerGrowth;
    public float hungerTime;
    public bool isBanished;
    [SerializeField] private float maxRangeToTrigerHungerEvent, maxRangeToTrigerHungerEventConstant, hungerEventTriger,
                     maxRangeToTrigerPowerEvent, maxRangeToTrigerPowerEventConstant, powerEventTriger;
    [SerializeField] VoidEventChannelSO monsterHungerEventChannel, monsterPowerEventChanel;
    Tiles[] tile;
    private void Start()
    {
        tile = FindObjectsOfType<Tiles>();
        maxRangeToTrigerHungerEvent = maxRangeToTrigerHungerEventConstant;
        maxRangeToTrigerPowerEvent = maxRangeToTrigerPowerEventConstant;
        StartCoroutine(HungerTimer());
    }

    private void Update()
    {
        monsterHunger = Mathf.Clamp(monsterHunger, 0, 10);
       monsterPower= Mathf.Clamp(monsterPower, 0, 10);
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
        PowerEventProbability();
        StartCoroutine(HungerTimer());
    }
    private void HungerEventFlag()
    {
        monsterHungerEventChannel.RaiseEvent();
    }
    private void HungerEventProbability()
    {
        maxRangeToTrigerHungerEvent -= monsterHunger;
        hungerEventTriger = Random.Range(0, maxRangeToTrigerHungerEventConstant);
        if (hungerEventTriger >= maxRangeToTrigerHungerEvent)
        {
            HungerEventFlag();
            maxRangeToTrigerHungerEvent = maxRangeToTrigerHungerEventConstant;
            
        }
    }
    private void PowerEventProbability()
    {
        maxRangeToTrigerPowerEvent -= monsterPower;
        powerEventTriger = Random.Range(0, maxRangeToTrigerPowerEventConstant);
        if (powerEventTriger >= maxRangeToTrigerPowerEvent)
        {
            PowerEvent();
            maxRangeToTrigerPowerEvent = maxRangeToTrigerPowerEventConstant;
            monsterPower -= monsterPowerGrowth;
        }
    }
    private void PowerEvent()
    {
        int randomizer;
        randomizer = Random.Range(0, tile.Length);
        
        //todo Randomize is cool - i had a thought about making it spread if close to monster like a deasese,  you know like its alive
        if(!tile[randomizer].isCursed)
        {
            tile[randomizer].SetCursed();     
        }
        else 
        { 
            PowerEvent(); 
        }
    }
}
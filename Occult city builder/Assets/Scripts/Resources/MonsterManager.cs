using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Monster;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterManager : MonoBehaviour
{
    public float monsterHunger, monsterPower;
    public float monsterHungerGrowth, monsterPowerGrowth;
    public float hungerTime;
    public bool isBanished;
    [SerializeField] private float maxRangeToTrigerHungerEvent, maxRangeToTrigerHungerEventConstant, hungerEventTriger,
                     maxRangeToTrigerPowerEvent, maxRangeToTrigerPowerEventConstant, powerEventTriger
        ,minThreshholdForHungerEvent,minThresholdForPowerEvent,maxThresholdForHungerEventTrigger,maxThresholdForPowerEventTrigger;
    [SerializeField] VoidEventChannelSO monsterHungerEventChannel, monsterPowerEventChanel;
    Tiles[] tile;

    [SerializeField] Tentecle[] _tenteclesArray;
    [SerializeField] private MonsterEmot _monsterEmotCurseTile;
    [SerializeField] private MonsterEmot _monsterEmotFeedMe;
    
    private void Start()
    {
        _tenteclesArray = GetComponentsInChildren<Tentecle>();
        tile = FindObjectsOfType<Tiles>();
        maxRangeToTrigerHungerEvent = maxRangeToTrigerHungerEventConstant;
        maxRangeToTrigerPowerEvent = maxRangeToTrigerPowerEventConstant;
        StartCoroutine(HungerTimer());
    }

    private void Update()
    {
        monsterHunger = Mathf.Clamp(monsterHunger, 0, 100);
        monsterPower= Mathf.Clamp(monsterPower, 0, 100);
        HungerGrowth();
        
    }

    private void HungerGrowth()
    {
        if (!GameManager.isEventUIActive)
        {
            monsterHunger += monsterHungerGrowth * Time.deltaTime;

            //Add power when really hungry
            if (monsterHunger >= 90)
                monsterPower += 0.05f * Time.deltaTime;
        }
    }
    private IEnumerator HungerTimer()
    {
        yield return new WaitForSeconds(hungerTime);
        if (!GameManager.isEventUIActive)
        {
            
            HungerEventProbability();
            PowerEventProbability();
        } 
        StartCoroutine(HungerTimer());
    }
    private void HungerEventFlag()
    {
        monsterHungerEventChannel.RaiseEvent();
    }
    private void HungerEventProbability()
    {
        if (monsterHunger >= minThreshholdForHungerEvent)
        {
            if (monsterHunger <= maxThresholdForHungerEventTrigger)
            {
                maxRangeToTrigerHungerEvent -= monsterHunger;
            }
            else
            {
                maxRangeToTrigerHungerEvent = maxRangeToTrigerHungerEventConstant- maxThresholdForHungerEventTrigger;
            }
            hungerEventTriger = Random.Range(0, maxRangeToTrigerHungerEventConstant);
        }
        if (hungerEventTriger >= maxRangeToTrigerHungerEvent)
        {
            HungerEventFlag();
            MonsterReact(_monsterEmotFeedMe);
            maxRangeToTrigerHungerEvent = maxRangeToTrigerHungerEventConstant;
        }
    }
    private void PowerEventProbability()
    {
        if (monsterPower >= minThresholdForPowerEvent)
        {
            maxRangeToTrigerPowerEvent -= monsterPower;
            powerEventTriger = Random.Range(0, maxRangeToTrigerPowerEventConstant);
            if (powerEventTriger >= maxRangeToTrigerPowerEvent)
            {
                PowerEvent();
                MonsterReact(_monsterEmotCurseTile);
                maxRangeToTrigerPowerEvent = maxRangeToTrigerPowerEventConstant;
                monsterPower -= monsterPowerGrowth;
            }
        }
    }
    private void PowerEvent()
    {
        int randomizer;
        randomizer = Random.Range(0, tile.Length);
        
        //todo Randomize is cool - i had a thought about making it spread if close to monster like a deasese,  you know like its alive
        if(!tile[randomizer].isCursed)
        {
            if(!tile[randomizer].CompareTag("HolyTile"))
                tile[randomizer].SetCursed(); 
            MonsterReact(_monsterEmotCurseTile);
        }
        else 
        { 
          
            PowerEvent(); 
        }
    }

    void MonsterReact(MonsterEmot _monsterEmot)
    {
        Debug.Log("Monster react");
        foreach (var tentecle in _tenteclesArray)
        {
            StartCoroutine(tentecle.Pulse(_monsterEmot));
           
        }
    }
}
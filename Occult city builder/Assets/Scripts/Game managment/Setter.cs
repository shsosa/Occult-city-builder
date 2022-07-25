using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game_managment;

public class Setter : MonoBehaviour
{
    #region Lists
    private List<Building> building;
    #endregion
    #region Serializables
    #region Buildings
    [Header("Buildings")]

    public Building farm;
    public Building house;
    public Building mine;
    public Building query;
    public Building witchHut;
    #endregion
    #region Spells
    [Header("Spells: ")]
    public Spell banishing;
    public Spell blessing;
    public Spell monsterPowerReduction;
    #endregion
    #region Sacrefice
    [Header("Sacrefice:")]
    public Sacrefice villagers;
    public Sacrefice cattle;
    #endregion
    [Header("Monster: ")]

    public Monster monsterOptions;

    [Header("Random Events: ")]
    public RandomEvents eventsOptions;

    [Header("Resources")]
    public Resource resources;
    #endregion
    private void Start()
    {
        farm.OnStart();
        house.OnStart();
        mine.OnStart();
        query.OnStart();
        witchHut.OnStart();
        banishing.OnStart();
        blessing.OnStart();
        monsterPowerReduction.OnStart();
        villagers.OnStart();
        cattle.OnStart();
        monsterOptions.OnStart();
        eventsOptions.OnStart();
        resources.OnStart();
    }
    private void Update()
    {
        resources.OnRunTime();
    }

    #region Classes
    [System.Serializable]
    public class Building
    {
        public ReasourcePrice so;
        public int priceInGold;
        public int priceInWood;
        public int priceInCattle;
        public int priceInVillagers;
        public int priceInReserchPoints;

        public void OnStart()
        {
            so.wood = priceInWood;
            so.gold = priceInGold;
            so.cattle = priceInCattle;
            so.vilagers = priceInVillagers;
            so.researchPoints = priceInReserchPoints;
        }
    }
    [System.Serializable]
    public class Spell
    {
        public ReasourcePrice so;
        public int priceInGold;
        public int priceInWood;
        public int priceInCattle;
        public int priceInVillagers;
        public int priceInReserchPoints;
        public int monsterPower;
        public void OnStart()
        {
            so.wood = priceInWood;
            so.gold = priceInGold;
            so.cattle = priceInCattle;
            so.vilagers = priceInVillagers;
            so.researchPoints = priceInReserchPoints;
            so.secrificeAddPower -= monsterPower;
        }
    }
    [System.Serializable]
    public class Sacrefice
    {
        public ReasourcePrice so;
        public int priceInGold;
        public int priceInWood;
        public int priceInCattle;
        public int priceInVillagers;
        public int priceInReserchPoints;
        public int monsterPower;
        public int monsterHunger;
        public void OnStart()
        {
            so.wood = priceInWood;
            so.gold = priceInGold;
            so.cattle = priceInCattle;
            so.vilagers = priceInVillagers;
            so.researchPoints = priceInReserchPoints;
            so.secrificeAddPower = monsterPower;
            so.secrificeAmountHunger = monsterHunger;
        }
    }
    [System.Serializable]
    public class Monster
    {
        public MonsterManager monsterScript;

        [Header("Steps For Growth of Hunger and Power")]
        public float hunger;
        public float power;

        [Header("Timers for Hunger and Power Events To Fire")]
        [Tooltip("How often (in seconds) Monster will attempt to triger Random Events")]
        public float timeHunger;
        [Tooltip("How often (in seconds) Monster will attempt to Eat a Tile")]
        public float timePower;

        [Header("Events Thresholds")]
        [Tooltip("If monster hunger is bellow this number hunger event will not fire")]
        public float hungerThreshold;
        [Tooltip("If monster power is bellow this number power event will not fire")]
        public float powerThreshold;

        [Header("Probabilities")]
        [Tooltip("The higher this number th lower the probability of event firing")]
        public float hungerProbability;
        [Tooltip("The higher this number th lower the probability of event firing")]
        public float powerProbability;
        public void OnStart()
        {
            monsterScript.monsterHungerGrowth = hunger;
            monsterScript.monsterPowerGrowth = power;
            monsterScript.hungerTime = timeHunger;
            monsterScript.powerTime = timePower;
            monsterScript.maxRangeToTrigerHungerEventConstant = hungerProbability;
            monsterScript.maxRangeToTrigerPowerEventConstant = powerProbability;
            monsterScript.minThreshholdForHungerEvent = hungerThreshold;
            monsterScript.minThresholdForPowerEvent = powerThreshold;
        }
    }
    [System.Serializable]
    public class RandomEvents
    {
        public RandomEventsManager rEManager;
        [Header("Price on Hunger Event(on Start)")]
        [Tooltip("determinse minimal price for random event on start of the game, if this number is negative it will give a grater range in the late game")]
        public int minPriceOnStart;
        [Tooltip("determinse maximal price for random event on start of the game")]
        public int maxPriceOnStart;

        [Header("Price on Hunger Event")]
        public int minPrice;
        public int maxPrice;

        [Header("Punishment for Refusing Hunger Event(on Start)")]
        [Tooltip("determinse minimal punishment for random event on start of the game, if this number is negative it will give a grater range in the late game")]
        public int minPunishmentOnStart;
        [Tooltip("determinse maximal punishment for random event on start of the game")]
        public int maxPunishmentOnStart;

        [Header("Punishment for Refusing Hunger Event")]
        public int minPunishment;
        public int maxPunishment;

        [Header("Growth of Price and Punishment Between Hunger Events")]
        public int priceStep;
        public int punishmentStep;
        public void OnStart()
        {
            rEManager.minCurrentPriceToPay = minPriceOnStart;
            rEManager.maxCurrentPriceToPay = maxPriceOnStart;
            rEManager.minCurrentPunishment = minPunishmentOnStart;
            rEManager.maxCurrentPunishment = maxPunishmentOnStart;
            rEManager.priceGrowthPerItration = priceStep;
            rEManager.punishmentGrowthPerIteration = punishmentStep;
            rEManager.minPriceToPay = minPrice;
            rEManager.maxPriceToPay = maxPrice;
            rEManager.minPunishment = minPunishment;
            rEManager.maxPunishment = maxPunishment;
        }
    }
    [System.Serializable]
    public class Resource
    {
        public BradcasterScript timer;
        public ResourceData so;
        [Header("Resources on Start")]
        public int villagers;
        public int cattle;
        public int wood;
        public int gold;
        public int reserchPoints;

        [Header("Maximal and Minimal Value of Each Resource on Level")]
        public int maxVillagers;
        public int minVillagers;
        public int maxCattle;
        public int minCattle;
        public int maxWood;
        public int minWood;
        public int maxGold;
        public int minGold;
        public int maxReserchPoints;
        public int minReserchPoints;

        [Header("Time to colect resources")]
        public float time;
        public void OnStart()
        {
            timer = FindObjectOfType<BradcasterScript>();
            so.vilagers = villagers;
            so.cattle = cattle;
            so.wood = wood;
            so.gold = gold;
            so.researchPoints = reserchPoints;
            timer.time = time;
        }
        public void OnRunTime()
        {
            so.vilagers = Mathf.Clamp(so.vilagers,minVillagers,maxVillagers);
            so.cattle = Mathf.Clamp(so.cattle, minCattle, maxCattle);
            so.wood = Mathf.Clamp(so.wood, minWood, maxWood);
            so.gold = Mathf.Clamp(so.gold, minGold, maxGold);
            so.researchPoints = Mathf.Clamp(so.researchPoints, minReserchPoints, maxReserchPoints);
        }
    }

    #endregion
    #region Functions
   
    #endregion
}

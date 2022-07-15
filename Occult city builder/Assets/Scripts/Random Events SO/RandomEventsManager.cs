using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RandomEvents", fileName = "RandomEvents")]
public class RandomEventsManager : ScriptableObject
{
    [SerializeField] VoidEventChannelSO monsterHungerEventChannel;
    [SerializeField] ResourceData resource;
    RandomEventUI eventUI;


    private int eventTypeIterator;

    public enum EventType
    {
        Madness, Desise, WildAnimals, Starvation, FalingStar, MaxValueForIteration
        //MaxValueForIteration is not an event and used only to astablish randomization 
        //upper border in EventRandomizer. Do not add enums after it
    }
    public EventType eventType;

    public List<string> madnesEvents;
    public List<string> desiseEvents;
    public List<string> wildAnimalsEvents;
    public List<string> starvationEvents;
    public List<string> fallingStarEvents;
    public List<string> eventTextHeaders;

    private List<string> curentEventTexts;

    public string randomEventText, eventTextHeader;

    [System.NonSerialized] public int punishment, maxCurrentPunishment, minCurrentPunishment,minPunishment,maxPunishment, priceToPay, maxCurrentPriceToPay, minCurrentPriceToPay,minPriceToPay,maxPriceToPay;
      public int  priceGrowthPerItration,punishmentGrowthPerIteration;
    public int maxPunishmentOnStart, minPunishmentOnStart, maxPriceToPayOnStart, minPriceToPayOnStart;

    public int resourceIterator;
    private void OnEnable()
    {
        //SettingPriceAndPunishment();
        monsterHungerEventChannel.OnEventRaised += RandomEvent;
        eventUI = FindObjectOfType<RandomEventUI>();
    }


    private void RandomEvent() 
    {  
        EventRandomizer();
        eventType= (EventType) eventTypeIterator;
        EventListTextAndResourceSorter();
        EventTextSorter();
        maxCurrentPriceToPay += priceGrowthPerItration;
        maxCurrentPunishment += punishmentGrowthPerIteration;
        minCurrentPriceToPay += priceGrowthPerItration;
        minCurrentPunishment += punishmentGrowthPerIteration;   
    }
    private void EventRandomizer()
    {    
        ResourceIteration();
        PriceAndPunishmentRandomizer();
        eventTypeIterator = (int)Random.Range(0, (int)EventType.MaxValueForIteration);
    }
    private void EventListTextAndResourceSorter()
    {
        int relevantResource=0;
        {
            if (eventType == EventType.Madness)
            {
                curentEventTexts = madnesEvents;
                eventTextHeader = eventTextHeaders[0];
                relevantResource = resource.vilagers;
            }
            else if (eventType == EventType.Desise)
            {
                curentEventTexts = desiseEvents;
                eventTextHeader = eventTextHeaders[1];
                relevantResource = resource.gold;
            }
            else if (eventType == EventType.WildAnimals)
            {
                curentEventTexts = wildAnimalsEvents;
                eventTextHeader = eventTextHeaders[2];
                relevantResource = resource.wood;
            }
            else if (eventType == EventType.Starvation)
            {
                curentEventTexts = starvationEvents;
                eventTextHeader = eventTextHeaders[3];
                relevantResource = resource.cattle;
            }
            else if (eventType == EventType.FalingStar)
            {
                curentEventTexts = fallingStarEvents;
                eventTextHeader = eventTextHeaders[4];
                relevantResource = resource.researchPoints;
            }
        }
        if(relevantResource<priceToPay)
        {
            eventUI.DesableSecrificeButton();
        }
    }
    private void EventTextSorter()
    {
        int eventTextIterator;
        eventTextIterator = Random.Range(0, curentEventTexts.Count);
        randomEventText = curentEventTexts[eventTextIterator];
    }
    private void PriceAndPunishmentRandomizer()
    {
        priceToPay = Random.Range(minCurrentPriceToPay, maxCurrentPriceToPay); 
        punishment = Random.Range(minCurrentPunishment, maxCurrentPunishment);
        if (punishment <= 0)
        { punishment = 1; }
        if(punishment>maxPunishment)
        { punishment = maxPunishment; }
        if (priceToPay <= 0)
        { priceToPay = 1; }
        if(priceToPay>maxPriceToPay)
        { priceToPay = maxPriceToPay; }
    }
    private void ResourceIteration()
    {
        resourceIterator = Random.Range(0, 5);
    }
}

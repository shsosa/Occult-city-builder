using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RandomEvents", fileName = "RandomEvents")]
public class RandomEventsManager : ScriptableObject
{
    [SerializeField] VoidEventChannelSO monsterHungerEventChannel;


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

    [System.NonSerialized] public int punishment, maxPunishment, minPunishment, priceToPay, maxPriceToPay, minPriceToPay;
      public int  priceGrowthPerItration,punishmentGrowthPerIteration;
    public int maxPunishmentOnStart, minPunishmentOnStart, maxPriceToPayOnStart, minPriceToPayOnStart;

    public int resourceIterator;
    private void OnEnable()
    {
        SettingPriceAndPunishment();
        monsterHungerEventChannel.OnEventRaised += RandomEvent;
    }
    

    private void RandomEvent() 
    {  
        EventRandomizer();
        eventType= (EventType) eventTypeIterator;
        EventListTextSorter();
        EventTextSorter();
        maxPriceToPay += priceGrowthPerItration;
        maxPunishment += punishmentGrowthPerIteration;
        minPriceToPay += priceGrowthPerItration;
        minPunishment += punishmentGrowthPerIteration;
        
    }
    private void EventRandomizer()
    { 
        
        ResourceIteration();
        PriceRandomizer();
        punishment = Random.Range(minPunishment, maxPunishment);
        eventTypeIterator = (int)Random.Range(0, (int)EventType.MaxValueForIteration);
       // Debug.LogError("randomizer");
    }
    private void EventListTextSorter()
    {
        //Debug.LogError("listsorter");
        if (eventType == EventType.Madness)
        {
            curentEventTexts = madnesEvents;
            eventTextHeader = eventTextHeaders[0];
        }
        else if (eventType == EventType.Desise)
        {
            curentEventTexts = desiseEvents;
            eventTextHeader = eventTextHeaders[1];
        }
        else if (eventType == EventType.WildAnimals)
        {
            curentEventTexts = wildAnimalsEvents;
            eventTextHeader = eventTextHeaders[2];
        }
        else if (eventType == EventType.Starvation)
        {
            curentEventTexts = starvationEvents;
            eventTextHeader = eventTextHeaders[3];
        }
        else if (eventType == EventType.FalingStar)
        {
            curentEventTexts = fallingStarEvents;
            eventTextHeader = eventTextHeaders[4];
        }
        else
        {
            Debug.LogError("Event Type Does not exist!!!!!!!!!!!");
        }
    }
    private void EventTextSorter()
    {
        int eventTextIterator;
        eventTextIterator = Random.Range(0, curentEventTexts.Count);
        randomEventText = curentEventTexts[eventTextIterator];
    }
    private void PriceRandomizer()
    {
        priceToPay = Random.Range(minPriceToPay, maxPriceToPay);
    }
    private void ResourceIteration()
    {
        resourceIterator = Random.Range(0, 4);
    }
    private void SettingPriceAndPunishment()
    {
        minPriceToPay = minPriceToPayOnStart;
        maxPriceToPay = maxPriceToPayOnStart;
        minPunishment = minPunishmentOnStart;
        maxPunishment = maxPunishmentOnStart;
    }
}

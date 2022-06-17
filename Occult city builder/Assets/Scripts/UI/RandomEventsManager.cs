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
        Madness , Desise, WildAnimals, MaxValueForIteration
            //MaxValueForIteration is not an event and used only to astablish randomization 
            //upper border in EventRandomizer. Do not add enums after it
    }
    public EventType eventType;
    private void OnEnable()
    {
        monsterHungerEventChannel.OnEventRaised += RandomEvent;
    }
    

    private void RandomEvent() 
    {
        EventRandomizer();
        eventType= (EventType) eventTypeIterator;
        Debug.Log(eventType);
    }
    private void EventRandomizer()
    {
        eventTypeIterator = (int)Random.Range(0, (int)EventType.MaxValueForIteration-1);
        Debug.Log("eventTypeIterator = " + eventTypeIterator);
    }
}

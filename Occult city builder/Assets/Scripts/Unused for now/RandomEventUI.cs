using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventUI : MonoBehaviour
{
    [SerializeField] RandomEventsManager rEManager;
    [SerializeField] ResourceData resource;
    int resourceIterator;

    public void IfRejectedToSecrefice()
    {
        ResourceIteration();
        if (resourceIterator == 0)
        {
            resource.cattle -= rEManager.punishment;
        }
        if (resourceIterator == 1)
        {
            resource.wood -= rEManager.punishment;
        }
        if (resourceIterator == 2)
        {
            resource.vilagers -= rEManager.punishment;
        }
        if (resourceIterator == 3)
        {
            resource.gold -= rEManager.punishment;
        }
        if (resourceIterator == 4)
        {
            resource.researchPoints -= rEManager.punishment;
        }
        
    }
    private void ResourceIteration()
    {
        resourceIterator = Random.Range(0, 4);
    }
    public void RelevantSecrifice()
    {
        if (rEManager.eventType==RandomEventsManager.EventType.Starvation)
        {
            
        }
        if (rEManager.eventType==RandomEventsManager.EventType.Desise)
        {

        }
        if (rEManager.eventType==RandomEventsManager.EventType.Madness)
        {

        }
        if (rEManager.eventType==RandomEventsManager.EventType.WildAnimals)
        {

        }
        if (rEManager.eventType==RandomEventsManager.EventType.FalingStar)
        {

        }
    }
}

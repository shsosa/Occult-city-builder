using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RandomEventUI : MonoBehaviour
{
    [SerializeField] RandomEventsManager rEManager;

    [SerializeField] ResourceData resource;
    [SerializeField] GameObject eventPromt,secrificeObject;
    [SerializeField] TMP_Text eventText,headerText,priceText;
    [SerializeField] VoidEventChannelSO monsterHungerEventChannel;
    [SerializeField] List<Sprite> listOfSprite;


    private void OnEnable()
    {
        monsterHungerEventChannel.OnEventRaised += Activate;
    }
    private void Start()
    {
        eventPromt.SetActive(false);

    }
    public void Activate()
    {
        eventPromt.SetActive(true);
        GameManager.isEventUIActive = true;
        Text();
        Header();
        PriceText();
        RelevantSecrificeSprite();
    }
    public void IfRejectedToSecrefice()
    {
        if (rEManager.resourceIterator == 0)
        {
            resource.cattle -= rEManager.punishment;
            if(resource.cattle<0)
            {
                resource.cattle = 0;
            }
        }
        if (rEManager.resourceIterator == 1)
        {
            resource.wood -= rEManager.punishment;
            if (resource.wood < 0)
            {
                resource.wood = 0;
            }
        }
        if (rEManager.resourceIterator == 2)
        {
            resource.vilagers -= rEManager.punishment;
            if (resource.vilagers < 0)
            {
                resource.vilagers = 0;
            }
        }
        if (rEManager.resourceIterator == 3)
        {
            resource.gold -= rEManager.punishment;
            if (resource.gold < 0)
            {
                resource.gold = 0;
            }
        }
        if (rEManager.resourceIterator == 4)
        {
            resource.researchPoints -= rEManager.punishment;
            if (resource.researchPoints < 0)
            {
                resource.researchPoints = 0;
            }
        }
        Deactivate();
    }
    public void IfAceptedToSecrifice()
    {
        if (rEManager.eventType == RandomEventsManager.EventType.Madness)
        {
            resource.vilagers-= rEManager.priceToPay;

        }
        if (rEManager.eventType == RandomEventsManager.EventType.Desise)
        {
            resource.gold -= rEManager.priceToPay;
        }
        if (rEManager.eventType == RandomEventsManager.EventType.WildAnimals)
        {
            resource.wood -= rEManager.priceToPay;
        }
        if (rEManager.eventType == RandomEventsManager.EventType.Starvation)
        {
            resource.cattle -= rEManager.priceToPay;
        }
        if (rEManager.eventType == RandomEventsManager.EventType.FalingStar)
        {
            resource.researchPoints -= rEManager.priceToPay;
        }
        Deactivate();
    }
    
    public void RelevantSecrificeSprite()
    {
        if (rEManager.eventType==RandomEventsManager.EventType.Madness)
        {
            secrificeObject.GetComponent<Image>().sprite = listOfSprite[0];
            
        }
        if (rEManager.eventType==RandomEventsManager.EventType.Desise)
        {
            secrificeObject.GetComponent<Image>().sprite = listOfSprite[1];
        }
        if (rEManager.eventType == RandomEventsManager.EventType.WildAnimals)
        {
            secrificeObject.GetComponent<Image>().sprite = listOfSprite[2];
        }
        if (rEManager.eventType==RandomEventsManager.EventType.Starvation)
        {
            secrificeObject.GetComponent<Image>().sprite = listOfSprite[3];
        }
        if (rEManager.eventType==RandomEventsManager.EventType.FalingStar)
        {
            secrificeObject.GetComponent<Image>().sprite = listOfSprite[4];
        }    
    }
    private void Text()
    {
        eventText.text = rEManager.randomEventText;
    }
    private void Header()
    {
        headerText.text = rEManager.eventTextHeader;
    }
    private void PriceText()
    {
        priceText.text = rEManager.priceToPay.ToString()+" X ";
    }
    
    private void Deactivate()
    {
        eventPromt.SetActive(false);
        GameManager.isEventUIActive = false;
    }
}

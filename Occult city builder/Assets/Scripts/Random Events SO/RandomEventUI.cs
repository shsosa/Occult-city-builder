using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Game_managment;

public class RandomEventUI : MonoBehaviour
{
    [SerializeField] RandomEventsManager rEManager;

    [SerializeField] GameObject secrificeButton;

    [SerializeField] ResourceData resource;
    [SerializeField] ReasourcePrice price;
    [SerializeField] GameObject eventPromt, secrificeObject;
    [SerializeField] TMP_Text eventText, headerText, priceText;
    [SerializeField] VoidEventChannelSO monsterHungerEventChannel;
    [SerializeField] List<Sprite> listOfSprite;

    //Added reserch point amount after event
    [SerializeField] private int researchPointToAdd;


    private void OnEnable()
    {
        monsterHungerEventChannel.OnEventRaised += Activate;
       // rEManager.SettingPriceAndPunishment();
    }
    private void OnDisable()
    {
        monsterHungerEventChannel.OnEventRaised -= Activate;
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
           // rEManager.NoSecrafice(resource.cattle);
            
            //resource.cattle -= rEManager.punishment;
           // if (resource.cattle < 0)
           // {
          //      resource.cattle = 0;
          //  }
          price.cattle= rEManager.punishment;
        }
        if (rEManager.resourceIterator == 1)
        {
           // rEManager.NoSecrafice(resource.wood);
          //  resource.wood -= rEManager.punishment;
           // if (resource.wood < 0)
          //  {
           //     resource.wood = 0;
           // }
           price.wood= rEManager.punishment;
        }
        if (rEManager.resourceIterator == 2)
        {
          //  rEManager.NoSecrafice(resource.vilagers);
           // resource.vilagers -= rEManager.punishment;
           // if (resource.vilagers < 0)
            //{
           //    resource.vilagers = 0;
           // }
           price.vilagers= rEManager.punishment;
        }
        if (rEManager.resourceIterator == 3)
        {
            //rEManager.NoSecrafice(resource.gold);
           // resource.gold -= rEManager.punishment;
            //if (resource.gold < 0)
           // {
            //    resource.gold = 0;
           // }
           price.gold=rEManager.punishment;
        }
        if (rEManager.resourceIterator == 4)
        {
            //rEManager.NoSecrafice(resource.researchPoints);
           // resource.researchPoints -= rEManager.punishment;
           // if (resource.researchPoints < 0)
          //  {
          //      resource.researchPoints = 0;
          //  }
          price.researchPoints= rEManager.punishment;
        }
        resource.SpendReasource(price);
        Deactivate();
    }
    public void IfAceptedToSecrifice()
    {
       
        if (rEManager.eventType == RandomEventsManager.EventType.Madness)
        {
            //rEManager.Secrafice(resource.vilagers);
            //resource.vilagers -= rEManager.priceToPay;
           // if (resource.vilagers < 0)
           // {
           //     resource.vilagers = 0;
           // }
           price.vilagers = rEManager.priceToPay;
        }
        if (rEManager.eventType == RandomEventsManager.EventType.Desise)
        {
          //  rEManager.Secrafice(resource.gold);
           // resource.gold -= rEManager.priceToPay;
          //  if (resource.gold < 0)
           // {
           //     resource.gold = 0;
           // }
           price.gold = rEManager.priceToPay;
        }
        if (rEManager.eventType == RandomEventsManager.EventType.WildAnimals)
        {
            //rEManager.Secrafice(resource.wood);
          //  resource.wood -= rEManager.priceToPay;
          //  if (resource.wood < 0)
          //  {
          //      resource.wood = 0;
          //  }
          price.wood = rEManager.priceToPay;
        }
        if (rEManager.eventType == RandomEventsManager.EventType.Starvation)
        {
           // rEManager.Secrafice(resource.cattle);
           // resource.cattle -= rEManager.priceToPay;
           // if (resource.cattle < 0)
           // {
           //     resource.cattle = 0;
           // }
           price.cattle = rEManager.priceToPay;
        }
        if (rEManager.eventType == RandomEventsManager.EventType.FalingStar)
        {
          //  rEManager.Secrafice(resource.researchPoints);
         //   resource.researchPoints -= rEManager.priceToPay;
          //  if (resource.researchPoints < 0)
         //   {
          //      resource.researchPoints = 0;
           // }
           price.researchPoints = rEManager.priceToPay;
        }
        resource.SpendReasource(price);
        Deactivate();
    }

    public void RelevantSecrificeSprite()
    {
        if (rEManager.eventType == RandomEventsManager.EventType.Madness)
        {
            secrificeObject.GetComponent<Image>().sprite = listOfSprite[0];
        }
        if (rEManager.eventType == RandomEventsManager.EventType.Desise)
        {
            secrificeObject.GetComponent<Image>().sprite = listOfSprite[1];
        }
        if (rEManager.eventType == RandomEventsManager.EventType.WildAnimals)
        {
            secrificeObject.GetComponent<Image>().sprite = listOfSprite[2];
        }
        if (rEManager.eventType == RandomEventsManager.EventType.Starvation)
        {
            secrificeObject.GetComponent<Image>().sprite = listOfSprite[3];
        }
        if (rEManager.eventType == RandomEventsManager.EventType.FalingStar)
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
        priceText.text = rEManager.priceToPay.ToString() + " X ";
    }

    private void Deactivate()
    {
        //Add some research after event
        // resource.researchPoints += researchPointToAdd;
        price.wood = 0;
        price.gold = 0;
        price.vilagers = 0;
        price.cattle = 0;
        price.researchPoints = 0;
        EnableSacreficeButton();
        eventPromt.SetActive(false);
        GameManager.isEventUIActive = false;
    }

    public void DesableSecrificeButton()
    {
        secrificeButton.GetComponent<Collider2D>().enabled = false;
        Image image = secrificeButton.GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, .2f);
    }
    public void EnableSacreficeButton()
    {
        secrificeButton.GetComponent<Collider2D>().enabled = true;
        Image image = secrificeButton.GetComponent<Image>();
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
    }
}

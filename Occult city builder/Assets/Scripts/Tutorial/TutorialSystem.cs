using System;
using System.Collections;
using System.Collections.Generic;
using UI.Tooltip;
using UnityEngine;

public class TutorialSystem : MonoBehaviour
{
   
   
    [Header("Event channels: ")]
    [SerializeField] private VoidEventChannelSO buildEventChannelSo;
    [SerializeField] private VoidEventChannelSO monsterHungerEvent;
    [SerializeField] private VoidEventChannelSO monsterPowerEvent;
    [SerializeField] private VoidEventChannelSO resourceColletEvent;
    

    [SerializeField] private UIObject witchUtUI;
    
    
    [Header("Tutorial objects trasforms: ")]
    [SerializeField] private RectTransform tutorialBubbleTransform;
    [SerializeField] private Transform buildingHighlight;
    [SerializeField] private Transform tileHighlight;
   
    
    

    [Header("Toolitip tutorial text: ")]
    [SerializeField] private TooltipTextSO[] tutoialTextSos;


    [SerializeField] private GameObject eventManager;
    [SerializeField] private int time;
    
    
    
    //Flags
    private bool builtEventHappned = false;
    private bool resourceEventHappned = false;
    private bool monsterHungerEventhappned = false;
    private bool monsterFed =false;
    private bool powerEventHappend =false;
    private bool tileBlessedEvent = false;
    private bool tileHolyActivate = false;

   
    
    
    
    
    public  int currentTutorialObject=0;
    
    [Serializable]
    public struct HightLightObjects
    {
        public int id;
        public Transform buildingHighlight;
        public Transform tileHighlight;
        public Transform tutorialBubbleTransform;
    }

    [SerializeField] private List<HightLightObjects> _hightLightObjectsList;


    private void OnEnable()
    {
        BuildingManager.TileHoltActivate += OnActivateHoly;
        BuildingManager.TileBlessed += OnTileBlessed;
        MonsterManager.CursedTile += OnPowerEvent;
        buildEventChannelSo.OnEventRaised += OnBuiltEvent;
        resourceColletEvent.OnEventRaised += OnResourceEvent;
       

    }

    private void OnDisable()
    {
        BuildingManager.TileHoltActivate -= OnActivateHoly;
        MonsterManager.CursedTile -= OnPowerEvent;
        buildEventChannelSo.OnEventRaised -= OnBuiltEvent;
        resourceColletEvent.OnEventRaised -= OnResourceEvent;
        monsterHungerEvent.OnEventRaised -= OnHungerEvent;
        
    }


  


    private void Start()
    { 
        eventManager.SetActive(false);
        StartCoroutine(Tutorial());
    }

    void OnActivateHoly()
    {
        tileHolyActivate = true;
    }

    IEnumerator WaitForActiveHoly()
    {
        yield return new WaitUntil((() => tileHolyActivate));
        tileHolyActivate = false;
    }

    void OnTileBlessed()
    {
        tileBlessedEvent = true;
    }

    IEnumerator WaitForTileBlessedEvent()
    {
        yield return new WaitUntil((() => tileBlessedEvent));
        tileBlessedEvent = false;
    }
    

    void OnPowerEvent()
    {
        powerEventHappend = true;
    }

    IEnumerator WaitForPowerEvent()
    {
        yield return new WaitUntil((() => powerEventHappend));
        ShowTutorialObject(tutoialTextSos[24]);
        powerEventHappend = false;
        yield return new WaitForSeconds(2);
        ShowTutorialObject(tutoialTextSos[currentTutorialObject]);
    }
    

    void OnBuiltEvent()
    {
        builtEventHappned = true;
    }

    IEnumerator WaitForBuiltEvent()
    {
        yield return new WaitUntil(() => builtEventHappned);
        builtEventHappned = false;
    }
    
    
    void OnResourceEvent()
    {
        resourceEventHappned = true;
    }

    IEnumerator WaitForResoueceEvent()
    {
        yield return new WaitUntil(() => resourceEventHappned);
        resourceEventHappned = false;
    }
    
    void OnHungerEvent()
    {
        monsterHungerEventhappned = true;
    }

    IEnumerator WaitForHungerEvent()
    {
        monsterHungerEvent.OnEventRaised += OnHungerEvent;
        yield return new WaitUntil(() => monsterHungerEventhappned);
        eventManager.SetActive(true);
        monsterHungerEventhappned = false;
    }

    public void FeedMonster()
    {
        monsterFed = true;
    }


    IEnumerator Tutorial()
    {
       
        ShowTutorialObject(tutoialTextSos[currentTutorialObject]);
        yield return new WaitForSeconds(3f);
        
        currentTutorialObject++;
        ShowTutorialObject(tutoialTextSos[currentTutorialObject]);
        
        
        yield return StartCoroutine(WaitForBuiltEvent());
        currentTutorialObject++;
        ShowTutorialObject(tutoialTextSos[currentTutorialObject]);
        
        yield return new WaitForSeconds(time);
        currentTutorialObject++;
        ShowTutorialObject(tutoialTextSos[currentTutorialObject]);
        
        yield return new WaitForSeconds(time);
        currentTutorialObject++;
        ShowTutorialObject(tutoialTextSos[currentTutorialObject]);
        
        yield return StartCoroutine(WaitForBuiltEvent());
        currentTutorialObject++;
        ShowTutorialObject(tutoialTextSos[currentTutorialObject]);
        
        yield return new WaitForSeconds(time);
        currentTutorialObject++;
        ShowTutorialObject(tutoialTextSos[currentTutorialObject]);
        
        yield return new WaitForSeconds(time);
        yield return StartCoroutine(WaitForResoueceEvent());
        currentTutorialObject++;
        ShowTutorialObject(tutoialTextSos[currentTutorialObject]);
        
        yield return new WaitForSeconds(time);
        currentTutorialObject++;
        ShowTutorialObject(tutoialTextSos[currentTutorialObject]);
        
        
        yield return new WaitForSeconds(time);
        currentTutorialObject++;
        ShowTutorialObject(tutoialTextSos[currentTutorialObject]);
        
        yield return new WaitForSeconds(time);
        currentTutorialObject++;
        ShowTutorialObject(tutoialTextSos[currentTutorialObject]);
        
       
        
        yield return StartCoroutine(WaitForBuiltEvent());
        currentTutorialObject++;
        ShowTutorialObject(tutoialTextSos[currentTutorialObject]);
       
        
        yield return StartCoroutine(WaitForBuiltEvent());
        TutorialTextSystem.Hide();
        
        
        
        yield return StartCoroutine(WaitForHungerEvent());
       
        
        
        yield return new WaitUntil(() => GameManager.isEventUIActive);
        currentTutorialObject++;
        ShowTutorialObject(tutoialTextSos[currentTutorialObject]);
        
        yield return new WaitForSeconds(time);
        currentTutorialObject++;
        ShowTutorialObject(tutoialTextSos[currentTutorialObject]);
        
        yield return new WaitForSeconds(2f);
        currentTutorialObject++;
        ShowTutorialObject(tutoialTextSos[currentTutorialObject]);
        
        
        yield return new WaitUntil(() => !GameManager.isEventUIActive);
        eventManager.SetActive(false);
        currentTutorialObject++;
        ShowTutorialObject(tutoialTextSos[currentTutorialObject]);
        
        yield return new WaitUntil(() => monsterFed);
        currentTutorialObject++;
        ShowTutorialObject(tutoialTextSos[currentTutorialObject]);
       
        
        yield return new WaitForSeconds(time);
        yield return StartCoroutine(WaitForPowerEvent());
        currentTutorialObject++;
        ShowTutorialObject(tutoialTextSos[currentTutorialObject]);
        
        
        
        
        yield return StartCoroutine(WaitForBuiltEvent());
        currentTutorialObject++;
        ShowTutorialObject(tutoialTextSos[currentTutorialObject]);
        
        yield return StartCoroutine(WaitForTileBlessedEvent());
        currentTutorialObject++;
        ShowTutorialObject(tutoialTextSos[currentTutorialObject]);
        monsterFed = false;
        
        yield return new WaitUntil(() => monsterFed);
        currentTutorialObject++;
        ShowTutorialObject(tutoialTextSos[currentTutorialObject]);
        
        yield return StartCoroutine(WaitForActiveHoly());
        currentTutorialObject++;
        ShowTutorialObject(tutoialTextSos[currentTutorialObject]); 
        
        
       
        
       
      
        
      
        
        
       

        

    }

   

   

  
    private void ShowTutorialObject(TooltipTextSO tooltipTextSo)
    {
       
       
        TutorialTextSystem.Show(tooltipTextSo);
        
        if (tutoialTextSos[currentTutorialObject].id != 0)
        {
            var hightLightObject =  GetHighlightObject(tooltipTextSo.id);
            //todo maybe make a for loop here for 2 arrays
            if (hightLightObject.buildingHighlight != null)
            {
                buildingHighlight.gameObject.SetActive(true);
                ChangePosTransform(hightLightObject.buildingHighlight,buildingHighlight);
            } else buildingHighlight.gameObject.SetActive(false);

            if (hightLightObject.tileHighlight != null)
            {
                tileHighlight.gameObject.SetActive(true);
                ChangePosTransform(hightLightObject.tileHighlight,tileHighlight);
            } else  tileHighlight.gameObject.SetActive(false);
               
            if(hightLightObject.tutorialBubbleTransform !=null)
                ChangePosTransform(hightLightObject.tutorialBubbleTransform,tutorialBubbleTransform);
        }
        
    }
    
    void ChangePosTransform(Transform newPos, Transform objectToMove)
    {
        objectToMove.position = newPos.position;
    }

    HightLightObjects GetHighlightObject(int id)
    {
        HightLightObjects hightLightObject = default;
        
        foreach (var highlightObjects in _hightLightObjectsList)
        {
            //todo change to just highlite object
            if (id == highlightObjects.id)
            {
                hightLightObject= highlightObjects;
                return hightLightObject; 
               
            }
        }

        return hightLightObject; 

    }
}

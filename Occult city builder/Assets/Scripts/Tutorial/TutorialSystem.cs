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
    
    
    
    //Flags
    private bool builtEventHappned = false;
    private bool resourceEventHappned = false;
    private bool monsterHungerEventhappned = false;
    private bool monsterFed =false;

   
    
    
    
    
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
        buildEventChannelSo.OnEventRaised += OnBuiltEvent;
        resourceColletEvent.OnEventRaised += OnResourceEvent;
       

    }

    private void OnDisable()
    {
        buildEventChannelSo.OnEventRaised -= OnBuiltEvent;
        resourceColletEvent.OnEventRaised -= OnResourceEvent;
        monsterHungerEvent.OnEventRaised -= OnHungerEvent;
        
    }


    private void Update()
    {
    }


    private void Start()
    { 
        eventManager.SetActive(false);
        StartCoroutine(Tutorial());
    }
    
    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
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
       
        yield return new WaitUntil(() => monsterHungerEventhappned);
        monsterHungerEventhappned = false;
    }

    public void FeedMonster()
    {
        monsterFed = true;
    }


    IEnumerator Tutorial()
    {
       
        SHowCurrentTutorialObject();
        yield return new WaitForSeconds(3f);
        
        currentTutorialObject++;
        SHowCurrentTutorialObject();
        
        
        yield return StartCoroutine(WaitForBuiltEvent());
        currentTutorialObject++;
        SHowCurrentTutorialObject();
        
        yield return new WaitForSeconds(2f);
        currentTutorialObject++;
        SHowCurrentTutorialObject();
        
        yield return new WaitForSeconds(2f);
        currentTutorialObject++;
        SHowCurrentTutorialObject();
        
        yield return StartCoroutine(WaitForBuiltEvent());
        currentTutorialObject++;
        SHowCurrentTutorialObject();
        
        yield return new WaitForSeconds(2f);
        currentTutorialObject++;
        SHowCurrentTutorialObject();
        
        yield return new WaitForSeconds(3f);
        yield return StartCoroutine(WaitForResoueceEvent());
        currentTutorialObject++;
        SHowCurrentTutorialObject();
        
        yield return new WaitForSeconds(2f);
        currentTutorialObject++;
        SHowCurrentTutorialObject();
        
        
        yield return new WaitForSeconds(2f);
        currentTutorialObject++;
        SHowCurrentTutorialObject();
        
        yield return new WaitForSeconds(2f);
        currentTutorialObject++;
        SHowCurrentTutorialObject();
        
       
        
        yield return StartCoroutine(WaitForBuiltEvent());
        yield return new WaitForSeconds(2f);
        TutorialTextSystem.Hide();
        
        
        monsterHungerEvent.OnEventRaised += OnHungerEvent;
        yield return StartCoroutine(WaitForHungerEvent());
        eventManager.SetActive(true);
        
        
        yield return new WaitUntil(() => GameManager.isEventUIActive);
        currentTutorialObject++;
        SHowCurrentTutorialObject();
        
        yield return new WaitForSeconds(2f);
        currentTutorialObject++;
        SHowCurrentTutorialObject();
        
        yield return new WaitForSeconds(2f);
        currentTutorialObject++;
        SHowCurrentTutorialObject();
        
        
        yield return new WaitUntil(() => !GameManager.isEventUIActive);
        eventManager.SetActive(false);
        currentTutorialObject++;
        SHowCurrentTutorialObject();
        
        yield return new WaitUntil(() => monsterFed);
        currentTutorialObject++;
        SHowCurrentTutorialObject();
        
        yield return new WaitForSeconds(2f);
        currentTutorialObject++;
        SHowCurrentTutorialObject();
        
        yield return StartCoroutine(WaitForBuiltEvent());
        yield return StartCoroutine(WaitForHungerEvent());
        currentTutorialObject++;
        SHowCurrentTutorialObject();
      
        
        
       

        

    }

   

   

  
    private void SHowCurrentTutorialObject()
    {
       
       
        TutorialTextSystem.Show(tutoialTextSos[currentTutorialObject]);
        
        if (tutoialTextSos[currentTutorialObject].id != 0)
        {
            var hightLightObject =  GetHighlightObject(tutoialTextSos[currentTutorialObject].id);
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
            if (id == highlightObjects.id)
            {
                hightLightObject= highlightObjects;
                return hightLightObject; 
               
            }
        }

        return hightLightObject; 

    }
}

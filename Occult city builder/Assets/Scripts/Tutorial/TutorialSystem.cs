using System;
using System.Collections;
using System.Collections.Generic;
using UI.Tooltip;
using UnityEngine;

public class TutorialSystem : MonoBehaviour
{
   
   

    [SerializeField] private VoidEventChannelSO buildEventChannelSo;
    [SerializeField] private VoidEventChannelSO monsterHungerEvent;
    [SerializeField] private VoidEventChannelSO monsterPowerEvent;
    [SerializeField] private VoidEventChannelSO resourceColletEvent;
    

    [SerializeField] private UIObject witchUtUI;

    [SerializeField] private RectTransform tutorialBubbleTransform;

    [SerializeField] private RectTransform[] bubblePosArray;
    
    

    [SerializeField] private TooltipTextSO[] tutoialTextSos;
    public  int currentTutorialObject=0;
    
    

    private void OnDisable()
    {
        buildEventChannelSo.OnEventRaised -= BuildTutorialInfo;
        
    }


    private void Update()
    {
        
    }


    private void Start()
    {
      
        StartCoroutine(Tutorial());
    }
    
    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
    

   

    IEnumerator Tutorial()
    {
        SHowCurrentTutorialObject();
        currentTutorialObject++;
        
        yield return new WaitForSeconds(3f);
        SHowCurrentTutorialObject();
        ChangeBubbleTranform(0);

        //GameManager.PauseGame();
       
        
        buildEventChannelSo.OnEventRaised += BuildTutorialInfo;
        monsterHungerEvent.OnEventRaised += ShowOnHungerEventText;
        SHowCurrentTutorialObject();
        yield return new WaitForSeconds(3f);
     
      
        
       
        yield return CanbuildUt();

        
    }

    private void ChangeBubbleTranform(int transArray)
    {
        tutorialBubbleTransform.position = bubblePosArray[transArray].position;
        tutorialBubbleTransform.localScale = bubblePosArray[transArray].localScale;
    }

    IEnumerator CanbuildUt()
    {
        if (witchUtUI.canBuild)
        {
            
            TutorialTextSystem.Show(tutoialTextSos[6]);
            
            SHowCurrentTutorialObject();
            yield break;
            
        }
        
    }
    

    void ShowCuresedTileText()
    {
        TutorialTextSystem.Show(tutoialTextSos[2]);
        monsterHungerEvent.OnEventRaised -= ShowCuresedTileText;
      
        SHowCurrentTutorialObject();
       
    }

    void  BuildTutorialInfo()
    {
        GameManager.ResumeGame();
        TutorialTextSystem.Show(tutoialTextSos[2]);
        buildEventChannelSo.OnEventRaised -= BuildTutorialInfo;
        resourceColletEvent.OnEventRaised += ShowResorceCollectText;
      
        

    }

    void ShowOnHungerEventText()
    {
        Debug.Log("Monster hunger event tutorial");
        TutorialTextSystem.Show(tutoialTextSos[4]);
        ChangeBubbleTranform(2);

       // monsterHungerEvent.OnEventRaised -= ShowOnHungerEventText;
        StartCoroutine(DeactivateUIEvent());
        
        //Coroutine for wait until event is no longer active 
        IEnumerator DeactivateUIEvent()
        {
            yield return new WaitUntil(() => !GameManager.isEventUIActive);
          
            
                ChangeBubbleTranform(currentTutorialObject-1);
                SHowCurrentTutorialObject();
                
        }
        
          
      
       
      

    }
    void ShowResorceCollectText()
    {
        currentTutorialObject++;
        TutorialTextSystem.Show(tutoialTextSos[3]);
        ChangeBubbleTranform(1);
        resourceColletEvent.OnEventRaised -= ShowResorceCollectText;
        StartCoroutine(Wait());
        
        
        IEnumerator Wait()
        {
            yield return new WaitForSeconds(4);
           
            
        }
       
       
       
    }

    private void SHowCurrentTutorialObject()
    {
        TutorialTextSystem.Show(tutoialTextSos[currentTutorialObject]);
       
       
    }
}

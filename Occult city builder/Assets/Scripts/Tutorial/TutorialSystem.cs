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
    
    

    [SerializeField] private TooltipTextSO[] tutoialTextSos;
    public  int currentTutorialObject=0;
    private void Awake()
    {
        GameManager.isTutorial = true;
    }

    private void OnEnable()
    {
       
        
    }

    private void OnDisable()
    {
        buildEventChannelSo.OnEventRaised -= BuildTutorialInfo;
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
       buildEventChannelSo.OnEventRaised += BuildTutorialInfo;
       SHowCurrentTutorialObject();
        
        currentTutorialObject++;
        yield return CanbuildUt();




    }

    IEnumerator CanbuildUt()
    {
        if (witchUtUI.canBuild)
        {
            TutorialTextSystem.Show(tutoialTextSos[6]);
            StartCoroutine(Wait(1));
            SHowCurrentTutorialObject();
            yield break;
            
        }
        
    }
    

    void ShowCuresedTileText()
    {
        TutorialTextSystem.Show(tutoialTextSos[2]);
        monsterHungerEvent.OnEventRaised -= ShowCuresedTileText;
        StartCoroutine(Wait(1));
        SHowCurrentTutorialObject();
       
    }

    void  BuildTutorialInfo()
    {
        TutorialTextSystem.Show(tutoialTextSos[2]);
        currentTutorialObject++;
        buildEventChannelSo.OnEventRaised -= BuildTutorialInfo;
        StartCoroutine(Wait(1));
        resourceColletEvent.OnEventRaised += ShowResorceCollectText;
      
        

    }

    void ShowOnHungerEventText()
    {
        TutorialTextSystem.Show(tutoialTextSos[4]);
      
        monsterHungerEvent.OnEventRaised -= ShowOnHungerEventText;
        StartCoroutine(Wait(1));
       
      

    }
    void ShowResorceCollectText()
    {
        TutorialTextSystem.Show(tutoialTextSos[3]);
        resourceColletEvent.OnEventRaised -= ShowResorceCollectText;
        StartCoroutine(Wait(1));
        resourceColletEvent.OnEventRaised += ShowOnHungerEventText;
       
       
    }

    private void SHowCurrentTutorialObject()
    {
        TutorialTextSystem.Show(tutoialTextSos[currentTutorialObject]);
       
    }
}

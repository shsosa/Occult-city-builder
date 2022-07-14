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

   
    
    

    [SerializeField] private TooltipTextSO[] tutoialTextSos;
    public  int currentTutorialObject=0;
    
    [Serializable]
    public struct HightLightObjects
    {
        public int id;
        public Transform[] newTransform;
    }

    [SerializeField] private List<HightLightObjects> _hightLightObjectsList;

    [SerializeField] private Transform buildingHighlight;
    [SerializeField] private Transform tileHighlight;
    

    private void OnDisable()
    {
        buildEventChannelSo.OnEventRaised -= BuildTutorialInfo;
        
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SHowCurrentTutorialObject();
            currentTutorialObject++;
        }
    }


    private void Start()
    {
      
       // StartCoroutine(Tutorial());
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
       

        //GameManager.PauseGame();
       
        
        buildEventChannelSo.OnEventRaised += BuildTutorialInfo;
        monsterHungerEvent.OnEventRaised += ShowOnHungerEventText;
        SHowCurrentTutorialObject();
        yield return new WaitForSeconds(3f);
     
      
        
       
        yield return CanbuildUt();

        
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
       
        //todo when to deactivate maybe when player press button "understood"
       // monsterHungerEvent.OnEventRaised -= ShowOnHungerEventText;
        StartCoroutine(DeactivateUIEvent());
        
        //Coroutine for wait until event is no longer active 
        IEnumerator DeactivateUIEvent()
        {
            yield return new WaitUntil(() => !GameManager.isEventUIActive);
          
            
               
                SHowCurrentTutorialObject();
                
        }
        
          
      
       
      

    }
    void ShowResorceCollectText()
    {
        currentTutorialObject++;
        TutorialTextSystem.Show(tutoialTextSos[3]);
      
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
        
        if (tutoialTextSos[currentTutorialObject].id != 0)
        {
            var hightLightObject =  GetHighlightObject(tutoialTextSos[currentTutorialObject].id);
            
            
            ChangePosTransform(hightLightObject.newTransform[0],buildingHighlight);
            ChangePosTransform(hightLightObject.newTransform[1],tileHighlight);
            if(hightLightObject.newTransform[2] !=null)
                ChangePosTransform(hightLightObject.newTransform[2],tutorialBubbleTransform);
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
                goto exitLoop;
            }
        }
    
        exitLoop:
        return hightLightObject;
    }
}

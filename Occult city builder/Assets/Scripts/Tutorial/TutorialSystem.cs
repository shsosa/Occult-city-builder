using System;
using System.Collections;
using System.Collections.Generic;
using UI.Tooltip;
using UnityEngine;

public class TutorialSystem : MonoBehaviour
{
   
    [SerializeField] private TutorialTextSystem _tutorialTextSystem;

    [SerializeField] private VoidEventChannelSO buildEventChannelSo;
    

    [SerializeField] private string buildFirstbuilding;

    [SerializeField] private TooltipTextSO[] tutoialTextSos;

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

   void  BuildTutorialInfo()
    {
        _tutorialTextSystem.Show(tutoialTextSos[2].Content, tutoialTextSos[2].header);
            
        
        buildEventChannelSo.OnEventRaised -= BuildTutorialInfo;
       
    }
    
    private void Start()
    {
      
        StartCoroutine(Tutorial());
    }


   
    IEnumerator Tutorial()
    {
        _tutorialTextSystem.Show(tutoialTextSos[0].Content, tutoialTextSos[0].header);
        yield return new WaitForSeconds(3f);
        _tutorialTextSystem.Show(tutoialTextSos[1].Content, tutoialTextSos[1].header);
        buildEventChannelSo.OnEventRaised += BuildTutorialInfo;
        
        
    }
}

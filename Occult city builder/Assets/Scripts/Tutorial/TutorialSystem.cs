using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSystem : MonoBehaviour
{
   
    [SerializeField] private TutorialTextSystem _tutorialTextSystem;

    [SerializeField] private VoidEventChannelSO buildEventChannelSo;

    [SerializeField] private string buildFirstbuilding;


    private void OnEnable()
    {
        buildEventChannelSo.OnEventRaised += BuildTutorialInfo;
    }

    private void OnDisable()
    {
        buildEventChannelSo.OnEventRaised -= BuildTutorialInfo;
    }

    void BuildTutorialInfo()
    {
        _tutorialTextSystem.Show("Building", buildFirstbuilding);
        buildEventChannelSo.OnEventRaised -= BuildTutorialInfo;
    }

    
}

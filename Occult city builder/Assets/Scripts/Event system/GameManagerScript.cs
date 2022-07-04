using System;
using System.Collections;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public VoidEventChannelSO CollectReasources;
    public VoidEventChannelSO SacredSiteBuiltEvent;
    [SerializeField] private float time;
    [SerializeField] private int numberOfScaredSitesActive =0;

    private void OnEnable()
    {
        SacredSiteBuiltEvent.OnEventRaised += UpdateSacretSitesActive;
    }

    private void Start()
    {
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(time);
        CollectReasources.RaiseEvent();
        StartCoroutine(Timer());
    }

    void UpdateSacretSitesActive()
    {
        numberOfScaredSitesActive++;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class FeedbackEffects : MonoBehaviour
{
    private static FeedbackEffects current;
    
    [Header("Place building on tile effects "  )]
    [SerializeField] private VoidEventChannelSO buildChannelSo;
    [SerializeField] private MMFeedbacks PlaceBuildingOnTileFeedbacks;
    [Header("Instantiate building from UI effects:")]
    [SerializeField] private VoidEventChannelSO InstanitateBuildingChannelSO;
    [SerializeField] private MMFeedbacks MMInstantiateBuildinFeedbacks;
    [Header("Collect resources effects:")]
    [SerializeField] private VoidEventChannelSO CollectReasourcesSO;
    [SerializeField] private MMFeedbacks collectResourcesFeddbacks;


    [Serializable]
    public struct FeelEffects
    {
        public string name;
        public MMFeedbacks Feedbacks;
    }

   
    public List<FeelEffects> FeelEffectsList;

    void Awake()
    {
       // DontDestroyOnLoad(this.gameObject);
       current = this;
    }

    private void OnEnable()
    {
       
        buildChannelSo.OnEventRaised += PlaceBUildingEvent;
        InstanitateBuildingChannelSO.OnEventRaised += InstantiateBuildingEvent;
        CollectReasourcesSO.OnEventRaised += CollectResourcesEvent;
    }
    private void CollectResourcesEvent()
    {
        current.collectResourcesFeddbacks.PlayFeedbacks();
    }

    void InstantiateBuildingEvent()
    {
        current.MMInstantiateBuildinFeedbacks.PlayFeedbacks();
    }

    private void PlaceBUildingEvent()
    {
        current.PlaceBuildingOnTileFeedbacks.PlayFeedbacks();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
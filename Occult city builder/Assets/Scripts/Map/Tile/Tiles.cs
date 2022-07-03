using System;
using System.ComponentModel.Design;
using MoreMountains.Feedbacks;
using Unity.VisualScripting;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite normalSprite;
    public ResourceTypeData type;
    public ResourceTypeData building;
    public Sprite cursedSprite;
    [SerializeField] private ResourceData _resourceDataScriptable;
    public VoidEventChannelSO resourceManager,monsterPowerEvent;
    
    [SerializeField] BuildingManager _buildingManager;
    private FeedbackEffects feedbackEffectsManager;
    private MMFeedbacks tileFeedbacks;
    
    public bool hasBuilding =false;
    public bool hasBonus,isCursed, nextToSite;
    public int amountOfReasourceProdused;
    private PolygonCollider2D _polygonCollider2D;

    private void Awake()
    {
        feedbackEffectsManager = FindObjectOfType<FeedbackEffects>();
        
    }

    private void Start()
    {
       
        _buildingManager = FindObjectOfType<BuildingManager>();
       
        tileFeedbacks = feedbackEffectsManager.FeelEffectsList[0].Feedbacks;
        spriteRenderer = GetComponent<SpriteRenderer>();
        normalSprite = spriteRenderer.sprite;
        _polygonCollider2D = GetComponent<PolygonCollider2D>();
            if(building!= null)
                building = GetComponentInChildren<Building>()._resourceTypeData;
        
    }

    private void OnEnable()
    {
       
        resourceManager.OnEventRaised += TileProduction;
        
    }

    private void OnDisable()
    { 
        resourceManager.OnEventRaised -= TileProduction;
    }
    
    
    
    private void Update()
    {
        if (hasBuilding )
        {
            _polygonCollider2D.isTrigger = false;
            if (!isCursed)
            {
                building = GetComponentInChildren<Building>()?._resourceTypeData;
            }
        }
        else
        {
            _polygonCollider2D.isTrigger = true;
        }
        
        
           

    }
    
    

    public void TileProduction()
    {

        int totalAmountToProduce = amountOfReasourceProdused;
        if (hasBonus)
            totalAmountToProduce = amountOfReasourceProdused * building.bonus;
        if(hasBuilding && !isCursed && building != null&&!GameManager.isEventUIActive)
             _resourceDataScriptable.IncreaseResource(building._resourceType,totalAmountToProduce);
    }
    public void SetCursed()
    {
        isCursed = true;
        
        spriteRenderer.sprite = cursedSprite;
        if(hasBuilding && building !=null)
        {
            hasBuilding = false;
            Destroy(transform.GetChild(0).gameObject);
            hasBonus = false;
        } 
    }

    public void SetNotCursed()
    {
        isCursed = false;
        spriteRenderer.sprite = normalSprite;
    }

    private void OnMouseExit()
    {
        spriteRenderer.sortingOrder = 0;
        spriteRenderer.color = Color.white;
            _buildingManager.tile = null;
    }
    

    private void OnMouseOver()
    {
        _buildingManager.tile = gameObject;
        
    }

    public void TileHoverEffect()
    {
        
        tileFeedbacks.GetComponent<MMFeedbackScale>().AnimateScaleTarget = transform;
        tileFeedbacks.PlayFeedbacks();
        spriteRenderer.sortingOrder=1;
    }

    public void ChangeTileColor(Color color)
    {
        spriteRenderer.color = color;
    }

    public void ActivateSacredSite()
    {
        SpriteRenderer sacredSite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        sacredSite.color = Color.Lerp(Color.blue, Color.cyan, 1f);
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("HolyTile"))
        {
            Debug.Log("Tile next to site " + name);

            nextToSite = true;
        }
       
    }
}

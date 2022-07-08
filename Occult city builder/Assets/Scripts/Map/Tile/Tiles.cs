using System;
using System.Collections;
using System.ComponentModel.Design;
using MoreMountains.Feedbacks;
using UI.Tooltip;
using Unity.VisualScripting;
using UnityEngine;

public class Tiles : MonoBehaviour
{
     public  string header;
     public string content;

  
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
    [SerializeField] private TooltipTextSO _tooltipTextSo;
    
    public bool hasBuilding =false;
    public bool hasBonus,isCursed, isHoly,isErelevantToLoseCondition,isBlesed;
    public int amountOfReasourceProdused;
    
   
    private PolygonCollider2D _polygonCollider2D;

    private void Awake()
    {
        feedbackEffectsManager = FindObjectOfType<FeedbackEffects>();
        RelevancyToLoseCondition();
        
          
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

        WorkAroundForWinCondition(); 
    }
    
    

    public void TileProduction()
    {

        int totalAmountToProduce = amountOfReasourceProdused;
        if (hasBonus && building != null)
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
        if(header != null && content != null)
            TooltipSystem.Hide();
        spriteRenderer.sortingOrder = 0;
        spriteRenderer.color = Color.white;
            _buildingManager.tile = null;
            
           
    }

    private void OnMouseEnter()
    {
        if(header != null && content != null)
          StartCoroutine(DelayTooltip());
    }

    private void OnMouseOver()
    {
        _buildingManager.tile = gameObject;
     

    }

    IEnumerator DelayTooltip()
    {
        yield return new WaitForSeconds(0.5f);
        if(header!=null && content != null)
            TooltipSystem.Show(_tooltipTextSo);
    }

    public void TileHoverEffect()
    {
        if (tileFeedbacks != null)
        {
            tileFeedbacks.GetComponent<MMFeedbackScale>().AnimateScaleTarget = transform;
            tileFeedbacks.PlayFeedbacks();
            spriteRenderer.sortingOrder=1;
        }
       
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
    private void RelevancyToLoseCondition()
    {
        if(gameObject.CompareTag("HolyTile"))
        {
            isErelevantToLoseCondition = true;
        }
    }
    private void WorkAroundForWinCondition()
    {
        if(isErelevantToLoseCondition&&hasBuilding&&!isBlesed)
        {
            GameManager.numOfTilesToWin++;
            isBlesed = true;
        }

    }

    

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("HolyTile"))
        {
            Debug.Log("Tile next to site " + name);

            isHoly = true;
        }      
    }
}

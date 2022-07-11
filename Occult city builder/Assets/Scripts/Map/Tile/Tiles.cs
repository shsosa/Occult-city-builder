using System;
using System.Collections;
using System.ComponentModel.Design;
using MoreMountains.Feedbacks;
using UI.Tooltip;
using Unity.VisualScripting;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    
    [Header("Tool tip content: "+ "\n")]
     [SerializeField]  string header;
     [TextArea]
     [SerializeField] private string content;
     [SerializeField] private Sprite iconSprit;
     [SerializeField] private TooltipTextSO _tooltipTextSo;

    [Header("Tile states : " + "\n")]
    private SpriteRenderer spriteRenderer;
    public Sprite normalSprite;
    public ResourceTypeData type;
    public ResourceTypeData building;
    public Sprite cursedSprite;
    
    [Header("Resources SO: "+ "\n")]
    [SerializeField] private ResourceData _resourceDataScriptable;
    
    [Header("Events channels: "+ "\n")]
    public VoidEventChannelSO resourceManager,monsterPowerEvent;
    
    [Header("Managers: "+ "\n")]
    [SerializeField] BuildingManager _buildingManager;
    private FeedbackEffects feedbackEffectsManager;
    private MMFeedbacks tileFeedbacks;
   
    
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
        _tooltipTextSo.iconSprite = null;
        if(header != null && content != null)
            TooltipSystem.Hide(_tooltipTextSo);
        spriteRenderer.sortingOrder = 0;
        spriteRenderer.color = Color.white;
            _buildingManager.tile = null;
            
           
    }

    private void OnMouseEnter()
    {
        if(header != null && content != null )
          StartCoroutine(DelayTooltip());
        else
        {
            TooltipSystem.Hide(_tooltipTextSo);
        }
    }

    private void OnMouseOver()
    {
        _buildingManager.tile = gameObject;
     

    }

    IEnumerator DelayTooltip()
    {
       
        
            
        yield return new WaitForSeconds(0.001f);
        if (_tooltipTextSo != null )
        {
           
            _tooltipTextSo.header = header;
            _tooltipTextSo.Content = "";
            TooltipSystem.Show(_tooltipTextSo);
            
           
        }
           
    }

    public void ActivateBonusContent()
    {
        if (iconSprit != null)
        {
            _tooltipTextSo.iconSprite = iconSprit;
            _tooltipTextSo.Content = content;
            TooltipSystem.Show(_tooltipTextSo);
        }
        
    }
    public void DeactivateBonusContent()
    {
        
        TooltipSystem.Hide(_tooltipTextSo);
        
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

using System;
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
    [SerializeField] private MMFeedbacks tileFeedbacks;
    
    
    public bool hasBuilding =false;
    public bool hasBonus,isCursed;
    public int amountOfReasourceProdused;
    private PolygonCollider2D _polygonCollider2D;
    private void Start()
    {
       
        _buildingManager = FindObjectOfType<BuildingManager>();
        
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
        if(hasBuilding && !isCursed)
             _resourceDataScriptable.IncreaseResource(building._resourceType,amountOfReasourceProdused);
    }
    public void SetCursed()
    {
        isCursed = true;
        spriteRenderer.sprite = cursedSprite;
        if(hasBuilding)
        {
            Destroy(transform.GetChild(0).gameObject);
            hasBuilding = false;
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

    

   
}

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
             _resourceDataScriptable.IncreaseResource(type._resourceType,amountOfReasourceProdused);
    }
    public void SetCursed()
    {
        isCursed = true;
        spriteRenderer.sprite = cursedSprite;
        if(hasBuilding)
        {
            Destroy(transform.GetChild(0).gameObject);
            hasBuilding = false;
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
        switch (hasBuilding)
        {
            case false:
                if (_buildingManager.hasInstantiatedBuilding && !isCursed)
                {
                    
                    spriteRenderer.sortingOrder=1;
                    if(_buildingManager.building != null)
                    if (_buildingManager.building.GetComponent<Building>()._typeOfDraggableItem ==
                        Building.TypeOfDraggableItem.Building)
                    {
                        tileFeedbacks.GetComponent<MMFeedbackScale>().AnimateScaleTarget = transform;
                        tileFeedbacks.PlayFeedbacks();
                    }
                   
                    _buildingManager.tile = gameObject;
                }
                break;
            
            case true:
                if (_buildingManager.hasInstantiatedBuilding)
                {
                    if(_buildingManager.building != null)
                        if (_buildingManager.building.GetComponent<Building>()._typeOfDraggableItem ==
                            Building.TypeOfDraggableItem.Building)
                            spriteRenderer.color = Color.red;
                    
                    
                }
                
                break;
        }

        if (isCursed && _buildingManager.hasInstantiatedBuilding)
        {
            if(_buildingManager.building != null)
                if (_buildingManager.building.GetComponent<Building>()._typeOfDraggableItem ==
                    Building.TypeOfDraggableItem.Research)
                {
                    tileFeedbacks.GetComponent<MMFeedbackScale>().AnimateScaleTarget = transform;
                    tileFeedbacks.PlayFeedbacks();
                    spriteRenderer.color = Color.red;
                }
            spriteRenderer.sortingOrder=1;
            _buildingManager.tile = gameObject;
           
            
        }
           
              
        
       
    }

    void TileHasBuilding()
    {
        hasBuilding = true;
    }

   
}

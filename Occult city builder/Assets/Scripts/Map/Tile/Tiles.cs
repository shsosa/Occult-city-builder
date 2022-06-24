using System;
using MoreMountains.Feedbacks;
using Unity.VisualScripting;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite normalSprite;
    public ResourceTypeData type;
    public ResourceTypeData building;
    public Sprite cursedSprite;
    [SerializeField] private ResourceData _resourceDataScriptable;
    public VoidEventChannelSO resourceManager,monsterPowerEvent;
    
    [SerializeField] BuildingManager _buildingManager;
    
    
    public bool hasBuilding =false;
    public bool hasBonus,isCursed;
    public int amountOfReasourceProdused;
    private PolygonCollider2D _polygonCollider2D;
    private void Start()
    {
        _buildingManager = FindObjectOfType<BuildingManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        //normalSprite = spriteRenderer.sprite;
        _polygonCollider2D = GetComponent<PolygonCollider2D>();
            if(building!= null)
                building = GetComponentInChildren<Building>()._resourceTypeData;
        
    }

    private void OnEnable()
    {
       
        resourceManager.OnEventRaised += TileProduction;
        
    }

    private void Update()
    {
        if (hasBuilding )
        {
            _polygonCollider2D.isTrigger = false;
            if (!isCursed)
            {
                building = GetComponentInChildren<Building>()._resourceTypeData;
            }
        }
        else
        {
            _polygonCollider2D.isTrigger = true;
        }

    }

    public void ChangeColor()
    {
        GetComponent<SpriteRenderer>().color = Color.blue;
    }

    public void TileProduction()
    {
        if(hasBuilding)
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

    private void OnMouseExit()
    {
        
            GetComponent<SpriteRenderer>().color = Color.white;
            _buildingManager.tile = null;
    }
    

    private void OnMouseOver()
    {
        switch (hasBuilding)
        {
            case false:
                if (_buildingManager.hasInstantiatedBuilding)
                {
                    GetComponent<SpriteRenderer>().color = Color.blue;
                    _buildingManager.tile = gameObject;
                }
                break;
            
            case true:
                if(_buildingManager.hasInstantiatedBuilding)
                    GetComponent<SpriteRenderer>().color = Color.red;
                _buildingManager.tile = null;
               
                break;
        }
       
        
              
        
       
    }

    void TileHasBuilding()
    {
        hasBuilding = true;
    }

   
}

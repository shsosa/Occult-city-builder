using System;
using System.Collections;
using System.Collections.Generic;
using InputMouse;
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
    
    
    public bool hasBuilding =false;
    public bool hasBonus,isCursed;
    public int amountOfReasourceProdused;
    private PolygonCollider2D _polygonCollider2D;
    private void Start()
    {
        normalSprite = spriteRenderer.sprite;
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
        if (hasBuilding)
        {
            _polygonCollider2D.isTrigger = false;
            building = GetComponentInChildren<Building>()._resourceTypeData;    
        }
        else
        {
            _polygonCollider2D.isTrigger = true;
        }
            
        
        
    }

    

    public void TileProduction()
    {
        if(hasBuilding&&!isCursed)
             _resourceDataScriptable.IncreaseResource(type._resourceType,amountOfReasourceProdused);
    }
    public void SetCursed()
    {
        isCursed = true;
        spriteRenderer.sprite = cursedSprite;
    }
    
 
}

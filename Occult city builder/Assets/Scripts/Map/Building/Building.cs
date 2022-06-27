using System;
using DefaultNamespace;using Game_managment;
using InputMouse;
using Unity.VisualScripting;
using UnityEngine;


public class Building : MonoBehaviour, Idraggable
{
    //todo make building id - like the order on the ui screen
  public enum TypeOfDraggableItem
   {
       Building , Secrifice, Research
   }

   public TypeOfDraggableItem _typeOfDraggableItem;

    #region SerializedData

    public ResourceTypeData _resourceTypeData;
    [SerializeField] private ReasourcePrice reasourcePrice;
    [SerializeField] private ResourceData _resourceDataSO;
    public VoidEventChannelSO BuildEventChannelSo;
    public GameObject tile;

    #endregion
    
    #region Building Bool States

    public bool isDragged;
    private bool isOnTile = false;
    private bool isBuildingChildOfTile = false;

    #endregion

    #region Mono 
    private void Start()
    {
        GetComponent<SpriteRenderer>().sortingOrder = 2;
      
    }
    

    private void Update()
    {
        ChackIfDragged();
    }
    

    #endregion

    #region Check mouse States Methods

    public void ChackIfDragged()
    {
        if (Input.GetMouseButtonUp(0))
        {
            isDragged = false;
        }
        else if (Input.GetMouseButton(0))
        {
            isDragged = true;
        }

        if (!isDragged && !isBuildingChildOfTile && !isOnTile)
        {
            Destroy(gameObject);
        }
        
        Debug.Log("is dragged: " + isDragged);
    }

    public void GetFollowMouse()
    {
        throw new System.NotImplementedException();
    }

    #endregion
    
    #region Check Collision triggers methods - to build on tile

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if(!isBuildingChildOfTile)
            isOnTile = true;
        
        CheckCollisionsOnTile(other);
    }
    //todo building manager
    
    /// <summary>
    /// Switches between types of buildings 
    /// </summary>
    /// <param name="other"></param>
    private void CheckCollisionsOnTile(Collider2D other)
    {
        
        switch (_typeOfDraggableItem)
        {
            
            case TypeOfDraggableItem.Building:  
                 CheckTileVacancy(other);
                 break;
            
            case TypeOfDraggableItem.Research:
                if (other.gameObject.CompareTag("Tile"))
                {
                    if (gameObject.CompareTag("Building"))
                    {
                        PlaceBuildingOnTile();
                        goto ThisIsBuilding;
                    }
                    
                    if(!other.GetComponent<Tiles>().isCursed && !isDragged)
                    {
                        Destroy(gameObject);
                    }
                    
                }
                ThisIsBuilding:
                break;
            
            case TypeOfDraggableItem.Secrifice:
                if (other.gameObject.CompareTag("Secrifice"))
                { 
                    if (!isDragged)
                    {
                        DecreaseReasourceCost();
                        GetMonsterEat(other);
                        Destroy(gameObject);
                    }    
                }
                
                if (!isDragged)
                {
                    
                    Destroy(gameObject);
                }

                break;
        }
    }

    private void GetMonsterEat(Collider2D other)
    {
        other.GetComponent<MosterObjectScript>()
            .Eat(reasourcePrice.secrificeAmountHunger, reasourcePrice.secrificeAddPower);
    }

    private void CheckTileVacancy(Collider2D other)
    {
        if (other.gameObject.CompareTag("Building"))
        {
            if (!isBuildingChildOfTile && !isDragged)
                Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Tile"))
        {
            if (other.GetComponent<Tiles>().isCursed && !isDragged)
                Destroy(gameObject);
        }
    }

    #endregion

    #region Build
    /// <summary>
    /// Called from buildManager
    /// </summary>
    public void PlaceBuildingOnTile()
    {
        if (!isDragged && isOnTile && !isBuildingChildOfTile)
        {
            if (tile != null)
            {
                var tileScript = tile.GetComponent<Tiles>();
                if (!tileScript.isCursed)
                {
                   
                    DecreaseReasourceCost();
                    CheckIfGetsResourceBonus(tileScript);
                    SetTileParent(tile);
                    SnapToTile();
                    StopFollowingMouse();
                    BuildEventChannelSo.RaiseEvent();
                    tileScript.hasBuilding = true;
                    GetComponent<PolygonCollider2D>().isTrigger = true;
                    
                }
                
                
            }
            
          
        
        }
    }


    private void CheckIfGetsResourceBonus(Tiles tile)
    {
        if (tile.type._resourceType == _resourceTypeData._resourceType)
        {
            tile.amountOfReasourceProdused += _resourceTypeData.bonus;
            tile.hasBonus = true;
        }
    }

    private void StopFollowingMouse()
    {
        GetComponent<FollowMouse>().enabled = false;
    }

    private void SetTileParent(GameObject tile)
    {
        isBuildingChildOfTile = true;
        transform.parent = tile.transform;
    }

    private void SnapToTile()
    {
        transform.localPosition = new Vector3(0, 0, 0);
       
    }
    /// <summary>
    /// Takes the building price SO and passes it to resource manager SO
    /// </summary>
    public void DecreaseReasourceCost()
    {
        _resourceDataSO.SpendReasource(reasourcePrice);
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isOnTile = false;
    }
    

    #endregion

    private void OnDestroy()
    {
        Debug.Log("Building destroyed");
        FindObjectOfType<BuildingManager>().DetachBuildingFromManager(this);
    }
}


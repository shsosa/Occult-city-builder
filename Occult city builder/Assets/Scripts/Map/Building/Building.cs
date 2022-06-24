using System;
using DefaultNamespace;using Game_managment;
using InputMouse;
using UnityEngine;


public class Building : MonoBehaviour, Idraggable
{
    
  public enum TypeOfDraggableItem
   {
       Building , Secrifice, Ritual
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

    /// <summary>
    /// Switches between types of buildings 
    /// </summary>
    /// <param name="other"></param>
    private void CheckCollisionsOnTile(Collider2D other)
    {
        
        switch (_typeOfDraggableItem)
        {
            
            case TypeOfDraggableItem.Building:
                if (other.gameObject.CompareTag("Building"))
                {
                    if(!isBuildingChildOfTile && !isDragged)
                        Destroy(gameObject);
                }

                if (other.gameObject.CompareTag("Tile"))
                {
                    if(other.GetComponent<Tiles>().isCursed && !isDragged)
                        Destroy(gameObject);
                }
                break;

            case TypeOfDraggableItem.Secrifice:
                if (other.gameObject.CompareTag("Secrifice"))
                {
                    if (!isDragged)
                    {
                        DecreaseReasourceCost();
                        
                        other.GetComponent<MosterObjectScript>().Eat(reasourcePrice.secrificeAmountHunger, reasourcePrice.secrificeAddPower);
                        Destroy(gameObject);
                    }
                    
                }

                break;
            case TypeOfDraggableItem.Ritual:

                if (other.gameObject.CompareTag("Ritual"))
                {
                    if (!isDragged)
                    {
                        
                    }

                }

                if (!isDragged)

                
                if (!isDragged)
                {
                    

                    Destroy(gameObject);
                }

                break;
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
                if (!tile.GetComponent<Tiles>().isCursed)
                {
                   
                    DecreaseReasourceCost();
                    CheckIfGetsResourceBonus(tile.GetComponent<Tiles>());
                    SetTileParent(tile);
                    SnapToTile();
                    StopFollowingMouse();
                    BuildEventChannelSo.RaiseEvent();
                    tile.GetComponent<Tiles>().hasBuilding = true;
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
    private void DecreaseReasourceCost()
    {
        _resourceDataSO.SpendReasource(reasourcePrice);
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isOnTile = false;
    }
    

    #endregion
   

   
    
    

}


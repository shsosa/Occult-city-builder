using System.Security.Cryptography;
using DefaultNamespace;using Game_managment;
using InputMouse;
using UnityEngine;


public class Building : MonoBehaviour, Idraggable
{
   //todo maybe move resource update from building manager - still with event to update resource manager 
   //todo use raycast instead of collision

  public enum TypeOfDraggableItem
   {
       Building , Secrifice
   }

   public TypeOfDraggableItem _typeOfDraggableItem;

    #region SerializedData

    public ResourceTypeData _resourceTypeData;
    [SerializeField] private ReasourcePrice reasourcePrice;
    [SerializeField] private ResourceData _resourceDataSO;

    #endregion
    
    #region Building Bool States

    public bool isDragged;
    private bool isOnTile = false;
    private bool isBuildingChildOfTile = false;

    #endregion

    #region Mono 
    private void Start()
    {
        GetComponent<SpriteRenderer>().sortingOrder = 1;
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

    /// <summary>
    /// If we want the building can only be on a certain kind of tile with the same resource type
    /// </summary>
    /// <param name="resourceTypeData"></param>
    /// <returns></returns>
    bool CheckIfTileHasSameResourceType(ResourceTypeData resourceTypeData)
    {
        return _resourceTypeData == resourceTypeData;
    }
    
    #endregion
    
    #region Check Collision triggers methods - to build on tile

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("building hit with tile");
        if(!isBuildingChildOfTile)
            isOnTile = true;
        
        BuildOnTile(other);
    }

    private void BuildOnTile(Collider2D other)
    {
        
        switch (_typeOfDraggableItem)
        {
            
            case TypeOfDraggableItem.Building:
                
                if (other.gameObject.CompareTag("Tile"))
                {
                    if (!isDragged && isOnTile && !isBuildingChildOfTile)
                    {
                        var tile = GetTileComponent(other);
                        if (!tile.isCursed)
                        {
                            DecreaseReasourceCost();
                            CheckIfGetsResourceBonus(tile);
                            SetTileParent(other);
                            SnapToTile();
                            StopFollowingMouse();
                        }
                    }
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
                
                if(!isDragged)
                    Destroy(gameObject);
              
                
                break;
        }
    }

    private static Tiles GetTileComponent(Collider2D other)
    {
        Tiles tile;
        tile = other.GetComponent<Tiles>();
        tile.hasBuilding = true;
        return tile;
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

    private void SetTileParent(Collider2D other)
    {
        isBuildingChildOfTile = true;
        transform.parent = other.transform;
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
    
    
//todo do we ude this or can delet?
    public void Destruction()
    {
        Destroy(gameObject);
    }
    
    
   

}


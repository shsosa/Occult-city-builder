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
    public ResourceData _resourceDataSO;
    public VoidEventChannelSO BuildEventChannelSo;
    public GameObject tile;
    private SpriteRenderer _spriteRenderer;

    #endregion
    
    #region Building Bool States

    public bool isDragged;
    private bool isOnTile = false;
    public bool isBuildingChildOfTile = false;

    #endregion

    #region Mono 
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sortingOrder = 2;
      
    }
    

    private void Update()
    {
        ChackIfDragged();
        ChangeSortingOrder();
    }

    private void ChangeSortingOrder()
    {
        if (GameManager.isEventUIActive)
            _spriteRenderer.sortingOrder = 0;
        else
        {
            _spriteRenderer.sortingOrder = 2;
        }
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
                CheckTileVacancy(other);
                break;
            
            case TypeOfDraggableItem.Secrifice:
                if (other.gameObject.CompareTag("Monster"))
                { 
                    if (!isDragged)
                    {
                        DecreaseReasourceCost();
                        GetMonsterEat(other);
                        Destroy(gameObject);
                    }    
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
        if (other.gameObject.CompareTag("Tile"))
        {
            if (other.GetComponent<Tiles>().isCursed && !isDragged && !isBuildingChildOfTile) 
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
                    tileScript.hasBuilding = true;
                    SetTileParent(tile);
                    DecreaseReasourceCost();
                    tileScript.hasBonus =
                        CheckIfGetsResourceBonus(tileScript, this);
                    SnapToTile();
                    StopFollowingMouse();
                    BuildEventChannelSo.RaiseEvent();
                    GetComponent<PolygonCollider2D>().isTrigger = true;
                    if (tileScript.isHoly && _typeOfDraggableItem == TypeOfDraggableItem.Research)
                        tileScript.hasBonus = true;
                    
                }
                
            }
            
        }
    }


    public bool CheckIfGetsResourceBonus(Tiles tile,Building building)
    {
        return tile.type._resourceType == building._resourceTypeData._resourceType;
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
        FindObjectOfType<BuildingManager>()?.DetachBuildingFromManager(this);
    }
}


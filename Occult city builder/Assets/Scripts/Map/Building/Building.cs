using System;
using InputMouse;
using UnityEngine;


public class Building : MonoBehaviour
{
    /*
* snap to tile center or other
*/
    public ResourceTypeData _resourceTypeData;

    #region Building bool states

    private bool isDragged;
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

    #region CheckStatesMethods
    private void ChackIfDragged()
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
    
    #region Collision triggers

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("building hit with tile");
        if(!isBuildingChildOfTile)
            isOnTile = true;
        
        if (other.gameObject.CompareTag("Tile") )
        {

           
            if (!isDragged && isOnTile && !isBuildingChildOfTile)
            {
                other.GetComponent<Tiles>().hasBuilding = true;
                isBuildingChildOfTile =true;
                transform.parent = other.transform;
                transform.localPosition = new Vector3(0, 0, 0);
                GetComponent<FollowMouse>().enabled = false;
               
            }
            
          

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isOnTile = false;
    }

    #endregion
   

    
    // collision for UIManager - visual feedback
   

}


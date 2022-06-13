using System;
using InputMouse;
using UnityEngine;

//namespace Map.Building
//{
public class Building : MonoBehaviour
{
    /*
* snap to tile center or other
*/
    public ResourceTypeData _resourceTypeData;
    private void Start()
    {
        gameObject.AddComponent<PolygonCollider2D>();
        GetComponent<SpriteRenderer>().sortingOrder = 1;
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("building hit with tile");
        
        if (!Input.GetMouseButtonDown(0) && col.gameObject.CompareTag("Tile"))
        {
            transform.parent = col.transform;
            transform.localPosition = new Vector3(0, 0, 0);
            GetComponent<FollowMouse>().enabled = false;
            col.GetComponent<Tiles>().hasBuilding = true;
           
        }
    }

    // collision for UIManager - visual feedback
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("buliding colide");
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        throw new NotImplementedException();
    }
    private void BuildingCreation()
    {

    }

}
//}

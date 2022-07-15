using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InputMouse;

public class EventIcon : MonoBehaviour
{
    private Vector3 originalPosition;
    private FollowMouse mouse;
    private RandomEventUI rEvent;
   

    private bool isSecreficed,isNotSecrificed;
    
    private void Start()
    {
        rEvent = GetComponentInParent<RandomEventUI>();
        originalPosition = transform.position;
        mouse = GetComponent<FollowMouse>();
        mouse.enabled = false;
    }

    private void OnMouseDown()
    {
        mouse.enabled = true;
    }
    private void OnMouseUp()
    { 
        if(isSecreficed)
        {
            rEvent.IfAceptedToSecrifice();
          
           // Debug.LogError("Ohhh yeah!!!!!");
            isSecreficed = false;
        }
        else if(isNotSecrificed)
        {
            rEvent.IfRejectedToSecrefice();
            Debug.Log("Ohhh yeah!!!!!");
        }
        mouse.enabled = false;
        transform.position = originalPosition; 
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        Debug.Log("Im here");
        if (other.gameObject.CompareTag("EventSecrefice"))
        {    
            isSecreficed = true;
        }
        if(other.gameObject.CompareTag("EventNotSecrefice"))
        {
            isNotSecrificed = true;
            Debug.Log("Im now here");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isSecreficed = false;
        isNotSecrificed = false;
    }
}

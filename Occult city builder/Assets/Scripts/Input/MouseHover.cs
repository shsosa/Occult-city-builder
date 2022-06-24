using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InputMouse
{
    public class MouseHover : MonoBehaviour
    {
    
        public static GameObject GetUIObject(string tagName)
        {
            Debug.Log("Mouse hover called");
            var eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;
            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);
            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].gameObject.CompareTag(tagName))
                {
                    
                    return results[i].gameObject;
                }
            
            
            }
       
            return null;
       
        
        
        }


    
      
    }
}

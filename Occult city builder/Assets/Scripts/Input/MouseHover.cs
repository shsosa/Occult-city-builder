using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InputMouse
{
    public class MouseHover : MonoBehaviour
    {
    
        public UIObject GetUIObject()
        {
            var eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;
            var results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);
            for (int i = 0; i < results.Count; i++)
            {
                if (results[i].gameObject.CompareTag("Tile"))
                {
               
                    return results[i].gameObject.GetComponent<UIObject>();
                }
            
            
            }
       
            return null;
       
        
        
        }
    

    
      
    }
}

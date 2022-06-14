using UnityEngine;

namespace InputMouse
{
    public class MouseHover : MonoBehaviour
    {
    
        private void OnMouseOver()
        {
            ProductionMono production = GetComponent<ProductionMono>();
        
          //  Debug.Log("mouse hover " +production. _resourceType +" "+ production.howMuchCanProduce + " " + gameObject.name);
        }
    

    
      
    }
}

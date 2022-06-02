using UnityEngine;

namespace InputMouse
{
    public class FollowMouse : MonoBehaviour
    {
        private Vector3 mousePos;
   
        void Update()
        {
            mousePos = UnityEngine.Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }
}

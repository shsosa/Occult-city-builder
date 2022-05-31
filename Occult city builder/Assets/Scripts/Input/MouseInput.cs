using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    /*
     * mouse input
     * mouse hover
     * connected to UI
     */

    private Vector3 mousePos;
    
    // Start is called before the first frame update
    void Start()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Debug.Log("mouse pos: " + mousePos);
    }
}

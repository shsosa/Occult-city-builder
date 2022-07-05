using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

[ExecuteInEditMode()]
public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI headerFiled;
    public TextMeshProUGUI contentField;

    public LayoutElement layoutElement;

    public int charecterWrapLimit;

    public RectTransform RectTransform;
    private Vector2 position;

    private Color _color;

    [SerializeField] bool isOnMouseUI;
    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
      
    }

    
    void  Update()
    {
            if(isOnMouseUI)
                position = Input.mousePosition;
        

            float pivotX = position.x / Screen.width;
            float pivotY = position.y / Screen.height;

            RectTransform.pivot = new Vector2(pivotX, pivotY);
        
            
        
      
       
       

    }

    public void SetText(string content, string header = "")
    {
        if (string.IsNullOrEmpty(header))
        {
            headerFiled.gameObject.SetActive(false);
        }
        else
        {
            Vector2 position = Input.mousePosition;
             position = Camera.main.ScreenToWorldPoint(position);
            RectTransform.position = new Vector3(position.x, position.y, 0);
            
            headerFiled.gameObject.SetActive(true);
            headerFiled.text = header;
        }

        contentField.text = content;
        
        int headerLength = headerFiled.text.Length;
        int contentLenght = contentField.text.Length;

        layoutElement.enabled = headerLength > charecterWrapLimit || contentLenght > charecterWrapLimit;
    }


    
}

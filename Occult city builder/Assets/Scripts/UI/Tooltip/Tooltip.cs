using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI.Tooltip;
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

    public void SetText(TooltipTextSO tooltipTextSo)
    {
        if (!tooltipTextSo)
        {
            headerFiled.gameObject.SetActive(false);
        }
        else
        {
            if (isOnMouseUI)
            {
                Vector2 position = Input.mousePosition;
                position = Camera.main.ScreenToWorldPoint(position);
                RectTransform.position = new Vector3(position.x, position.y, 0);
            }
           
            
            headerFiled.gameObject.SetActive(true);
            headerFiled.text = tooltipTextSo.header;
            headerFiled.color = tooltipTextSo.headerColor;
            headerFiled.fontSize = tooltipTextSo.headerFontSize;

        }

        contentField.text = tooltipTextSo.Content;
        contentField.color = tooltipTextSo.contentColor;
        contentField.fontSize = tooltipTextSo.contentFontSize;
        
        int headerLength = headerFiled.text.Length;
        int contentLenght = contentField.text.Length;

        layoutElement.enabled = headerLength > charecterWrapLimit || contentLenght > charecterWrapLimit;
    }


    
}

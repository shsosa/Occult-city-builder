using System;
using System.Collections;
using System.Collections.Generic;
using Game_managment;
using UI.Tooltip;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string header;
    
    [TextArea]
    [SerializeField] string content="";

    [SerializeField] private Sprite iconSprite;
    [SerializeField] private ReasourcePrice _reasourcePrice;
    [SerializeField] private TooltipTextSO _tooltipTextSo;
   

    
  

    public void OnPointerEnter(PointerEventData eventData)
    {
       
        StartCoroutine(Delay());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       TooltipSystem.Hide(_tooltipTextSo);
    }

    IEnumerator Delay()
    {
        _tooltipTextSo.iconSprite = null;   
        _tooltipTextSo.header = header + "\n";
        _tooltipTextSo.Content = _reasourcePrice.GetBuildingPrice() + "\n" + content;
        _tooltipTextSo.iconSprite = iconSprite;
        yield return new WaitForSeconds(0.1f);
        TooltipSystem.Show(_tooltipTextSo);
    }

   
}

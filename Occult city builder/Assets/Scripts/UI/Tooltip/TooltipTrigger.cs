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
    [SerializeField] private ReasourcePrice _reasourcePrice;
    [SerializeField] private TooltipTextSO _tooltipTextSo;
   

    
  

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(Delay());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       TooltipSystem.Hide();
    }

    IEnumerator Delay()
    {
        _tooltipTextSo.Content = _reasourcePrice.GetBuildingPrice();
        yield return new WaitForSeconds(0.3f);
        TooltipSystem.Show(_tooltipTextSo);
    }

   
}

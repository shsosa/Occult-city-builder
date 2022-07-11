using System;
using System.Collections;
using System.Collections.Generic;
using UI.Tooltip;
using UnityEngine;
using UnityEngine.UIElements;

public class TooltipSystem : MonoBehaviour
{
   private static TooltipSystem current;

   public Tooltip Tooltip;
   

   public void Awake()
   {
      current = this;
     
   }

   public static void Show(TooltipTextSO tooltipTextSo)
   {
      current.Tooltip.SetText(tooltipTextSo);
      current.Tooltip.gameObject.SetActive(true);
   }
   

   public static void Hide(TooltipTextSO tooltipTextSo)
   {
      tooltipTextSo.iconSprite = null;
      current.Tooltip.ResetTooltip();
      current.Tooltip.gameObject.SetActive(false);
   }
   
   
}

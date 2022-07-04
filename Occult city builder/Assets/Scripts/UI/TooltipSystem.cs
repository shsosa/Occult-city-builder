using System;
using System.Collections;
using System.Collections.Generic;
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

   public static void Show(string content, string header = "")
   {
      current.Tooltip.SetText(content,header);
      current.Tooltip.gameObject.SetActive(true);
   }

   public static void Hide()
   {
      current.Tooltip.gameObject.SetActive(false);
   }
   
   
}

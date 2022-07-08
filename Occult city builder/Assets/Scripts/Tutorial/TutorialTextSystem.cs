using System;
using System.Collections;
using System.Collections.Generic;
using UI.Tooltip;
using UnityEngine;

public class TutorialTextSystem : MonoBehaviour
{
    public static TutorialTextSystem current;

    private void Awake()
    {
        current = this;
    }

    public Tooltip TutorialBubble;
    public static  void Show(TooltipTextSO tooltipTextSo)
    {
        current.TutorialBubble.SetText(tooltipTextSo);
       current.TutorialBubble.gameObject.SetActive(true);
    }

    public  void Hide()
    {
      TutorialBubble.gameObject.SetActive(false);
    }
}

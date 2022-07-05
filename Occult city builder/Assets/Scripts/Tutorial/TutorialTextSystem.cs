using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTextSystem : MonoBehaviour
{
    public static TutorialTextSystem current;

    private void Awake()
    {
        current = this;
    }

    public Tooltip TutorialBubble;
    public static  void Show(string content, string header = "")
    {
        current.TutorialBubble.SetText(content,header);
       current.TutorialBubble.gameObject.SetActive(true);
    }

    public  void Hide()
    {
      TutorialBubble.gameObject.SetActive(false);
    }
}

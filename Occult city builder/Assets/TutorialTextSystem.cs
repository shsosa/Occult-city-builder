using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTextSystem : MonoBehaviour
{

    public TutorialBubble TutorialBubble;
    public  void Show(string content, string header = "")
    {
        TutorialBubble.SetText(content,header);
       TutorialBubble.gameObject.SetActive(true);
    }

    public  void Hide()
    {
      TutorialBubble.gameObject.SetActive(false);
    }
}

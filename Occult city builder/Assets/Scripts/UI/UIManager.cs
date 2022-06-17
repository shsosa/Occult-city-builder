using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    public ResourceData ResourceManager;

    [SerializeField] private TextMeshProUGUI goldTextUI;
    [SerializeField] private TextMeshProUGUI woodTextUI;
    [SerializeField] private TextMeshProUGUI villigersTextUI;
    [SerializeField] private TextMeshProUGUI cattleTextUI;
    [SerializeField] private TextMeshProUGUI researchTextUI;
    
  

    // Update is called once per frame
    void Update()
    {
        goldTextUI.text = ResourceManager.gold.ToString();
        woodTextUI.text = ResourceManager.wood.ToString();
        cattleTextUI.text = ResourceManager.cattle.ToString();
        researchTextUI.text = ResourceManager.researchPoints.ToString();
        villigersTextUI.text = ResourceManager.vilagers.ToString();
    }
    
    
}

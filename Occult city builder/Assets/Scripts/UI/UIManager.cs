using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    /*
     * every thing ui pulls from game manager
     * - timer
     * - resources
     * - buildings UI
     * - tile info
     */
    // Start is called before the first frame update
    public ResourceData ResourceManager;
    [SerializeField] private TextMeshProUGUI goldTextUI;
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        goldTextUI.text = ResourceManager.gold.ToString();
    }
}

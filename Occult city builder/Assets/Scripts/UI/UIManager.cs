using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class UIManager : MonoBehaviour
{

    #region Serialised Managers

    public BuildingManager buildingManager;
    
    [SerializeField] ResourceData _resourceData;

    #endregion
    
    [Header("Array of UI Intractable")]
    [SerializeField] private UIObject[] uiObjects;
    
    #region Serialized textGUI
    [SerializeField] private TextMeshProUGUI goldTextUI;
    [SerializeField] private TextMeshProUGUI woodTextUI;
    [SerializeField] private TextMeshProUGUI villigersTextUI;
    [SerializeField] private TextMeshProUGUI cattleTextUI;
    [SerializeField] private TextMeshProUGUI researchTextUI;
    #endregion

    #region Mono
    void Update()
    {
        UpdateUIText();
        CheckIfCanBuildUI();
    }
    private void Awake()
    {
       
        uiObjects = GetComponentsInChildren<UIObject>();
        
    }
    #endregion
    
    
    void CheckIfCanBuildUI()
    {
        foreach (var uiObject in uiObjects)
        {
            
            Debug.Log("Current uiObject checking to build: "+ uiObject.name);
            uiObject.canBuild = buildingManager.CheckIfCanBuild(uiObject);
        }
    }

    private void UpdateUIText()
    {
        goldTextUI.text = _resourceData.gold.ToString();
        woodTextUI.text = _resourceData.wood.ToString();
        cattleTextUI.text = _resourceData.cattle.ToString();
        researchTextUI.text = _resourceData.researchPoints.ToString();
        villigersTextUI.text = _resourceData.vilagers.ToString();
    }
}

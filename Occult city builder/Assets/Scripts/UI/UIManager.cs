using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    #region Serialised Managers

    public BuildingManager buildingManager;
    
    [SerializeField] ResourceData _resourceData;
    private UIObjectInfo _uiObjectInfo;
    [Header("Array of UI Intractable")]
    [SerializeField] private UIObject[] uiObjects;

    #endregion

    #region Serialized textGUI
    [SerializeField] private TextMeshProUGUI goldTextUI;
    [SerializeField] private TextMeshProUGUI woodTextUI;
    [SerializeField] private TextMeshProUGUI villigersTextUI;
    [SerializeField] private TextMeshProUGUI cattleTextUI;
    [SerializeField] private TextMeshProUGUI researchTextUI;
    //[SerializeField] private TextMeshProUGUI toolTipTextUI;
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
        _uiObjectInfo = GetComponent<UIObjectInfo>();
    }
    #endregion

    #region Update UI objects 
    void CheckIfCanBuildUI()
    {
        foreach (var uiObject in uiObjects)
        {
            
            Debug.Log("Current uiObject checking to build: "+ uiObject.name);
            
            uiObject.canBuild = buildingManager.CheckIfCanBuild(uiObject);
            ChangeUIObjectColor(uiObject);
        }
    }

    private static void ChangeUIObjectColor(UIObject uiObject)
    {
        if (uiObject.canBuild)
        {
            uiObject.gameObject.GetComponent<Image>().color = Color.Lerp(Color.gray,Color.white,3f);
        }
        else
        {
            uiObject.gameObject.GetComponent<Image>().color = Color.gray;
        }
    }

    private void UpdateUIText()
    {
        Mathf.Clamp(_resourceData.gold, 0, 100);
        Mathf.Clamp(_resourceData.wood, 0, 100);
        Mathf.Clamp(_resourceData.cattle, 0, 100);
        Mathf.Clamp(_resourceData.researchPoints, 0, 100);
        Mathf.Clamp(_resourceData.vilagers, 0, 100);
        goldTextUI.text = _resourceData.gold.ToString();
        woodTextUI.text = _resourceData.wood.ToString();
        cattleTextUI.text = _resourceData.cattle.ToString();
        researchTextUI.text = _resourceData.researchPoints.ToString();
        villigersTextUI.text = _resourceData.vilagers.ToString();
       // toolTipTextUI.text = _uiObjectInfo.GetBuildingPrice();
    }
    
    #endregion
   
}

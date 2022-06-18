using System;
using System.Collections;
using System.Collections.Generic;
using Game_managment;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    #region Managers

    public BuildingManager BuildingManager;
    [SerializeField] private UIObject[] _uiObjects;
    [SerializeField] ResourceData _resourceData;

    #endregion
    
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
       
        _uiObjects = GetComponentsInChildren<UIObject>();
        
    }
    #endregion
    
    
    void CheckIfCanBuildUI()
    {
        foreach (var uiObject in _uiObjects)
        {
            Debug.Log("Current uiObject "+ uiObject.name);
            uiObject.canBuild = BuildingManager.CheckIfCanBuild(uiObject);
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

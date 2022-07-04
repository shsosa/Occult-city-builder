using System;
using Game_managment;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIObject : MonoBehaviour
{
   //todo check if building manager can instantiate

   #region Variables

   [SerializeField] private GameObject buildingToCreate;
   private BuildingManager _buildingManager;
    
   //Price to build
   public ReasourcePrice _reasourcePrice;
    
   //Instantiate building as child of map - on canvas 
   private Transform map;
    
   //Original object scale
   private Vector3 scaleOG;
    
   public bool canBuild =false;
   private bool eventHappaning = false;

   #endregion

   #region Mono

   private void Awake()
   {
       _buildingManager = FindObjectOfType<BuildingManager>();
       scaleOG = transform.localScale;
        
       map = FindObjectOfType<BuildingManager>().transform;
   }

   
   #endregion
   
   #region Tranform Scale

    public void ChangeScale()
    {
        if(canBuild)
            transform.localScale = new Vector3(2f, 2f, 2f);
    }
    
    public void RevertScaleToOG()
    {
        if(canBuild)
            transform.localScale = scaleOG;
    }

    #endregion
    
    #region Build

    public void CreateBuldingFromUI()
    {
        if(!eventHappaning && canBuild && buildingToCreate!= null)
        {
            _buildingManager.InstantiateBuilding(buildingToCreate,transform);
        }
    }

    #endregion
    
   
     
}

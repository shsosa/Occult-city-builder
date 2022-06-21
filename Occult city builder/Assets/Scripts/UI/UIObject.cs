using System;
using Game_managment;
using Unity.Mathematics;
using UnityEngine;

public class UIObject : MonoBehaviour
{
   //todo check if building manager can instantiate
    [SerializeField] private GameObject buildingToCreate;
    public ReasourcePrice _reasourcePrice;
    private Transform map;
    public bool canBuild =false;

    private void Awake()
    {
        map = FindObjectOfType<BuildingManager>().transform;
    }

    public void CreateBuldingFromUI()
    {
        if(canBuild)
        {
            //todo instantiate from another place
            GameObject building;
            building = Instantiate(buildingToCreate, transform.position, quaternion.identity);
            building.transform.SetParent(map);
        }
    }

   
}

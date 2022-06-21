using Game_managment;
using Unity.Mathematics;
using UnityEngine;

public class UIObject : MonoBehaviour
{
   //todo check if building manager can instantiate
    [SerializeField] private GameObject buildingToCreate;
    public ReasourcePrice _reasourcePrice;
    public bool canBuild =false;
    
    

    public void CreateBuldingFromUI()
    {
        if(canBuild)
            Instantiate(buildingToCreate, transform.position, quaternion.identity);
    }

   
}

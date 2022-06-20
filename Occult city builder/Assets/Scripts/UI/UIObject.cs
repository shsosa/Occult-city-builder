using Unity.Mathematics;
using UnityEngine;

public class UIObject : MonoBehaviour
{
   //todo check if building manager can instantiate
    [SerializeField] private GameObject buildingToCreate;
    public bool canBuild =false;
    
    

    public void CreateBuldingFromUI()
    {
        if(canBuild)
            Instantiate(buildingToCreate, transform.position, quaternion.identity);
    }

   
}

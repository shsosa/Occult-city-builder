using Unity.Mathematics;
using UnityEngine;

public class UIObject : MonoBehaviour
{
   
    [SerializeField] private GameObject buildingToCreate;
    public bool canBuild =false;
    
    

    public void CreateBuldingFromUI()
    {
        if(canBuild)
            Instantiate(buildingToCreate, transform.position, quaternion.identity);
    }

   
}

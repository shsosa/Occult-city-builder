using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tile : MonoBehaviour
{
    
    /*
     * visual feedback when mouse hovers with building
     * info on tile when mouse hovers
     */
    public TileScriptable TileScriptable;
    void Start()
    {
        Debug.Log(TileScriptable._resourceType);
    }

   
}

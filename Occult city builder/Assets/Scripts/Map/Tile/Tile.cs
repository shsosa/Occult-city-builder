using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileScriptable TileScriptable;
    void Start()
    {
        Debug.Log(TileScriptable._resourceType);
    }

   
}

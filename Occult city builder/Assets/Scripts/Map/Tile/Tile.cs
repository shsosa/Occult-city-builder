using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tile : ProductionMono
{
    
    /*
     * visual feedback when mouse hovers with building
     * info on tile when mouse hovers
     */
    [SerializeField] bool hasBonus = false;
    [SerializeField] bool hasBulding = false;

    private void OnCollisionEnter2D(Collision2D col)
    {
        hasBulding = true;
    }

    private void OnCollisionExit(Collision other)
    {
        hasBulding = false;
    }
}

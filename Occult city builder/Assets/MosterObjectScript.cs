using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Events;

public class MosterObjectScript : MonoBehaviour 
{
    public UnityEvent _unityEvent;
    [SerializeField] private SecreficeManager _secreficeManager;
   
   

    public void SacrificeToMonster()
    {
        Debug.Log("Monster eat event");
        _unityEvent.Invoke();
    }
    public void Eat(int amountToSecrificeHunger, int secrificeAddPower)
    {
        _secreficeManager.Sacrifice(amountToSecrificeHunger, secrificeAddPower);
    }

   
}

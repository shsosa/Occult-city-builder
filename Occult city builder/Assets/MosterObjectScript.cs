using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Monster;
using Game_managment;
using UnityEngine;
using UnityEngine.Events;

public class MosterObjectScript : MonoBehaviour 
{
    public UnityEvent _unityEvent;
    [SerializeField] private SecreficeManager _secreficeManager;
    [SerializeField] private MonsterManager _monsterManager;



    static public bool  isMonsterPowerDecrease =false;

    public void SacrificeToMonster()
    {
        Debug.Log("Monster eat event");
        
    }

    

    public void Eat(ReasourcePrice reasourcePrice)
    {
        
        _unityEvent.Invoke();
        _secreficeManager.Sacrifice(reasourcePrice.secrificeAmountHunger, reasourcePrice.secrificeAddPower,reasourcePrice.researchPointsAdd);
    }

   
}

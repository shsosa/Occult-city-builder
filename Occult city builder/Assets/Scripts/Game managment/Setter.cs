using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setter : MonoBehaviour
{

    

     public Farm farm;
    public House house;
    public Mine mine;
    public Querry query;
    public WitchHut witchHut;
   
    

    [Header("Spells: ")]
    [SerializeField] public ScriptableObject banishing;
    [SerializeField] public ScriptableObject clansing;
    [SerializeField] public ScriptableObject lightning;

    [Header("Managers: ")]

    [SerializeField] public GameObject randomEventManager;
    [SerializeField] public GameObject monsterManager;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [System.Serializable]
    public class Farm
    {
        public ScriptableObject so;
        public int priceInGold;
        public int priceInWood;
        public int priceInCattle;
        public int priceInVillagers;
        public int priceInReserchPoints;
    }
    [System.Serializable]
    public class House
    {
        public ScriptableObject so;
        public int priceInGold;
        public int priceInWood;
        public int priceInCattle;
        public int priceInVillagers;
        public int priceInReserchPoints;
    }
    [System.Serializable]
    public class Mine
    {
        public ScriptableObject so;
        public int priceInGold;
        public int priceInWood;
        public int priceInCattle;
        public int priceInVillagers;
        public int priceInReserchPoints;
    }
    [System.Serializable]
    public class Querry
    {
        public ScriptableObject so;
        public int priceInGold;
        public int priceInWood;
        public int priceInCattle;
        public int priceInVillagers;
        public int priceInReserchPoints;
    }
    [System.Serializable]
    public class WitchHut
    {
        public ScriptableObject so;
        public int priceInGold;
        public int priceInWood;
        public int priceInCattle;
        public int priceInVillagers;
        public int priceInReserchPoints;
    }

}

using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIBarSlider : MonoBehaviour
    {
        private Slider _slider;
        [SerializeField] private MonsterManager _monsterManager;

        private float monsterHungerSlider;
        

        private void Awake()
        {
            _slider = GetComponent<Slider>();

        }

        private void Update()
        {
            
            _slider.value = _monsterManager.monsterHunger;
        }
    }
}
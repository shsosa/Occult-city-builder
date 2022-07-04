using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIBarSlider : MonoBehaviour
    {
        private Slider _slider;
        [SerializeField] private MonsterManager _monsterManager;
        public enum BarType { hunger, power}
        public BarType _barType;

        private float monsterHungerSlider;
        

        private void Awake()
        {
            _slider = GetComponent<Slider>();

        }

        private void Update()
        {
            BarTypeSwitcher();
        }
        private void BarTypeSwitcher()
        {
            if (_barType==BarType.hunger)
            {
                _slider.value = _monsterManager.monsterHunger/10;
            }
            else if (_barType==BarType.power)
            {
                Debug.Log("i am monster power");
                _slider.value = _monsterManager.monsterPower/10;
            }
        }

    }
}
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIBarScript : MonoBehaviour
    {
        
        [SerializeField] MonsterManager monsterManager;
        
        
         Image fillbar;
        [SerializeField] float InputFloatFromScript;
        private float previousBarState;
        [SerializeField] float currentBarState;
        
        [SerializeField] float maxBarState;

        [SerializeField] private bool ShouldLerp;
        [SerializeField] private float lerpSpeed;
        [SerializeField] float fillAmountImage;

        private float t = 0;

        private void Awake()
        {
            fillbar = GetComponent<Image>();
            currentBarState = previousBarState = maxBarState;
            InputFloatFromScript = monsterManager.monsterHunger;
        }

        private void Update()
        {
            UpdateBar();
        }

        void UpdateBar()
        {
            InputFloatFromScript = monsterManager.monsterHunger;
            previousBarState = currentBarState;
           // currentBarState -= InputFloatFromScript;
            currentBarState = Mathf.Clamp(currentBarState, 0, maxBarState);
            LerpBarState();

        }

        void LerpBarState()
        {
            t += lerpSpeed * Time.deltaTime;
            
            currentBarState = Mathf.Lerp(previousBarState, InputFloatFromScript,t);

            fillAmountImage = fillbar.fillAmount = currentBarState/maxBarState;
        }
    }
}
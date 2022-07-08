using UnityEngine;

namespace UI.Tooltip
{
    [CreateAssetMenu(fileName = "Tool tip text", menuName = "Tooltip", order = 0)]
    public class TooltipTextSO : ScriptableObject
    {
        
        //todo check if needs id
        
        public int id;
        
        [Header("Text: ")]
        public string header;
        public string Content;

        [Header("Header text parameters")]
        public Color headerColor;
        public float headerFontSize;
        
        [Header("Content text parameters")]
        public Color contentColor;
        public float contentFontSize;
    }
}
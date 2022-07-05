using UnityEngine;

namespace UI.Tooltip
{
    [CreateAssetMenu(fileName = "Tool tip text", menuName = "Tooltip", order = 0)]
    public class TooltipText : ScriptableObject
    {
        public int id;
        public string header;
        public string Content;
    }
}
using System;
using UnityEngine;

namespace DefaultNamespace.Monster
{
    [CreateAssetMenu(fileName = "Monster", menuName = "Emot", order = 0)]
    public class MonsterEmot : ScriptableObject
    {
       public enum Emotion
        {
            CurseTile, FeedMe, Feeding, Happy, board
        }

       public Emotion _emotion;

        public float wiggleSpeed, wiggleMag, tenticleGrowth ,growthMagnitude, reactPulseTime;
    }
}
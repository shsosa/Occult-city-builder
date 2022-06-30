using System.Collections;
using System.Collections.Generic;
using MoreMountains.Feedbacks;
using UnityEngine;

public class EffectType : MonoBehaviour
{
   public enum FeelEffectType
   {
      UIEffect , BuildingEffect, CollectResourcesEffect, TileFeedbackEffect 
   }

   public MMFeedbacks.FeedbackType FeedbackType;
}

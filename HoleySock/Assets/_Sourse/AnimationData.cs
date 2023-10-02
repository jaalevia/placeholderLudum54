using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Animation Data", menuName = "ScriptableObjects/Animation Data", order = 1)]
public class AnimationData : ScriptableObject
{
   public static float TargetFrameTime = 0.0167f;
   public int FramesOfGap;
   public Sprite[] Sprites;
}

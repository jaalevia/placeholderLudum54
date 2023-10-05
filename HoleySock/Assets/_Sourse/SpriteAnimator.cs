using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    public SpriteRenderer mySpriteRenderer;
    public AnimationData BaseAnimation;
    Coroutine _previousAnimation;

    private void Start()
    {
        PlayAnimation(BaseAnimation);
    }
    public void PlayAnimation(AnimationData data)
    {
        if (_previousAnimation != null)
            StopCoroutine(_previousAnimation);
        _previousAnimation = StartCoroutine(PlayAnimationCoroutine(data));

    }
    public IEnumerator PlayAnimationCoroutine(AnimationData data)
    {
        if (data == null)
        {
            data = BaseAnimation;
        }
        int spritesAmount = data.Sprites.Length, i = 0;
        float waitTime = data.FramesOfGap * AnimationData.TargetFrameTime;
        while (i < spritesAmount)
        {
            mySpriteRenderer.sprite = data.Sprites[i++];
            yield return new WaitForSeconds(waitTime);

            if (data.Loop && i >= spritesAmount)
            {
                i = 0;
            }
        }
        yield return null;
    }
}

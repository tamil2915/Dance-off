using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsPlayer : MonoBehaviour
{
    int currentAnimationIndex;

    public Animator animationController;

    float elapsedTime;

    private void Start()
    {
        currentAnimationIndex = Mathf.RoundToInt(elapsedTime);
        PlayAnimation();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if(animationController.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animationController.IsInTransition(0))
        {
            PlayAnimation();
            currentAnimationIndex = Mathf.FloorToInt(elapsedTime);
        }
    }

    void PlayAnimation()
    {
        animationController.Play(currentAnimationIndex.ToString());
    }
}

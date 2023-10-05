using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorDelay : MonoBehaviour
{
    public List<AnimationClip> bossAnimations = new List<AnimationClip>(); // List of animations to choose from in the Inspector
    private Animator bossAnimator;
    private float timeSinceLastAnimationChange = 0f;
    private int currentAnimationIndex = 0;

    void Start()
    {
        bossAnimator = GetComponent<Animator>();
        if (bossAnimations.Count > 0)
        {
            // Initialize the boss animation with the first animation in the list
            bossAnimator.Play(bossAnimations[currentAnimationIndex].name);
        }
    }

    void Update()
    {
        // Check if there are animations to switch between
        if (bossAnimations.Count > 1)
        {
            timeSinceLastAnimationChange += Time.deltaTime;

            // Change animation every 10 seconds
            if (timeSinceLastAnimationChange >= 10f)
            {
                timeSinceLastAnimationChange = 0f;
                currentAnimationIndex = (currentAnimationIndex + 1) % bossAnimations.Count;
                bossAnimator.Play(bossAnimations[currentAnimationIndex].name);
            }
        }
    }
}
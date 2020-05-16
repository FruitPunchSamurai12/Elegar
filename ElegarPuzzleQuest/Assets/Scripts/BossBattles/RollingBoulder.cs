using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBoulder : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    bool roll = false;
    bool done = false;
    Vector2 startPos;
    Vector2 targetPos;
    float xOffset;
    float yOffset;
    float timeInterpolationStarted;
    public float interpolationDuration = 2f;

    void Update()
    {
        if (roll)
        {
            float timeSinceStarted = Time.time - timeInterpolationStarted;
            float percentageComplete = timeSinceStarted / interpolationDuration;
            transform.position = new Vector2(startPos.x + xOffset * Easings.QuadraticEaseOut(percentageComplete), startPos.y + yOffset * Easings.BounceEaseOut(percentageComplete));
            if (percentageComplete >= 1f)
            {
                Stop();
            }
        }
    }

    public void Roll(Vector2 target)
    {
        startPos = transform.position;
        targetPos = target;
        xOffset = targetPos.x - startPos.x;
        yOffset = targetPos.y - startPos.y;
        timeInterpolationStarted = Time.time;
        roll = true;
        animator.SetTrigger("Roll");
    }

    public void Stop()
    {
        animator.SetTrigger("Stop");
        roll = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BaseAIController boss = collision.GetComponent<BaseAIController>();
        boss.SetAnimatorTrigger("Death");
    }


}

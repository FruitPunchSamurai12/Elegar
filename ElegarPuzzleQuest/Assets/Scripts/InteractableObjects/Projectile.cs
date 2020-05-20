using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    protected Collider2D col;

    public bool phase2 = false;
    public float interpolationDuration = 1f;
    public float interpolationDuration2 = 1f;
    public float phase2Distance = 5f;
    public float colliderActivationLimit = 0.9f;

    public Functions xInterpolation1;
    public Functions yInterpolation1;
    public Functions xInterpolation2;
    public Functions yInterpolation2;

    protected bool done = false;
    protected bool phase1Done = false;
    protected bool initialized = false;

    protected float timeInterpolationStarted;
    protected Vector2 startPosition;
    protected Vector2 endPosition;
    protected Vector2 direction;
    protected float xOffset;
    protected float yOffset;

    public int damage = 1;
    public float forcePower = 500f;

    public virtual void Initialize(Vector2 target)
    {
        startPosition = transform.position;
        endPosition = target;
        direction = (endPosition - startPosition).normalized;
        xOffset = endPosition.x - startPosition.x;
        yOffset = endPosition.y - startPosition.y;
        timeInterpolationStarted = Time.time;
        initialized = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (initialized && !done)
        {            
            if (!phase1Done)
            {
                float timeSinceStarted = Time.time - timeInterpolationStarted;
                float percentageComplete = timeSinceStarted / interpolationDuration;
                transform.position = new Vector2(startPosition.x + xOffset * Easings.Interpolate(percentageComplete,xInterpolation1), startPosition.y + yOffset * Easings.Interpolate(percentageComplete, yInterpolation1));         


                if (percentageComplete < colliderActivationLimit)
                {
                    col.enabled = false;
                }
                else
                {
                    col.enabled = true;
                }
                if (percentageComplete >= 1f)
                {
                    phase1Done = true;
                    if (phase2)
                    {
                        startPosition = transform.position;
                        endPosition = startPosition + direction * phase2Distance;
                        xOffset = endPosition.x - startPosition.x;
                        yOffset = endPosition.y - startPosition.y;
                        timeInterpolationStarted = Time.time;
                    }
                    else
                    {
                        EndInterpolation();
                    }
                }
            }
            else
            {
                float timeSinceStarted = Time.time - timeInterpolationStarted;
                float percentageComplete = timeSinceStarted / interpolationDuration2;
                transform.position = new Vector2(startPosition.x + xOffset * Easings.Interpolate(percentageComplete, xInterpolation2), startPosition.y + yOffset * Easings.Interpolate(percentageComplete, yInterpolation2));
                if (percentageComplete >= 1f)
                {
                    EndInterpolation();   
                }
            }
        }
    }

    public virtual void EndInterpolation()
    {
        done = true;
        col.isTrigger = false;
    }

    public void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}

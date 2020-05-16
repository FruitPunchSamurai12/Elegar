using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingRock : MonoBehaviour
{
    [SerializeField]
    Collider2D col;

    [SerializeField]
    Animator animator;

    bool initialized = false;
    bool landed = false;
    bool done = false;
    Vector2 startPos;
    Vector2 targetPos;
    Vector2 direction;
    float distanceSlideAfterLanding;
    float xOffset;
    float yOffset;
    float timeInterpolationStarted;
    public float flyingDuration = 2f;
    public float slidingDuration = 1f;
    public float colliderActivationLimit = 0.5f;

    public int damage = 1;
    public float forcePower = 500f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (initialized && !done)
        {
            if (!landed)
            {
                float timeSinceStarted = Time.time - timeInterpolationStarted;
                float percentageComplete = timeSinceStarted / flyingDuration;
                transform.position = new Vector2(startPos.x + xOffset * Easings.Linear(percentageComplete), startPos.y + yOffset * Easings.BackEaseIn(percentageComplete));
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
                    landed = true;
                    startPos = transform.position;
                    targetPos = startPos + direction * distanceSlideAfterLanding;
                    xOffset = targetPos.x - startPos.x;
                    yOffset = targetPos.y - startPos.y;
                    timeInterpolationStarted = Time.time;
                }
            }
            else
            {
                float timeSinceStarted = Time.time - timeInterpolationStarted;
                float percentageComplete = timeSinceStarted / slidingDuration;
                transform.position = new Vector2(startPos.x + xOffset * Easings.QuadraticEaseOut(percentageComplete), startPos.y + yOffset * Easings.QuadraticEaseOut(percentageComplete));
                if (percentageComplete >= 1f)
                {
                    done = true;
                    col.isTrigger = false;
                }
            }
        }
    }

    public void Initialize(Vector2 target)
    {       
        startPos = transform.position;
        targetPos = target;
        distanceSlideAfterLanding = (targetPos - startPos).magnitude / 5f;
        direction = (targetPos - startPos).normalized;
        xOffset = targetPos.x - startPos.x;
        yOffset = targetPos.y - startPos.y;
        timeInterpolationStarted = Time.time;
        initialized = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {

        }
        else
        {
            animator.SetTrigger("Break");
            col.enabled = false;
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!done)
            {
                Player p = collision.GetComponent<Player>();
                if (!p.isInvulnerable)
                {
                    Vector2 forceDirection = (collision.attachedRigidbody.position - new Vector2(transform.position.x, transform.position.y)).normalized;
                    collision.attachedRigidbody.AddForce(forceDirection * forcePower);
                    p.TakeDamage(damage);
                    p.isInvulnerable = true;
                }
                animator.SetTrigger("Break");
                col.enabled = false;
            }
        }
        else if(collision.tag != "Switch")
        {
            animator.SetTrigger("Break");
            col.enabled = false;
        }
    }
}

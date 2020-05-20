using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : Projectile
{
    [SerializeField]
    Animator animator;

    public float slowDuration = 5f;


    public override void Initialize(Vector2 target)
    {
        base.Initialize(target);
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
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
                    p.SlowPlayer(slowDuration);
                }
                EndInterpolation();
            }
        }
        else
        {
            EndInterpolation();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        EndInterpolation();   
    }

    public override void EndInterpolation()
    {
        base.EndInterpolation();
        animator.SetTrigger("Break");
        col.enabled = false;
    }
}

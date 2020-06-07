using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///the arrows rogue shoots
///most of the functionality comes from the projectile class 
///the arrows set the animator to play the correct animation and also slow elegar if they hit him
public class Arrows : Projectile
{
    [SerializeField]
    Animator animator;

    public float slowDuration = 5f;

    [SerializeField]
    AudioSource source;

    public override void Initialize(Vector2 target)
    {
        base.Initialize(target);
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        source.volume = AudioManager.fxVolume;
        source.clip = AudioManager.Instance.GetSoundEffect("ArrowFly");
        source.Play();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        source.volume = AudioManager.fxVolume;
        source.clip = AudioManager.Instance.GetSoundEffect("ArrowBreak");
        source.Play();
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

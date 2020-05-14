using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Waterable
{
    public float forcePower = 100f;
    public int damage = 1;
    public void DestroyFire()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player p = collision.GetComponent<Player>();
            if (!p.isInvulnerable)
            {
                Vector2 forceDirection = (collision.attachedRigidbody.position - new Vector2(transform.position.x,transform.position.y)).normalized;
                collision.attachedRigidbody.AddForce(forceDirection * forcePower);
                p.TakeDamage(damage);
                p.isInvulnerable = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///the pitfalls in dark areas. elegar dies if he falls down
public class Pitfall : MonoBehaviour
{
    Collider2D collider;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            if(collider.OverlapPoint(player.groundCheck.position))//we check for the ground position instead of just colliding 
            {
                player.FallToDeath();
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    bool closed = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player p = collision.GetComponent<Player>();
            if(p.hasKey && closed)
            {
                animator.SetTrigger("Open");
                closed = false;
            }
        }
    }
}

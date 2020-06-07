using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the door in level 6. straight forward

public class Door : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    bool closed = true;

    [SerializeField]
    Level6 lvl;

    public void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player p = collision.GetComponent<Player>();
            if(lvl.levelPassed && closed)
            {
                animator.SetTrigger("Open");
                closed = false;
            }
        }
    }

    public void OpenDoor()
    {
        animator.SetTrigger("Open");
        closed = false;
    }
}

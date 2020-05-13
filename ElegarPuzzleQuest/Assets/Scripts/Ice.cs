using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Player>().StartSliding();
        }
        else
        {
            Movable m = collision.GetComponent<Movable>();
            if(m)
            {
                m.onIce = true;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Player>().sliding = false;
        }
        else
        {
            Movable m = collision.GetComponent<Movable>();
            if (m)
            {
                m.onIce = false;
            }
        }
    }

}

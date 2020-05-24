using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bushes : MonoBehaviour
{
    Collider2D col;

    public bool low = true;

    public bool hidesPlayer = false;

    [SerializeField]
    Bushes otherBushes;

    private void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            if (low)
            {
                if (col.OverlapPoint(player.groundCheck.position))
                {
                    player.HideInBush(true);
                    hidesPlayer = true;
                }
                else
                {
                    if (!otherBushes.hidesPlayer)
                    {
                        player.HideInBush(false);
                    }
                    hidesPlayer = false;
                }
            }
            else
            {
                if (col.OverlapPoint(player.hideShadow.transform.position))
                {
                    player.HideInBush(true);
                    hidesPlayer = true;
                }
                else
                {
                    if (!otherBushes.hidesPlayer)
                    {
                        player.HideInBush(false);
                    }
                    hidesPlayer = false;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            if (!otherBushes.hidesPlayer)
            {
                player.HideInBush(false);
            }
            hidesPlayer = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///the bushes in level 2.
///had to come up with a system to avoid visual bugs cause our sprite's sorting system is horrible 
///there are two bushes. high and low. High are drawned above the player and low below.
///low check for the elegar's feet while high check for elegar's head
///they also keep a reference to each other to check if elegar is hiding in the other bushes
///which at the moment of writing this i realize i could just have the hidesPlayer bool a static :/
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

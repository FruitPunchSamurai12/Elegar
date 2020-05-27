using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5 : Level
{
   
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player p = collision.GetComponent<Player>();
            if (p.inControl)
            {
                p.PlayerSlideDownTheCliff();
            }
        }
    }
}

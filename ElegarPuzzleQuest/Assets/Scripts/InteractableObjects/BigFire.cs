using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigFire : MonoBehaviour
{
    [SerializeField]
    GameObject bigFire;

    bool lit = false;

    public bool FireLit() { return lit; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            Fire fire = collision.GetComponent<Fire>();
            if(fire)
            {
                fire.DestroyFire();
                if(!lit)
                {
                    lit = true;
                    Instantiate(bigFire, transform.position, Quaternion.identity);
                }
            }
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Fire fire = collision.GetComponent<Fire>();
        if (fire)
        {
            fire.DestroyFire();
            if (!lit)
            {
                lit = true;
                Instantiate(bigFire, transform.position, Quaternion.identity);
            }
        }
    }

}

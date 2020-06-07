using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Helper class for the water in level 9. 

public class Water : MonoBehaviour
{
    [SerializeField]
    GameObject playerWaterCollision;

    [SerializeField]
    Level9 lvl;

    private void Update()
    {
        if (lvl.levelPassed)
        {
            if (playerWaterCollision)
            {
                Destroy(playerWaterCollision);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Movable m = collision.GetComponent<Movable>();
        if(m)
        {
            m.UnderWater();
            lvl.RockInWater();
            Destroy(playerWaterCollision);
        }
    }





}

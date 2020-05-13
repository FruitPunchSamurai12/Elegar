using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField]
    GameObject playerWaterCollision;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Movable m = collision.GetComponent<Movable>();
        if(m)
        {
            m.UnderWater();
            Destroy(playerWaterCollision);
        }
    }





}

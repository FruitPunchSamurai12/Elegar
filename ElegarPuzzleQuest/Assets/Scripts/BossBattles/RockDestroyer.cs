﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///NOT USED
public class RockDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ThrowingRock rock = collision.GetComponent<ThrowingRock>();
        if(rock)
        {
            //Destroy(rock);
        }
    }
}

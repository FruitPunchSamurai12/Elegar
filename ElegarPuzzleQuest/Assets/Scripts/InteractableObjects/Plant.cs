using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Waterable
{
    [SerializeField]
    BoxCollider2D collider;

    public override void Watered()
    {
        if (!watered)
        {
            animator.SetTrigger("Water");
            watered = true;
            collider.enabled = false;
        }
    }
}

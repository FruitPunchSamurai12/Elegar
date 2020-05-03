using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Waterable
{
    public void DestroyFire()
    {
        Destroy(gameObject);
    }
}

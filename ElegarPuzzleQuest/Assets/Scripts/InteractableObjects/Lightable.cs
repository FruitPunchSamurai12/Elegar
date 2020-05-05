using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Base class for objects that interact with the light spell
public class Lightable : MonoBehaviour
{


    protected bool lighted = false;


    public virtual void Light()
    {
        if (!lighted)
        {

            lighted = true;
        }
    }
}

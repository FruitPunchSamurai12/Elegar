using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightableAltar : Lightable
{
    [SerializeField]
    GameObject lightEffect;
    [SerializeField]
    Animator animator;

    // Update is called once per frame
    void Update()
    {
        if(lighted)
        {
            lightEffect.SetActive(true);
        }
        else
        {
            lightEffect.SetActive(false);
        }
    }

    public override void Light()
    {
        if (!lighted)
        {
            lighted = true;
            animator.SetTrigger("Light");
        }
    }

    public void ScaleLights()
    {
        lightEffect.transform.localScale *= 1.004f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///an altar you can light with the light spell. also has a light mask and provides vision underground
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
            AudioManager.Instance.PlaySoundEffect("Altar");
            lighted = true;
            animator.SetTrigger("Light");
        }
    }

    public void ScaleLights()//that's for the 4th boss fight
    {
        lightEffect.transform.localScale *= 1.004f;
    }
}

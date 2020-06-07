using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//plant in level 10. straight forward
public class Plant : Waterable
{
    [SerializeField]
    BoxCollider2D collider;

    [SerializeField]
    Level10 lvl;

    public void Update()
    {
        if(lvl.levelPassed && !watered)
        {
            animator.SetTrigger("Water");
            collider.enabled = false;
        }
    }

    public override void Watered()
    {
        if (!watered)
        {
            AudioManager.Instance.PlaySoundEffect("Item");
            animator.SetTrigger("Water");
            watered = true;
            lvl.PlantGrew();
            collider.enabled = false;
        }
    }
}

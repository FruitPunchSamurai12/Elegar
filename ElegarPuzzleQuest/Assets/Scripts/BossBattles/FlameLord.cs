using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the third boss Flame Lord
public class FlameLord : MonoBehaviour
{
    [SerializeField]
    GameObject fireProjectile;


    bool fired = false;

    public void SpawnFire()//called from the animation as an animation event
    {
        if (!fired)
        {
            fired = true;
            GameObject f = Instantiate(fireProjectile, transform.position, Quaternion.identity);
            f.GetComponent<PapaFire>().Initialize(ElegarPuzzleQuestManager.Instance.PlayerTransform().position,true);
        }
    }

    public void TimeToDie(Material dissolve)//dies same way as batula
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.material = dissolve;
        Animator animator = GetComponent<Animator>();
        animator.enabled = false;
        renderer.flipX = false;
    }

    public void Ready()
    {
        fired = false;
    }
}

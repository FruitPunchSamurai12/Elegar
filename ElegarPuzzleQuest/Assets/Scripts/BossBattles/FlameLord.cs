using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameLord : MonoBehaviour
{
    [SerializeField]
    GameObject fireProjectile;


    bool fired = false;

    public void SpawnFire()
    {
        if (!fired)
        {
            fired = true;
            GameObject f = Instantiate(fireProjectile, transform.position, Quaternion.identity);
            f.GetComponent<PapaFire>().Initialize(TestManager.Instance.PlayerTransform().position,true);
        }
    }

    public void TimeToDie(Material dissolve)
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

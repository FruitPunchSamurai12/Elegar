using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField]
    LightableAltar[] altars;

    [SerializeField]
    Animator animator;

    bool closed = true;
    private void Update()
    {
        if(closed)
        {
            bool success = true;
            foreach(var altar in altars)
            {
                if(!altar.Lit())
                {
                    success = false;
                }
            }
            if(success)
            {
                closed = false;
                animator.SetTrigger("Open");
            }
        }
    }
}

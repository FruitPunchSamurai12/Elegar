using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///the gate in level 16
public class Gate : MonoBehaviour
{


    [SerializeField]
    Animator animator;

    bool closed = true;

    public void OpenGate()
    {
        if (closed)
        {
            closed = false;
            animator.SetTrigger("Open");
        }
    }
}

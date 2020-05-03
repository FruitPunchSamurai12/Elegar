using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterable : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    bool watered = false;


    public void Watered()
    {
        if (!watered)
        {
            animator.SetTrigger("Water");
            watered = true;
        }
    }
}

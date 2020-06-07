using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Grog Grog the first boss. Moves and throws rocks. The ThrowRock function is called from the animation as an animation event

public class StoneBoss : MonoBehaviour
{
    [SerializeField]
    GameObject throwRock;


    bool threw = false;

    public void ThrowRock()
    {
        if (!threw)
        {
            threw = true;
            GameObject f = Instantiate(throwRock, transform.position, Quaternion.identity);
            f.GetComponent<ThrowingRock>().Initialize(ElegarPuzzleQuestManager.Instance.PlayerTransform().position);
        }
    }

    public void ResetThrew() { threw = false; }
}

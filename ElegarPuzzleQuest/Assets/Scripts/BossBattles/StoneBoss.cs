using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

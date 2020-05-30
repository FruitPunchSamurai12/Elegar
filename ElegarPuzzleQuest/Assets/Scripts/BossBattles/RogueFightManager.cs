using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueFightManager : MonoBehaviour
{
    [SerializeField]
    Rogue rogue;

    [SerializeField]
    GameObject bones;

    [SerializeField]
    Level7 lvl;

    // Start is called before the first frame update
    void Start()
    {
        bones.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(rogue)
        {
            if(rogue.Drowned())
            {
                bones.SetActive(true);
                lvl.RogueDrowned();
            }
        }
        if(lvl.levelPassed)
        {
            bones.SetActive(true);
        }
    }
}

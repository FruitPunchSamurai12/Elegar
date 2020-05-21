using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogueFightManager : MonoBehaviour
{
    [SerializeField]
    Rogue rogue;

    [SerializeField]
    GameObject bones;

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
            }
        }
    }
}

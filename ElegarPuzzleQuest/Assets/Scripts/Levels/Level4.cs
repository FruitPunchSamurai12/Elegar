using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4 : Level
{
    [SerializeField]
    FloorButton button;

    bool doorIsOpen = false;

    [SerializeField]
    Animator fenceDoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (button.IsPressed())
        {
            if (!doorIsOpen)
            {
                fenceDoor.SetTrigger("Open");
                doorIsOpen = true;
            }
        }
        else
        {
            if (doorIsOpen)
            {
                fenceDoor.SetTrigger("Close");
                doorIsOpen = false;
            }
        }
    }
}

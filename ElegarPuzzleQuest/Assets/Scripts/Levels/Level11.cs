using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level11 : Level
{
    [SerializeField]
    DoorTrigger doorTo12;

    public override void ExitLevel(DoorTrigger door)
    {
        if (door == doorTo12)
        {
            levelPassed = true;
            LevelManager.Instance.SetLevelPassed(levelPassed, ID);
        }
    }
}

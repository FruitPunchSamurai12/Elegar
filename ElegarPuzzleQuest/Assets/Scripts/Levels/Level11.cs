using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//you pass level 11 by moving to level 12
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

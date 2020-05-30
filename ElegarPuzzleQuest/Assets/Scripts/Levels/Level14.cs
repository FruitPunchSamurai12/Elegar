using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level14 : Level
{
    [SerializeField]
    DoorTrigger doorTo15;

    public override void ExitLevel(DoorTrigger door)
    {
        if (door == doorTo15)
        {
            levelPassed = true;
            LevelManager.Instance.SetLevelPassed(levelPassed, ID);
        }
    }
}

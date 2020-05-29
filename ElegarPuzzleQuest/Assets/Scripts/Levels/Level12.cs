using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level12 : Level
{

    [SerializeField]
    DoorTrigger doorTo11;

    [SerializeField]
    GameObject flameLord;

    protected override void EnterNotPassedLevel()
    {
        doorTo11.InvisibleWall(true);
        flameLord.SetActive(true);
    }

    protected override void EnterPassedLevel()
    {
        if (flameLord)
        {
            flameLord.SetActive(false);
        }

        base.EnterPassedLevel();
    }

    public override void ExitLevel(DoorTrigger door)
    {
        if (flameLord)
        {
            flameLord.SetActive(false);
        }
    }

    public void BossExploded()
    {
        levelPassed = true;
        doorTo11.InvisibleWall(false);
        LevelManager.Instance.SetLevelPassed(levelPassed, ID);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level7 : Level
{
    [SerializeField]
    DoorTrigger doorTo6;

    [SerializeField]
    DoorTrigger doorTo8;

    [SerializeField]
    GameObject rogue;

    [SerializeField]
    AIState rogueStartState;

    protected override void EnterNotPassedLevel()
    {
        doorTo6.InvisibleWall(true);
        doorTo8.InvisibleWall(true);
        rogue.SetActive(true);
        rogue.GetComponent<BaseAIController>().ChangeAIState(rogueStartState);
        base.EnterNotPassedLevel();
    }

    protected override void EnterPassedLevel()
    {
        if(rogue)
        {
            rogue.SetActive(false);
        }

        base.EnterPassedLevel();
    }

    public override void ExitLevel(DoorTrigger door)
    {
        if(rogue)
        {
            rogue.SetActive(false);
        }
    }

    public void RogueDrowned()
    {
        levelPassed = true;
        doorTo6.InvisibleWall(false);
        doorTo8.InvisibleWall(false);
        SentImportantObjectsPositionsToLevelManager();
        LevelManager.Instance.SetLevelPassed(levelPassed, ID);
    }
}

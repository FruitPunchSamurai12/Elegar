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

    [SerializeField]
    GameObject spellScroll;

    protected override void EnterNotPassedLevel()
    {
        doorTo6.InvisibleWall(true);
        doorTo8.InvisibleWall(true);
        if (rogue)
        {
            rogue.SetActive(true);
            rogue.GetComponent<BaseAIController>().ChangeAIState(rogueStartState);
        }
        if (spellScroll)
        {
            spellScroll.SetActive(false);
        }
        base.EnterNotPassedLevel();
    }

    protected override void EnterPassedLevel()
    {
        if(rogue)
        {
            rogue.SetActive(false);
        }
        if (spellScroll)
        {
            spellScroll.SetActive(true);
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
        if (spellScroll)
        {
            spellScroll.SetActive(true);
        }
    }
}

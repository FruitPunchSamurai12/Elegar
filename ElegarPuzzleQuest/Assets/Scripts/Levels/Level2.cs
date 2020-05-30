using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : Level
{
    [SerializeField]
    GameObject BBEG;

    [SerializeField]
    AIState introductionState;

    [SerializeField]
    AIWaypoint firstWaypoint;

    [SerializeField]
    DoorTrigger doorTo3;

    protected override void EnterNotPassedLevel()
    {
        if (BBEG)
        {
            BBEG.SetActive(true);
            BaseAIController ai = BBEG.GetComponent<BaseAIController>();
            ai.ChangeAIState(introductionState);
            ai.aiWaypoint = firstWaypoint;
        }
        base.EnterNotPassedLevel();
    }

    protected override void EnterPassedLevel()
    {
        if (BBEG)
        {
            BBEG.SetActive(false);
        }
    }

    public override void ExitLevel(DoorTrigger door)
    {
        if(door == doorTo3)
        {
            levelPassed = true;
            LevelManager.Instance.SetLevelPassed(levelPassed, ID);
        }
        if (BBEG)
        {
            BBEG.SetActive(false);
        }

    }
}

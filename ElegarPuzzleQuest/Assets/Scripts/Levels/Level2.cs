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
    AIState caughtState;

    [SerializeField]
    AIState leaveAfterCaughtState;

    [SerializeField]
    Player player;
    bool playerTookDamage = false;
    bool playerHasControl = false;

    [SerializeField]
    AIWaypoint firstWaypoint;

    [SerializeField]
    DoorTrigger doorTo3;

    private void Update()
    {
        if(BBEG)
        {
            BaseAIController ai = BBEG.GetComponent<BaseAIController>();
            if (ai.state == caughtState)
            {
                if (!playerTookDamage)
                {
                    player.TakeDamage(2);
                    player.isInvulnerable = true;
                    player.inControl = false;
                    playerTookDamage = true;
                    player.GetStunned();
                }
            }
            else if (ai.state == leaveAfterCaughtState)
            {
                if (!playerHasControl)
                {
                    player.inControl = true;
                    playerHasControl = true;
                }
            }
        }
    }

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

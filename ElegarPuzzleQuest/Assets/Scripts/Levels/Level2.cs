using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///level 2 is a hide and seek game against the game's evil guy. you can still pass the level if you get caught you will just take damage
public class Level2 : Level
{
    [SerializeField]
    GameObject BBEG;//big bad evil guy. he is the fifth boss not made yet

    [SerializeField]
    AIState introductionState;//his starting state. need to reassign this in case the player enters the level, goes back to level 1 and then reenters

    [SerializeField]
    AIState caughtState;//bbeg has caught elegar. need this to compare

    [SerializeField]
    AIState leaveAfterCaughtState;//bbeg is leaving the scene after he has caught elegar. need this to compare

    [SerializeField]
    Player player;//the player will take damage and get stunned if he gets caught
    bool playerTookDamage = false;
    bool playerHasControl = false;

    [SerializeField]
    AIWaypoint firstWaypoint;//bbeg's starting waypoint

    [SerializeField]
    DoorTrigger doorTo3;

    private void Update()
    {
        if(BBEG)
        {
            BaseAIController ai = BBEG.GetComponent<BaseAIController>();
            if (ai.state == caughtState)//if the ai caught the player
            {
                if (!playerTookDamage)
                {//make him take damage once and stun him
                    player.TakeDamage(2);
                    player.isInvulnerable = true;
                    player.inControl = false;
                    playerTookDamage = true;
                    player.GetStunned();
                }
            }
            else if (ai.state == leaveAfterCaughtState)//after the ai leaves give player control again
            {
                if (!playerHasControl)//had to do this or else it would interfere when moving through levels
                {
                    player.inControl = true;
                    playerHasControl = true;
                }
            }
        }
    }

    protected override void EnterNotPassedLevel()
    {
        if (BBEG)//set him up
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

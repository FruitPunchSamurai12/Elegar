using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Decision for when you want to change state after some time has passed
[CreateAssetMenu(menuName = "PluggableAI/Decisions/TimeElapsed")]
public class DecisionTimeElapsed : Decision
{
    public override bool Decide(BaseAIController controller)
    {
        if(controller.stateTime>controller.state.TimeLimit)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

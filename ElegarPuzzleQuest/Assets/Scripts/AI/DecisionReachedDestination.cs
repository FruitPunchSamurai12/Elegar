using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/ReachedDestination")]
public class DecisionReachedDestination : Decision
{
    public override bool Decide(BaseAIController controller)
    {
        float distance = Vector2.Distance(controller.transform.position, controller.target);
        if(distance<controller.nextWaypointDistance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

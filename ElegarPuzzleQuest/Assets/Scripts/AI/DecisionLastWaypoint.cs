using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/LastWaypoint")]
public class DecisionLastWaypoint : Decision
{
    public override bool Decide(BaseAIController controller)
    {
        if (controller.aiWaypoint.nextWaypont == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

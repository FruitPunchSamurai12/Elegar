using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/NextWaypoint")]
public class DecisionNextAIWaypoint : Decision
{
    public override bool Decide(BaseAIController controller)
    {
        if (Vector2.Distance((Vector2)(controller.aiWaypoint.transform.position), (Vector2)(controller.transform.position)) < controller.nextWaypointDistance)
        {
            if (controller.aiWaypoint.nextWaypont != null)
            {
                controller.aiWaypoint = controller.aiWaypoint.nextWaypont;
                return true;
            }
        }
        return false;
    }
}

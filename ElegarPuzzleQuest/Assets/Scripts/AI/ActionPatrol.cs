using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class ActionPatrol : Action
{
    public override void Act(BaseAIController controller)
    {
        if (Vector2.Distance((Vector2)(controller.aiWaypoint.transform.position), (Vector2)(controller.transform.position)) < controller.nextWaypointDistance)
        {
            controller.aiWaypoint = controller.aiWaypoint.nextWaypont;
        }
        if (controller.aiWaypoint != null)
        {
            controller.target = controller.aiWaypoint.transform;
        }
    }
}

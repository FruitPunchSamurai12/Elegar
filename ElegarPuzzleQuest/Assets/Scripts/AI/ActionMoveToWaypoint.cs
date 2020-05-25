using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/MoveToWaypoint")]
public class ActionMoveToWaypoint : Action
{
    public override void Act(BaseAIController controller)
    {
        if (controller.aiWaypoint != null)
        {
            controller.ToggleFreezeMovement(false);
            controller.target = controller.aiWaypoint.transform.position;
        }
    }
}

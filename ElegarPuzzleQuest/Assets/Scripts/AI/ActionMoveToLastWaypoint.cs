using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/MoveToLastWaypoint")]
public class ActionMoveToLastWaypoint : Action
{
    
    public override void Act(BaseAIController controller)
    {
       if(controller.aiWaypoint)
        {
            while(controller.aiWaypoint.nextWaypont != null)
            {
                controller.aiWaypoint = controller.aiWaypoint.nextWaypont;
            }
            controller.ToggleFreezeMovement(false);
            controller.target = controller.aiWaypoint.transform.position;
        }
        
    }

}


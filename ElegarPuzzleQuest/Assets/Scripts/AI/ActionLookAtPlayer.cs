using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/LookAtPlayer")]
public class ActionLookAtPlayer : Action
{
    public override void Act(BaseAIController controller)
    {
        controller.FreezeUnfreezeMovement(true);
        controller.target = TestManager.Instance.PlayerTransform().position;      
    }
}


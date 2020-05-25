using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/DisableCollider")]
public class ActionDisableCollider : Action
{
    public override void Act(BaseAIController controller)
    {
        if (controller.col)
        {
            controller.col.enabled = false;
        }
    }

}

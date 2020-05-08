using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/SetAnimationTrigger")]
public class ActionSetAnimationTrigger : Action
{
    public string triggerName;
    public override void Act(BaseAIController controller)
    {
        controller.SetAnimatorTrigger(triggerName);
    }
}

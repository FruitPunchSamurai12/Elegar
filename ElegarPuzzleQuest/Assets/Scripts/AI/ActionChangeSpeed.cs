using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/ChangeSpeed")]
public class ActionChangeSpeed : Action
{
    public float newSpeed = 500f;
    public override void Act(BaseAIController controller)
    {
        controller.ToggleFreezeMovement(false);
        controller.speed = newSpeed;
    }

}

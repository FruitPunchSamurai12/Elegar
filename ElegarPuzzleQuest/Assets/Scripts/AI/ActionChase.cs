using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Chase")]
public class ActionChase : Action
{
    public override void Act(BaseAIController controller)
    {
        controller.target = TestManager.Instance.PlayerTransform();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Iddle")]
public class ActionIddle : Action
{
    public override void Act(BaseAIController controller)
    {
        controller.target = controller.transform;
    }

}

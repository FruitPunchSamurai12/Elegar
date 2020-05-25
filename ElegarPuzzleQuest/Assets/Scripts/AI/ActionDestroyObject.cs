using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/DestroyObject")]
public class ActionDestroyObject : Action
{
    public float delay = 0f;
    public override void Act(BaseAIController controller)
    {
        Destroy(controller.gameObject, delay);
    }

}

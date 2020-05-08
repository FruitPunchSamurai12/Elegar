using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/True")]
public class DecisionTRUE : Decision
{
    public override bool Decide(BaseAIController controller)
    {
        return true;
    }
}

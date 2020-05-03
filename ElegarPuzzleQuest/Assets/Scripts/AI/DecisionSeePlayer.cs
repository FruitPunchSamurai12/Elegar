using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/See")]
public class DecisionSeePlayer : Decision
{
    public override bool Decide(BaseAIController controller)
    {
        Vector2 playerPosition = TestManager.Instance.PlayerTransform().position;
        Vector2 targetDir = playerPosition - (Vector2)controller.transform.position;
        float angle = Vector3.Angle(targetDir, controller.CharacterDirection());
        float distance = Vector2.Distance(playerPosition,controller.transform.position);

        //if the target 
        if (distance < controller.sightRange && angle < 45f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

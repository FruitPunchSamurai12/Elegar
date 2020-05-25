using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/See")]
public class DecisionSeePlayer : Decision
{
    public override bool Decide(BaseAIController controller)
    {
        Vector2 playerPosition = TestManager.Instance.PlayerTransform().position;
        Vector2 targetDir = playerPosition - (Vector2)controller.eyesPos.position;
        float angle = Vector2.Angle(targetDir, controller.CharacterDirection());
        float distance = Vector2.Distance(playerPosition,controller.eyesPos.position);

        //if the target 
        if (distance < controller.sightRange && angle < 45f)
        {

            int layerMask = 1 << LayerMask.NameToLayer("Bushes");
            RaycastHit2D hit = Physics2D.Raycast(controller.eyesPos.position, targetDir.normalized, distance, layerMask);
            if (hit.collider == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}

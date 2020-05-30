using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Hear")]
public class DecisionHearPlayer : Decision
{
    public override bool Decide(BaseAIController controller)
    {
        Vector2 playerPosition = ElegarPuzzleQuestManager.Instance.PlayerTransform().position;
        float distance = Vector2.Distance(playerPosition, controller.transform.position);
        if(distance<controller.hearRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/PlayerTooClose")]
public class DecisionPlayerTooClose : Decision
{
    public float range = 5f;

    public override bool Decide(BaseAIController controller)
    {
        Vector2 playerPosition = ElegarPuzzleQuestManager.Instance.PlayerTransform().position;
        float distance = Vector2.Distance(playerPosition, controller.transform.position);
        if (distance < range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

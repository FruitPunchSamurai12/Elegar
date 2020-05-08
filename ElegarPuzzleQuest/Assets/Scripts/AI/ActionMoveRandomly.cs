using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/MoveRandomly")]
public class ActionMoveRandomly : Action
{
    public float maxX,minX,maxY,minY;


    public override void Act(BaseAIController controller)
    {
        controller.RandomMovement(minX, maxX, minY, maxY);
    }
}

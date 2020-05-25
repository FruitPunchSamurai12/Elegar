using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/LookAround")]
public class ActionLookAround : Action
{
    float timeElapsed = 0f;
    public float directionChangeFrequency = 0.5f;
    Vector2 dir = Vector2.down;

    public override void Act(BaseAIController controller)
    {
        controller.ToggleFreezeMovement(true);
        ChangeDirection();
        controller.target = (Vector2)controller.transform.position + dir;
    }

    void ChangeDirection()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed>directionChangeFrequency)
        {
            int random = Random.Range(0, 4);
            switch(random)
            {
                case 0:
                    dir = Vector2.down;
                    break;
                case 1:
                    dir = Vector2.left;
                    break;
                case 2:
                    dir = Vector2.right;
                    break;
                case 3:
                    dir = Vector2.up;
                    break;
                default:
                    dir = Vector2.down;
                    break;

            }
            timeElapsed = 0;
        }
    }
}
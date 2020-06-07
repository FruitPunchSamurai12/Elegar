using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is used by the 4th boss to decide on a destination by picking from a list
//it is the exact same as decisionPickATargetFromList
//i wrote this first and when i needed this behaviour again some time had passed and i forgot i already had it so i rewrote it
[CreateAssetMenu(menuName = "PluggableAI/Decisions/Boss4FindDestination")]
public class DecisionBoss4FindDestination : Decision
{
    public Vector2[] waypoints;
    public override bool Decide(BaseAIController controller)
    {
        int random;
        do
        {
            random = Random.Range(0, waypoints.Length);
        }while(Vector2.Distance(controller.transform.position,waypoints[random])<controller.nextWaypointDistance);
        controller.target = waypoints[random];
        return true;
    }
}

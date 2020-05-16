using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/PickTargetFromList")]
public class DecisionPickATargetFromList : Decision
{
    public Vector2[] targetsToChooseFrom;
    int index = -1;

    public override bool Decide(BaseAIController controller)
    {
        int random;
        do
        {
            random = Random.Range(0, targetsToChooseFrom.Length);
        } while (random == index);
        index = random;
        controller.target = targetsToChooseFrom[index];
        return true;

    }
}

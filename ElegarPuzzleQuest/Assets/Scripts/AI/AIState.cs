﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///The AI State class. Check the GDD on how AI works

[CreateAssetMenu(menuName = "PluggableAI/State")]
public class AIState : ScriptableObject
{
    public float TimeLimit;
    public Action[] actions;
    public Transition[] transitions;

    public void UpdateState(BaseAIController controller)
    {
        DoActions(controller);
        CheckTransitions(controller);
    }

    private void DoActions(BaseAIController controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(controller);
        }
    }

    private void CheckTransitions(BaseAIController controller)
    {
        for (int i = 0; i < transitions.Length; i++)
        {
            bool decisionSucceeded = transitions[i].decision.Decide(controller);

            if (decisionSucceeded)
            {
                if (controller.state != transitions[i].trueState)
                {
                    controller.ChangeAIState(transitions[i].trueState);
                    return;
                }
            }
            else
            {
                if (controller.state != transitions[i].falseState)
                {
                    controller.ChangeAIState(transitions[i].falseState);
                    return;
                }
            }
        }
    }


}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/CloseDialogue")]
public class ActionCloseDialogue : Action
{
    public override void Act(BaseAIController controller)
    {
        controller.dialogueBox.SetActive(false);
    }

}

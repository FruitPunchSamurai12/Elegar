using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/PopUpDialogue")]
public class ActionPopUpDialogue : Action
{
    public string dialogueText;
    public override void Act(BaseAIController controller)
    {
        controller.dialogue.SetDialogue(dialogueText);
        controller.dialogueBox.SetActive(true);
    }

}
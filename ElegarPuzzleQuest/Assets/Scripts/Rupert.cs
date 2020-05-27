using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rupert : MonoBehaviour
{
    public Animator rupertAnimator;
    public Animator portalAnimator;
    public AIDialogueBox dialogue;
    public GameObject dialogueBox;
    public string dialogueText;

    private void Start()
    {
        dialogue.SetDialogue(dialogueText);
    }

    public void ExitRupert()
    {
        dialogueBox.SetActive(false);
        rupertAnimator.SetTrigger("Exit");
    }

    public void ExitPortal()
    {
        portalAnimator.SetTrigger("Exit");
    }

    public void EnableDialogue()
    {
        dialogueBox.SetActive(true);
    }

}

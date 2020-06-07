using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Thats a helper class for rupert to appear from a portal
///the portal gets activated by another script, usually the level he is at and then this script starts running
///it pretty much just calls all functions in an order 
public class Rupert : MonoBehaviour
{
    public Animator rupertAnimator;
    public Animator portalAnimator;
    public AIDialogueBox dialogue;
    public GameObject dialogueBox;
    public string dialogueText;
    public float rupertDuration = 10f;
    [SerializeField]
    GameObject portal;
    private void Start()
    {
        dialogue.SetDialogue(dialogueText);
        EnableDialogue();
    }

    public void ExitRupert()
    {
        dialogueBox.SetActive(false);
        rupertAnimator.SetTrigger("Exit");
        Invoke("DeactivatePortal", 1f);
    }

    void DeactivatePortal()
    {
        portal.SetActive(false);
    }

    public void ExitPortal()
    {
        portalAnimator.SetTrigger("Exit");
    }

    public void EnableDialogue()
    {
        dialogueBox.SetActive(true);
        Invoke("ExitRupert", rupertDuration);
    }


}

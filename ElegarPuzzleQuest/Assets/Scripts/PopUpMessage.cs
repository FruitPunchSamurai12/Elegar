using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class PopUpMessage : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    public string dialogue;
    public bool playerInRange;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            dialogueBox.SetActive(true);
            dialogueText.text = dialogue;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           playerInRange = false;
           dialogueBox.SetActive(false);
        }
    }

}
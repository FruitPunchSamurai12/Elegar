using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIDialogueBox : MonoBehaviour
{
    public Text textObject;

    public string text;

    public void SetDialogue(string s)
    {
        text = s;
        textObject.text = text;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : Level
{
    [SerializeField]
    GameObject portal;
    [SerializeField]
    Rupert rupert;

    bool rupertAppeared = false;

    public float rupertDuration = 6f;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!levelPassed && !rupertAppeared)
            {
                portal.SetActive(true);
                rupertAppeared = true;
                Invoke("RupertDialogue", 1f);
            }
        }
    }

    void RupertDialogue()
    {
        rupert.EnableDialogue();
        Invoke("RupertExit", rupertDuration);
    }

    void RupertExit()
    {
        rupert.ExitRupert();
        Destroy(portal, 1f);
        levelPassed = true;
        LevelManager.Instance.SetLevelPassed(levelPassed, ID);
    }
}

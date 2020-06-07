using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///The first level. Just makes Rupert appear when the player walks out of the stairs
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
                levelPassed = true;
                LevelManager.Instance.SetLevelPassed(levelPassed, ID);
              
            }
        }
    }


}

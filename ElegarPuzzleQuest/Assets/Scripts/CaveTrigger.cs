using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveTrigger : MonoBehaviour
{
    public int currentLevel;
    public int nextLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<Player>().PlayerAlive())
            {
                ElegarPuzzleQuestManager.Instance.EnterExitCave(nextLevel, currentLevel);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


///trigger collider for caves.
public class CaveTrigger : MonoBehaviour
{
    public int currentLevel;
    public int nextLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<Player>().PlayerAlive())//had a bug where i fell down a pitfall but i also touched the collider and moved me alive to next level
            {
                ElegarPuzzleQuestManager.Instance.EnterExitCave(nextLevel, currentLevel);
            }
        }
    }
}

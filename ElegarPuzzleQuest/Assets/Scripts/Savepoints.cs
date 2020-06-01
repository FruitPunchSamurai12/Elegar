using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savepoints : MonoBehaviour
{
    public int ID;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            LevelManager.Instance.playerLevelSave = ID;
            LevelManager.Instance.playerSpellsUnlocked = collision.GetComponent<Player>().spellsUnlocked;
            LevelManager.Instance.SaveGame();
        }
    }
}

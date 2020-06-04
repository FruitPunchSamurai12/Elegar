﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savepoints : MonoBehaviour
{
    public int ID;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Player p = collision.GetComponent<Player>();
            LevelManager.Instance.playerLevelSave = ID;
            LevelManager.Instance.playerSpellsUnlocked = p.spellsUnlocked;
            HUD.Instance.currentHealth = p.maxLife;
            HUD.Instance.OnSaveGame();
            LevelManager.Instance.SaveGame();
        }
    }
}

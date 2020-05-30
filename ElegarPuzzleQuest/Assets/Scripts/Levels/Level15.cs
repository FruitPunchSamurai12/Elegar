using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level15 : Level
{
   
    void Start()
    {
        levelPassed = LevelManager.Instance.IsLevelPassed(ID);
        EnterLevel();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            levelPassed = true;
            SentImportantObjectsPositionsToLevelManager();
            LevelManager.Instance.SetLevelPassed(levelPassed, ID);
        }
    }


}

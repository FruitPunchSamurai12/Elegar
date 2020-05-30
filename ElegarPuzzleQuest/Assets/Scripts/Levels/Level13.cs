using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level13 : Level
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            levelPassed = true;
            LevelManager.Instance.SetLevelPassed(levelPassed, ID);
        }
    }
}

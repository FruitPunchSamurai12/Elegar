using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//just need to walk to exit of the cave to pass level 13
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

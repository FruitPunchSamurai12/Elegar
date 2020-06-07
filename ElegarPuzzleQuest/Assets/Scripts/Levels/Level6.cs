using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//you need to get the key to pass level 6
public class Level6 : Level
{
    [SerializeField]
    Door door;

    protected override void EnterPassedLevel()
    {
        door.OpenDoor();
        DeActivateAllImportantObjects();
    }

    public void GotKey()
    {
        levelPassed = true;
        LevelManager.Instance.SetLevelPassed(levelPassed, ID);

    }
}

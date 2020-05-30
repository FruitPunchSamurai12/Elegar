using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

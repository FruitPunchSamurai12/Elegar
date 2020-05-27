using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : Level
{
    

    [SerializeField]
    DoorTrigger doorTo2;
    protected override void EnterNotPassedLevel()
    {
        ActivateAllImportantObjects();
        doorTo2.InvisibleWall(true);
        base.EnterNotPassedLevel();
    }

    protected override void EnterPassedLevel()
    {
        DeActivateAllImportantObjects();
    }



    public void BossDown()
    {
        levelPassed = true;
        doorTo2.InvisibleWall(false);
    }
}

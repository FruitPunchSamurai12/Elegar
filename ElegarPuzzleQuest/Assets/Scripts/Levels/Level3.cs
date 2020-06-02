using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3 : Level
{
    

    [SerializeField]
    DoorTrigger doorTo2;

    [SerializeField]
    GameObject spellScroll;
    protected override void EnterNotPassedLevel()
    {
        ActivateAllImportantObjects();
        doorTo2.InvisibleWall(true);
        if (spellScroll)
        {
            spellScroll.SetActive(false);
        }
        base.EnterNotPassedLevel();
    }

    protected override void EnterPassedLevel()
    {
        DeActivateAllImportantObjects();
        if(spellScroll)
        {
            spellScroll.SetActive(true);
        }
    }



    public void BossDown()
    {
        levelPassed = true;
        LevelManager.Instance.SetLevelPassed(levelPassed, ID);
        doorTo2.InvisibleWall(false);
        if (spellScroll)
        {
            spellScroll.SetActive(true);
        }
    }

   

}

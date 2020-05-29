using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level9 : Level
{
    [SerializeField]
    Movable m;



    protected override void EnterPassedLevel()
    {
        base.EnterPassedLevel();
        m.UnderWater();
    }


    public void RockInWater()
    {
        levelPassed = true;
        SentImportantObjectsPositionsToLevelManager();
        LevelManager.Instance.SetLevelPassed(levelPassed, ID);
    }

}

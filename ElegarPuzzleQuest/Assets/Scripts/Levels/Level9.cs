using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//to pass level 9 you need to push the rock in the water
public class Level9 : Level
{
    [SerializeField]
    Movable m;



    protected override void EnterPassedLevel()
    {
        base.EnterPassedLevel();
        m.UnderWater();//the rock is underwater if you have already passed
    }


    public void RockInWater()
    {
        levelPassed = true;
        SentImportantObjectsPositionsToLevelManager();//saves the rock's position
        LevelManager.Instance.SetLevelPassed(levelPassed, ID);
    }

}

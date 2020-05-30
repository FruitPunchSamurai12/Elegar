using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level17 : Level
{
    // Start is called before the first frame update
    void Start()
    {
        levelPassed = LevelManager.Instance.IsLevelPassed(ID);
        EnterLevel();
    }

    protected override void EnterNotPassedLevel()
    {
        ActivateAllImportantObjects();
        base.EnterNotPassedLevel();
    }

    protected override void EnterPassedLevel()
    {
        DeActivateAllImportantObjects();
    }

    public void BatulaExtinguished()
    {
        levelPassed = true;
        LevelManager.Instance.SetLevelPassed(levelPassed, ID);
    }
}

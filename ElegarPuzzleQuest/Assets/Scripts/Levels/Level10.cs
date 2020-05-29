using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level10 : Level
{
    public void PlantGrew()
    {
        levelPassed = true;
        LevelManager.Instance.SetLevelPassed(levelPassed, ID);
    }
    
}

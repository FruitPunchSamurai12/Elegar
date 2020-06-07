using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//you pass level 10 by watering the plant
public class Level10 : Level
{
    public void PlantGrew()
    {
        levelPassed = true;
        LevelManager.Instance.SetLevelPassed(levelPassed, ID);
    }
    
}

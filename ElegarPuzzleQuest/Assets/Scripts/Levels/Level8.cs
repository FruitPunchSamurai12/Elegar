using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level8 : Level
{
    [SerializeField]
    DoorTrigger doorTo9;

    [SerializeField]
    GameObject fireObstacle;

    private void Update()
    {
        if(fireObstacle)
        {
            doorTo9.InvisibleWall(true);
        }
        else
        {
            levelPassed = true;
            LevelManager.Instance.SetLevelPassed(levelPassed, ID);
            doorTo9.InvisibleWall(false);
        }
    }

}

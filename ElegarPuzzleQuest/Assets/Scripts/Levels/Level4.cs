using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//you need to move to level 5 to pass level 4. also in order to move to level 7 you need to extinguish the fire
public class Level4 : Level
{
    [SerializeField]
    FloorButton button;

    [SerializeField]
    DoorTrigger doorTo5;

    [SerializeField]
    DoorTrigger doorTo7;

    [SerializeField]
    DoorTrigger doorFrom7;

    [SerializeField]
    GameObject fireObstacle;

    bool doorIsOpen = false;

    [SerializeField]
    Animator fenceDoor;

    void Start()
    {
        levelPassed = LevelManager.Instance.IsLevelPassed(ID);
        EnterLevel();
    }



    // Update is called once per frame
    void Update()
    {
        if(fireObstacle == null)
        {
            doorTo7.InvisibleWall(false);
            doorFrom7.InvisibleWall(false);
        }
        else
        {
            doorTo7.InvisibleWall(true);
            doorFrom7.InvisibleWall(true);
        }

        if (button.IsPressed())//open the door to 5 when the button is pressed
        {
            if (!doorIsOpen)
            {
                fenceDoor.SetTrigger("Open");
                doorIsOpen = true;           
            }
            doorTo5.InvisibleWall(false);
        }
        else
        {
            if (doorIsOpen)
            {
                fenceDoor.SetTrigger("Close");
                doorIsOpen = false;
            }
            doorTo5.InvisibleWall(true);
        }
    }

    public override void ExitLevel(DoorTrigger door)
    {
        if (door == doorTo5)
        {
            levelPassed = true;
            SentImportantObjectsPositionsToLevelManager();//save the rock's position
            LevelManager.Instance.SetLevelPassed(levelPassed, ID);
        }      
    }
}

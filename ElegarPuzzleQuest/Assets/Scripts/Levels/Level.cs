using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Base Level class. All the levels inherit from this. 
///contains functions for entering and exiting a level called by the door triggers on that level
///Levels that have important objects for the puzzles in them also hold a reference to these objects in the importantObjects array
///When the player enters a level he hasn't cleared all important objects will be at their default positions (this is to avoid having the player stuck)
///when the player enters a level he cleared all objects will remain in the position the player left them

public class Level : MonoBehaviour
{
    public int ID = 0;
    public bool levelPassed = false;
    public GameObject[] importantObjects;
    public Vector2[] importantObjectsStartingPositions;//the default positions

    private void Start()
    {
        levelPassed = LevelManager.Instance.IsLevelPassed(ID);//on start we check if this level is passed
    }

    public virtual void EnterLevel()//enter level without a door parameter. used on levels that are on different unity scenes
    {
        if (levelPassed)
        {
            EnterPassedLevel();
        }
        else
        {
            EnterNotPassedLevel();
        }
    }

    public virtual void EnterLevel(DoorTrigger door)//called when the player passes through a door
    {
        if(levelPassed)
        {
            EnterPassedLevel();
        }
        else
        {
            EnterNotPassedLevel();
        }
    }

    public virtual void ExitLevel(DoorTrigger door)//called when the player passes through a door
    {

    }

    protected virtual void EnterPassedLevel()//get the position of all important objects and place them there
    {
        int i = 0;
        Vector2[] pos = LevelManager.Instance.GetImportantObjectsPositions(ID);
        foreach (GameObject obj in importantObjects)
        {
            if (obj && i<pos.Length)
            {
                obj.transform.position = pos[i];
                i++;
            }
        }
    }

    protected void ActivateAllImportantObjects()
    {
        foreach (GameObject obj in importantObjects)
        {
            if (obj)
            {
                obj.SetActive(true);
            }
        }
    }

    protected void DeActivateAllImportantObjects()//mostly used for boss fights
    {
        foreach (GameObject obj in importantObjects)
        {
            if (obj)
            {
                obj.SetActive(false);
            }
        }
    }

    protected virtual void EnterNotPassedLevel()//place all important objects on their default positions
    {
        int i = 0;
        foreach (GameObject obj in importantObjects)
        {
            if (obj)
            {
                obj.transform.position = importantObjectsStartingPositions[i];
                i++;
            }
        }
    }

    //Saves the important object's positions. Usually used the moment the level is passed
    protected void SentImportantObjectsPositionsToLevelManager()
    {
        Vector2[] positions = new Vector2[importantObjects.Length];
        int i = 0;
        foreach (GameObject obj in importantObjects)
        {
            if (i < positions.Length)
            {
                positions[i] = obj.transform.position;
                i++;
            }
        }
        LevelManager.Instance.SetImportantObjectPositions(positions, ID);
    }

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int ID = 0;
    public bool levelPassed = false;
    public GameObject[] importantObjects;
    public Vector2[] importantObjectsStartingPositions;

    private void Start()
    {
        levelPassed = LevelManager.Instance.IsLevelPassed(ID);
    }

    public virtual void EnterLevel(DoorTrigger door)
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

    public virtual void ExitLevel(DoorTrigger door)
    {

    }

    protected virtual void EnterPassedLevel()
    {

    }

    protected void ActivateAllImportantObjects()
    {
        foreach(GameObject obj in importantObjects)
        {
            obj.SetActive(true);
        }
    }

    protected void DeActivateAllImportantObjects()
    {
        foreach (GameObject obj in importantObjects)
        {
            obj.SetActive(false);
        }
    }

    protected virtual void EnterNotPassedLevel()
    {
        int i = 0;
        foreach (GameObject obj in importantObjects)
        {
            obj.transform.position = importantObjectsStartingPositions[i];
            i++;
        }
    }

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

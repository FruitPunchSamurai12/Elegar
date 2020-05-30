using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public string objectPositionsFileName;
    public string levelPassedFileName;

    [SerializeField]
    bool[] levelsPassed;

    public Vector2[] cameraStartingPositions;
    public Vector2[] savePointsPositions;

    public Vector2[] worldMapCavePositions;
    public Vector2[] level13CavePositions;
    public Vector2 level14CavePosition;
    public Vector2 level15CavePosition;
    public Vector2[] level16CavePositions;
    public Vector2[] level17CavePositions;

    public Vector2[] level4Positions;
    public Vector2[] level5Positions;
    public Vector2[] level7Positions;
    public Vector2[] level9Positions;
    public Vector2[] level15Positions;

    public Vector2 GetCavePosition(int levelToGo,int previousLevel)
    {
        switch (levelToGo)
        {
            case 5:
                return worldMapCavePositions[0];
            case 8:
                return worldMapCavePositions[1];
            case 13:
                if(previousLevel ==8)
                {
                    return level13CavePositions[0];
                }
                else if (previousLevel == 14)
                {
                    return level13CavePositions[1];
                }
                break;
            case 14:
                return level14CavePosition;
            case 15:
                return level15CavePosition;
            case 16:
                if (previousLevel == 15)
                {
                    return level16CavePositions[0];
                }
                else if (previousLevel == 17)
                {
                    return level16CavePositions[1];
                }
                break;
            case 17:
                if (previousLevel == 16)
                {
                    return level17CavePositions[0];
                }
                else if (previousLevel == 5)
                {
                    return level17CavePositions[1];
                }
                break;
        }
        return Vector2.zero;

    }

    public bool IsLevelPassed(int currentLevel)
    {
        int index = currentLevel - 1;
        if(index < levelsPassed.Length)
        {
            return levelsPassed[index];
        }
        return false;
    }

    public Vector2 GetCameraStartingPosition(int lvl)
    {
        switch (lvl)
        {
            case 1:
                return cameraStartingPositions[0];
            case 4:
                return cameraStartingPositions[1];
            case 5:
                return cameraStartingPositions[2];
            case 8:
                return cameraStartingPositions[3];
            case 11:
                return cameraStartingPositions[4];
            case 14:
                return cameraStartingPositions[5];
            case 15:
                return cameraStartingPositions[6];
            default:
                return Vector2.zero;
        }
    }

    public Vector2 SavePointsPosition(int lvl)
    {
        switch (lvl)
        {
            case 1:
                return savePointsPositions[0];
            case 4:
                return savePointsPositions[1];          
            case 8:
                return savePointsPositions[2];
            case 11:
                return savePointsPositions[3];
            case 16:
                return savePointsPositions[4];
            default:
                return Vector2.zero;
        }
    }

    public void SetLevelPassed(bool passed, int currentLevel)
    {
        if(currentLevel-1<levelsPassed.Length && currentLevel>0)
        {
            levelsPassed[currentLevel - 1] = passed;
        }
    }

    public void SetImportantObjectPositions(Vector2[] positions,int currentLevel)
    {
        switch (currentLevel)
        {
            case 4:
                level4Positions = positions;
                break;
            case 5:
                 level5Positions = positions;
                break;
            case 7:
                 level7Positions = positions;
                break;
            case 9:
                 level9Positions = positions;
                break;
            case 15:
                 level15Positions = positions;
                break;
            default:
                break;
        }
    }

    public Vector2[] GetImportantObjectsPositions(int currentLevel)
    {
        switch(currentLevel)
        {
            case 4:
                return level4Positions;
            case 5:
                return level5Positions;
            case 7:
                return level7Positions;
            case 9:
                return level9Positions;
            case 15:
                return level15Positions;
            default:
                return null;
        }
    }
    


    private void Awake()
    {
        if (Instance == null)//simpleton pattern
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }




}

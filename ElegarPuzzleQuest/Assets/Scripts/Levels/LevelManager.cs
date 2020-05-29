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


    public Vector2[] level4Positions;
    public Vector2[] level5Positions;
    public Vector2[] level7Positions;
    public Vector2[] level9Positions;
    public Vector2[] level15Positions;

    public bool IsLevelPassed(int currentLevel)
    {
        int index = currentLevel - 1;
        if(index < levelsPassed.Length)
        {
            return levelsPassed[index];
        }
        return false;
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

    public Vector2[] GetImportantObjectsTransforms(int currentLevel)
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

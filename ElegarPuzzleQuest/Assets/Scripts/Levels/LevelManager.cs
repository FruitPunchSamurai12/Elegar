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


    public Transform[] level4Transforms;
    public Transform[] level5Transforms;
    public Transform[] level7Transforms;
    public Transform[] level9Transforms;
    public Transform[] level15Transforms;

    public bool IsLevelPassed(int currentLevel)
    {
        int index = currentLevel - 1;
        if(index < levelsPassed.Length)
        {
            return levelsPassed[index];
        }
        return false;
    }

    public Transform[] GetImportantObjectsTransforms(int currentLevel)
    {
        switch(currentLevel)
        {
            case 4:
                return level4Transforms;
            case 5:
                return level5Transforms;
            case 7:
                return level7Transforms;
            case 9:
                return level9Transforms;
            case 15:
                return level15Transforms;
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

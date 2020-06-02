using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public string objectPositionsFileName;
    public string levelPassedFileName;
    public string playerStatsFileName;

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

    public int playerLevelSave = 1;
    public int playerSpellsUnlocked = 0;

 

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

    void LoadPlayerStats()
    {
        XmlDocument xmlDocLevelPassed = new XmlDocument();
        xmlDocLevelPassed.Load(playerStatsFileName);
        XmlNode xmlNode = xmlDocLevelPassed.DocumentElement.ChildNodes[0].FirstChild;
        playerLevelSave = int.Parse(xmlNode.Attributes["level"].Value);
        playerSpellsUnlocked = int.Parse(xmlNode.Attributes["spells"].Value);
    }

    void LoadLevelsPassed()
    {
        XmlDocument xmlDocLevelPassed = new XmlDocument();
        xmlDocLevelPassed.Load(levelPassedFileName);
        for (int i = 0; i < levelsPassed.Length; i++)
        {
            XmlNode xmlNode = xmlDocLevelPassed.DocumentElement.ChildNodes[i].FirstChild;
            int check = int.Parse(xmlNode.Attributes["lvl"].Value);
            if (check == 0)
            {
                levelsPassed[i] = false;
            }
            else
            {
                levelsPassed[i] = true;
            }
        }

    }

    public void LoadGame()//this should return a bool
    {
        LoadPlayerStats();
        LoadLevelsPassed();
        LoadObjectsPositions();      
    }

    void LoadObjectsPositions()
    {
        XmlDocument xmlDocPositions = new XmlDocument();
        xmlDocPositions.Load(objectPositionsFileName);
        LoadLevel4Positions(xmlDocPositions.DocumentElement.ChildNodes[0].FirstChild);
        LoadLevel5Positions(xmlDocPositions.DocumentElement.ChildNodes[1].FirstChild);
        LoadLevel7Positions(xmlDocPositions.DocumentElement.ChildNodes[2].FirstChild);
        LoadLevel9Positions(xmlDocPositions.DocumentElement.ChildNodes[3].FirstChild);
        LoadLevel15Positions(xmlDocPositions.DocumentElement.ChildNodes[4].FirstChild);
    }

    void LoadLevel4Positions(XmlNode node0)
    {
        string[] temp;
        temp = node0.Attributes["obj1"].Value.Split(':');
        level4Positions[0] = new Vector2(float.Parse(temp[0]), float.Parse(temp[1]));
    }
    void LoadLevel5Positions(XmlNode node1)
    {
        string[] temp;
        temp = node1.Attributes["obj1"].Value.Split(':');
        level5Positions[0] = new Vector2(float.Parse(temp[0]), float.Parse(temp[1]));
        temp = node1.Attributes["obj2"].Value.Split(':');
        level5Positions[1] = new Vector2(float.Parse(temp[0]), float.Parse(temp[1]));
        temp = node1.Attributes["obj3"].Value.Split(':');
        level5Positions[2] = new Vector2(float.Parse(temp[0]), float.Parse(temp[1]));
        temp = node1.Attributes["obj4"].Value.Split(':');
        level5Positions[3] = new Vector2(float.Parse(temp[0]), float.Parse(temp[1]));
    }
    void LoadLevel7Positions(XmlNode node2)
    {
        string[] temp;
        temp = node2.Attributes["obj1"].Value.Split(':');
        level7Positions[0] = new Vector2(float.Parse(temp[0]), float.Parse(temp[1]));
        temp = node2.Attributes["obj2"].Value.Split(':');
        level7Positions[1] = new Vector2(float.Parse(temp[0]), float.Parse(temp[1]));
        temp = node2.Attributes["obj3"].Value.Split(':');
        level7Positions[2] = new Vector2(float.Parse(temp[0]), float.Parse(temp[1]));
        temp = node2.Attributes["obj4"].Value.Split(':');
        level7Positions[3] = new Vector2(float.Parse(temp[0]), float.Parse(temp[1]));
        temp = node2.Attributes["obj5"].Value.Split(':');
        level7Positions[4] = new Vector2(float.Parse(temp[0]), float.Parse(temp[1]));
        temp = node2.Attributes["obj6"].Value.Split(':');
        level7Positions[5] = new Vector2(float.Parse(temp[0]), float.Parse(temp[1]));
    }
    void LoadLevel9Positions(XmlNode node3)
    {
        string[] temp;
        temp = node3.Attributes["obj1"].Value.Split(':');
        level9Positions[0] = new Vector2(float.Parse(temp[0]), float.Parse(temp[1]));
    }
    void LoadLevel15Positions(XmlNode node4)
    {
        string[] temp;
        temp = node4.Attributes["obj1"].Value.Split(':');
        level15Positions[0] = new Vector2(float.Parse(temp[0]), float.Parse(temp[1]));
    }


    public void SaveGame()
    {
        SavePlayerStats();
        SaveLevelPassedBooleans();
        SaveObjectPositions();
    }

    void SavePlayerStats()
    {
        XmlDocument xmlDocPlayerStats = new XmlDocument();
        xmlDocPlayerStats.Load(playerStatsFileName);
        XmlNode xmlNode = xmlDocPlayerStats.DocumentElement.ChildNodes[0].FirstChild;
        xmlNode.Attributes["level"].Value = playerLevelSave.ToString();
        xmlNode.Attributes["spells"].Value = playerSpellsUnlocked.ToString();
        xmlDocPlayerStats.Save(playerStatsFileName);
    }

    void SaveLevelPassedBooleans()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(levelPassedFileName);
        for (int i = 0; i < levelsPassed.Length; i++)
        {
            XmlNode xmlNode = xmlDoc.DocumentElement.ChildNodes[i].FirstChild;    
            if (i < levelsPassed.Length)
            {
                if (levelsPassed[i])
                {
                    xmlNode.Attributes["lvl"].Value = 1.ToString();
                }
                else
                {
                    xmlNode.Attributes["lvl"].Value = 0.ToString();
                }
            }
        }
        xmlDoc.Save(levelPassedFileName);
    }

    void SaveObjectPositions()
    {
        XmlDocument xmlDocPositions = new XmlDocument();
        xmlDocPositions.Load(objectPositionsFileName);
        XmlNode xmlNode0 = xmlDocPositions.DocumentElement.ChildNodes[0].FirstChild;
        XmlNode xmlNode1 = xmlDocPositions.DocumentElement.ChildNodes[1].FirstChild;
        XmlNode xmlNode2 = xmlDocPositions.DocumentElement.ChildNodes[2].FirstChild;
        XmlNode xmlNode3 = xmlDocPositions.DocumentElement.ChildNodes[3].FirstChild;
        XmlNode xmlNode4 = xmlDocPositions.DocumentElement.ChildNodes[4].FirstChild;
        xmlNode0.Attributes["obj1"].Value = level4Positions[0].x + ":" + level4Positions[0].y;
        xmlNode1.Attributes["obj1"].Value = level5Positions[0].x + ":" + level5Positions[0].y;
        xmlNode1.Attributes["obj2"].Value = level5Positions[1].x + ":" + level5Positions[1].y;
        xmlNode1.Attributes["obj3"].Value = level5Positions[2].x + ":" + level5Positions[2].y;
        xmlNode1.Attributes["obj4"].Value = level5Positions[3].x + ":" + level5Positions[3].y;
        xmlNode2.Attributes["obj1"].Value = level7Positions[0].x + ":" + level7Positions[0].y;
        xmlNode2.Attributes["obj2"].Value = level7Positions[1].x + ":" + level7Positions[1].y;
        xmlNode2.Attributes["obj3"].Value = level7Positions[2].x + ":" + level7Positions[2].y;
        xmlNode2.Attributes["obj4"].Value = level7Positions[3].x + ":" + level7Positions[3].y;
        xmlNode2.Attributes["obj5"].Value = level7Positions[4].x + ":" + level7Positions[4].y;
        xmlNode2.Attributes["obj6"].Value = level7Positions[5].x + ":" + level7Positions[5].y;
        xmlNode3.Attributes["obj1"].Value = level9Positions[0].x + ":" + level9Positions[0].y;
        xmlNode4.Attributes["obj1"].Value = level15Positions[0].x + ":" + level15Positions[0].y;
        xmlDocPositions.Save(objectPositionsFileName);
    }


   

}

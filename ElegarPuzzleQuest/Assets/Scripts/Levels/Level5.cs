using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//in order to pass level 5 you need to move to level 6. will also play the player slide down the cliff animation when the player is on top of the cliff
public class Level5 : Level
{
    [SerializeField]
    DoorTrigger doorTo6;

    private void Start()
    {
        levelPassed = LevelManager.Instance.IsLevelPassed(ID);
        EnterLevel();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player p = collision.GetComponent<Player>();
            if (p.inControl)
            {
                p.PlayerSlideDownTheCliff();
            }
        }
    }

    public override void ExitLevel(DoorTrigger door)
    {
        if (door == doorTo6)
        {
            levelPassed = true;
            SentImportantObjectsPositionsToLevelManager();//saves the position of the rocks
            LevelManager.Instance.SetLevelPassed(levelPassed, ID);
        }
    }
}

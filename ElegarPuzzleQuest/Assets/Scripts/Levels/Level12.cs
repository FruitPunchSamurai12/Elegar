using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level12 : Level
{

    [SerializeField]
    DoorTrigger doorTo11;

    [SerializeField]
    GameObject flameLord;

    [SerializeField]
    GameObject spellScroll;

    protected override void EnterNotPassedLevel()
    {
        AudioManager.Instance.PlayBGMusic("Boss");
        doorTo11.InvisibleWall(true);
        flameLord.SetActive(true);
        if (spellScroll)
        {
            spellScroll.SetActive(false);
        }
    }

    protected override void EnterPassedLevel()
    {
        if (flameLord)
        {
            flameLord.SetActive(false);
        }
        if (spellScroll)
        {
            spellScroll.SetActive(true);
        }
        base.EnterPassedLevel();
    }

    public override void ExitLevel(DoorTrigger door)
    {
        if (flameLord)
        {
            flameLord.SetActive(false);
        }
    }

    public void BossExploded()
    {
        AudioManager.Instance.PlayBGMusic("Mountain");
        levelPassed = true;
        doorTo11.InvisibleWall(false);
        if (spellScroll)
        {
            spellScroll.SetActive(true);
        }
        LevelManager.Instance.SetLevelPassed(levelPassed, ID);
    }
}

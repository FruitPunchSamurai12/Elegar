using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level17 : Level
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject spellScroll;

    void Start()
    {
        levelPassed = LevelManager.Instance.IsLevelPassed(ID);
        EnterLevel();
    }

    protected override void EnterNotPassedLevel()
    {
        ActivateAllImportantObjects();
        if (spellScroll)
        {
            spellScroll.SetActive(false);
        }
        base.EnterNotPassedLevel();
    }

    protected override void EnterPassedLevel()
    {
        if (spellScroll)
        {
            spellScroll.SetActive(true);
        }
        DeActivateAllImportantObjects();
    }

    public void BatulaExtinguished()
    {
        levelPassed = true;
        if (spellScroll)
        {
            spellScroll.SetActive(true);
        }
        LevelManager.Instance.SetLevelPassed(levelPassed, ID);
    }
}

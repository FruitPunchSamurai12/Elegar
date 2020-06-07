using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///you need to light all altars to extinguish batula and pass level 17. if you re-enter the level all lights will be lit and batula and the bats will be deactivated
public class Level17 : Level
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject spellScroll;

    [SerializeField]
    AudioSource source;

    void Start()
    {
        levelPassed = LevelManager.Instance.IsLevelPassed(ID);
        EnterLevel();
    }

    protected override void EnterNotPassedLevel()
    {
        AudioManager.Instance.PlayBGMusic("Boss");
        source.volume = AudioManager.fxVolume;
        source.clip = AudioManager.Instance.GetSoundEffect("Laugh");
        source.Play();
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
        AudioManager.Instance.PlayBGMusic("Dungeon");
        source.volume = AudioManager.fxVolume;
        source.clip = AudioManager.Instance.GetSoundEffect("Victory");
        source.Play();
        levelPassed = true;
        if (spellScroll)
        {
            spellScroll.SetActive(true);
        }
        LevelManager.Instance.SetLevelPassed(levelPassed, ID);
    }
}

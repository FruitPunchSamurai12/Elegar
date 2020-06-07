using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//level 3 first boss fight against grog grog.
public class Level3 : Level
{
    

    [SerializeField]
    DoorTrigger doorTo2;

    [SerializeField]
    GameObject spellScroll;

    [SerializeField]
    AudioSource source;
    protected override void EnterNotPassedLevel()//activate grog grog and play boss music
    {
        AudioManager.Instance.PlayBGMusic("Boss");
        ActivateAllImportantObjects();
        doorTo2.InvisibleWall(true);
        if (spellScroll)
        {
            spellScroll.SetActive(false);
        }
        base.EnterNotPassedLevel();
    }

    protected override void EnterPassedLevel()
    {
        AudioManager.Instance.PlayBGMusic("Forest");
        DeActivateAllImportantObjects();
        if(spellScroll)
        {
            spellScroll.SetActive(true);
        }
    }



    public void BossDown()//called when all switches are pressed
    {
        AudioManager.Instance.PlayBGMusic("Forest");
        source.volume = AudioManager.fxVolume;
        source.clip = AudioManager.Instance.GetSoundEffect("Victory");
        source.Play();
        levelPassed = true;
        LevelManager.Instance.SetLevelPassed(levelPassed, ID);
        doorTo2.InvisibleWall(false);
        if (spellScroll)
        {
            spellScroll.SetActive(true);
        }
    }

   

}

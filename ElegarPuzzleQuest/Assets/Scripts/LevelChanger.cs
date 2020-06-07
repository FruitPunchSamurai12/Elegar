﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


///this guy handles all scene changes in the game. also has a fade in and fade out animation

public class LevelChanger : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    int screenToLoadIndex;

    public static LevelChanger Instance;

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


    // Start is called before the first frame update


    public void LoadAScene()//this is called as an animation event at the end of fadeOut animation
    {
        SceneManager.LoadScene(screenToLoadIndex);
        HUD.Instance.ResumeGame();
    }

    public void WorldMap()
    {
        animator.SetTrigger("FadeOut");
        screenToLoadIndex = 1;
    }

    public void Level13()
    {
        animator.SetTrigger("FadeOut");
        screenToLoadIndex = 2;
    }
    public void Level1415()
    {
        animator.SetTrigger("FadeOut");
        screenToLoadIndex = 3;
    }
    public void Level16()
    {
        animator.SetTrigger("FadeOut");
        screenToLoadIndex = 4;
    }
    public void Level17()
    {
        animator.SetTrigger("FadeOut");
        screenToLoadIndex = 5;
    }

    public void LoadLevel(int lvl)//load a scene when we know the level we are
    {
        AudioManager.Instance.PlayBGMusic(lvl);
        if(lvl<16)
        {
            WorldMap();
        }
        else if(lvl==16)
        {           
            Level16();
        }
    }

    public void MainMenu()
    {
        animator.SetTrigger("FadeOut");
        screenToLoadIndex = 0;
    }
}

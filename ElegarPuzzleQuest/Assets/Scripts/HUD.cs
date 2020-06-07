using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///This guy handles all in game UI. 
///HEARTS, SPELLS, PAUSE MENU, GAME OVER MENU
///it also keeps check of elegar's stats and kills him if his health is 0
///since it is a singleton it keeps elegar's stats after a scene change and sets him up afterwards

public class HUD : MonoBehaviour
{

    Player elegar;

    public int currentHealth = 999;
    public int maxHealth = 999;

    [SerializeField]
    GameObject pauseMenu;

    [SerializeField]
    GameObject settingMenu;

    [SerializeField]
    GameObject gameOverMenu;

    [SerializeField]
    GameObject heartsBar;

    [SerializeField]
    GameObject spellbar;

    [SerializeField]
    GameObject gameSavedText;

    [SerializeField]
    Sprite fullHeart;

    [SerializeField]
    Sprite halfHeart;

    [SerializeField]
    Sprite emptyHeart;


    [SerializeField]
    Image[] hearts;

    [SerializeField]
    Image[] spellImages;
    [SerializeField]
    Sprite[] unselectedImages;
    [SerializeField]
    Sprite[] selectedImages;
    public int equippedSpellIndex;
    int spellLevel;

    bool godMode = false;

    public static HUD Instance;

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
    void Start()
    {
        settingMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    public void SetUpElegar(Player p)
    {
        elegar = p;
        elegar.EquipSpell((ElegarSpells)(equippedSpellIndex + 1));
        spellLevel = elegar.spellsUnlocked;
        //number of hearts displayed
        maxHealth = elegar.maxLife;
        if(currentHealth>maxHealth)
        {
            currentHealth = maxHealth;
        }
        int numberOfHearts = maxHealth / 2;
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < numberOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        //spells displayed
        for(int i=0;i<spellImages.Length;i++)
        {
            if (i >= spellLevel)
            {
                spellImages[i].enabled = false;
            }
            else
            {
                spellImages[i].enabled = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            if(godMode)
            {
                godMode = false;
            }
            else
            {
                godMode = true;
            }
        }

        if (elegar)//only show the ui while we have an elegar
        {
            spellbar.SetActive(true);
            heartsBar.SetActive(true);
            UpdateHearts();
            UpdateSpells();
        }
        else
        {
            spellbar.SetActive(false);
            heartsBar.SetActive(false);
        }
    }
    
    public void LearnedNewSpell(int sLevel)
    {
        spellLevel = sLevel;
        for (int i = 0; i < spellImages.Length; i++)
        {
            if (i >= spellLevel)
            {
                spellImages[i].enabled = false;
            }
            else
            {
                spellImages[i].enabled = true;
            }
        }
    }

    void UpdateHearts()
    {
        if (!godMode)
        {
            if (currentHealth == 0)
            {
                for (int i = 0; i < hearts.Length; i++)
                {
                    hearts[i].sprite = emptyHeart;
                    elegar.Die();
                    GameOver();
                }
            }
            else
            {
                for (int i = 0; i < hearts.Length; i++)
                {
                    if (currentHealth % 2 == 0)
                    {
                        if (i < currentHealth / 2)
                        {
                            hearts[i].sprite = fullHeart;
                        }
                        else
                        {
                            hearts[i].sprite = emptyHeart;
                        }
                    }
                    else
                    {
                        if (i < currentHealth / 2)
                        {
                            hearts[i].sprite = fullHeart;
                        }
                        else if (i == currentHealth / 2)
                        {
                            hearts[i].sprite = halfHeart;
                        }
                        else
                        {
                            hearts[i].sprite = emptyHeart;
                        }
                    }
                }
            }
        }
    }

    void UpdateSpells()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            elegar.EquipSpell(ElegarSpells.Push);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            elegar.EquipSpell(ElegarSpells.Pull);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            elegar.EquipSpell(ElegarSpells.Water);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            elegar.EquipSpell(ElegarSpells.Light);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            elegar.EquipSpell(ElegarSpells.Reflect);
        }
    }

    public void PressSpellButton(int s)
    {
        if (elegar)
        {
            elegar.EquipSpell((ElegarSpells)s);
        }
    }

    public void ChangeSpellImageOnEquipSpell()
    {
        for(int i = 0;i<spellImages.Length;i++)
        {
            if(i<spellLevel)
            {
                if(i==equippedSpellIndex)
                {
                    spellImages[i].sprite = selectedImages[i];
                }
                else
                {
                    spellImages[i].sprite = unselectedImages[i];
                }
            }
        }
    }

    public void OnSaveGame()
    {
        StartCoroutine("ToggleGameSavedText");
    }

    IEnumerator ToggleGameSavedText()
    {
        gameSavedText.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        gameSavedText.SetActive(false);
    }

    //Pause menu and game over menu stuff

    public void PauseGame()
    {
        Time.timeScale = 0f;
        ElegarPuzzleQuestManager.gamePaused = true;
        settingMenu.SetActive(false);
        pauseMenu.SetActive(true);
        gameOverMenu.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        ElegarPuzzleQuestManager.gamePaused = false;
        settingMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    public void GameOver()
    {
     
        settingMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(true);
        ElegarPuzzleQuestManager.state = GameStates.gameOver;
    }

    public void OnClickLoad()
    {
        ElegarPuzzleQuestManager.Instance.LoadGame();        
        currentHealth = maxHealth;
        
    }

    public void OnClickSettings()
    {
        settingMenu.SetActive(true);
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    public void OnClickBack()
    {
        settingMenu.SetActive(false);
        pauseMenu.SetActive(true);
        gameOverMenu.SetActive(false);
    }

    public void OnClickExit()
    {
        ResumeGame();
        ElegarPuzzleQuestManager.Instance.GoToMainMenu();
    }

    public void BGVolumeSlider(float value)
    {
        AudioManager.Instance.ChangeBGVolume(value);
    }

    public void FXVolumeSlider(float value)
    {
        AudioManager.Instance.ChangeFXVolume(value);
    }

}

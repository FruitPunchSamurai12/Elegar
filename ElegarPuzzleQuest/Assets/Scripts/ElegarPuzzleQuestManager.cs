using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates
{
    mainMenu,
    gameplay,
    pause,
    gameOver
}

///This guy is the GM. It might seem like he doesnt do much but he coordinates all the other managers and makes sure everything is set as should be

public class ElegarPuzzleQuestManager : MonoBehaviour
{
    [SerializeField]
    CameraScript cam;
    [SerializeField]
    Player player;

    public static ElegarPuzzleQuestManager Instance;
    public static GameStates state = GameStates.mainMenu;
    public static bool gamePaused = false;

    Vector2 cameraStartPosition;
    Vector2 playerStartPosition;

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

    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case GameStates.mainMenu:
                break;
            case GameStates.gameplay:
                    if(Input.GetKeyDown(KeyCode.Escape))//toggle pause
                {
                    if(gamePaused)
                    {
                        HUD.Instance.ResumeGame();
                    }
                    else
                    {
                        HUD.Instance.PauseGame();
                    }
                }
                break;
            case GameStates.gameOver:
                break;
        }       
    }

    public void GoToMainMenu()
    {
        state = GameStates.mainMenu;
        LevelChanger.Instance.MainMenu();
    }

    public void StartNewGame()
    {
        LevelManager.Instance.ResetLevelsPassed();
        LevelManager.Instance.playerSpellsUnlocked = 0;
        state = GameStates.gameplay;
        LevelChanger.Instance.WorldMap();
        playerStartPosition = LevelManager.Instance.SavePointsPosition(1);
        cameraStartPosition = LevelManager.Instance.GetCameraStartingPosition(1);
    }

    public void LoadGame()
    {
        state = GameStates.gameplay;
        LevelManager.Instance.LoadGame();
        LevelChanger.Instance.LoadLevel(LevelManager.Instance.playerLevelSave);
        playerStartPosition = LevelManager.Instance.SavePointsPosition(LevelManager.Instance.playerLevelSave);
        cameraStartPosition = LevelManager.Instance.GetCameraStartingPosition(LevelManager.Instance.playerLevelSave);
    }

    public void EnterExitCave(int newLevel,int currentLevel)//used to change to the correct screen after exiting/entering a cave
    {
        if (newLevel == 5 || newLevel == 8)
        {
            LevelChanger.Instance.WorldMap();
        }
        else if (newLevel == 13)
        {
            LevelChanger.Instance.Level13();
        }
        else if (newLevel == 14 || newLevel == 15)
        {
            LevelChanger.Instance.Level1415();
        }
        else if(newLevel == 16)
        {
            LevelChanger.Instance.Level16();
        }
        else if (newLevel == 17)
        {
            LevelChanger.Instance.Level17();
        }
        playerStartPosition = LevelManager.Instance.GetCavePosition(newLevel, currentLevel);
        cameraStartPosition = LevelManager.Instance.GetCameraStartingPosition(newLevel);
        AudioManager.Instance.PlayBGMusic(newLevel);
    }

   

    public void SetPlayer(Player p)//the player calls this when a scene loads
    {
        player = p;
        p.transform.position = playerStartPosition;
        p.spellsUnlocked = LevelManager.Instance.playerSpellsUnlocked;
    }

    public void SetCamera(CameraScript c)//the camera calls this when a scene loads
    {
        cam = c;
        cam.startingPosition = cameraStartPosition;
    }

    public Transform PlayerTransform() { return player.transform; }//used by ai mostly to get the player's position

    public void ChangeRoom(bool horizontal, bool positive, Vector3 newPlayerPosition)//called by the door trigger when the player collides with it
    {
        cam.ChangeRoom(horizontal, positive);
        player.ChangeRoom(newPlayerPosition);
    }

}

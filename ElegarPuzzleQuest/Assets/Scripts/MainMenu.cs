using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject mainMenu;

    [SerializeField]
    GameObject settingsMenu;

    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickNewGame()
    {
        ElegarPuzzleQuestManager.Instance.StartNewGame();
    }

    public void OnClickLoad()
    {
        ElegarPuzzleQuestManager.Instance.LoadGame();
    }

    public void OnClickSettings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void OnClickBack()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}

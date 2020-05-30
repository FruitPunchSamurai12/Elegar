using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    Player elegar;

    [SerializeField]
    Sprite fullHeart;

    [SerializeField]
    Sprite halfHeart;

    [SerializeField]
    Sprite emptyHeart;


    [SerializeField]
    Image[] hearts;


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
        
    }

    public void SetUpElegar(Player p)
    {
        elegar = p;
        int numberOfHearts = elegar.maxLife / 2;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (elegar)
        {
            UpdateHearts();
        }
    }
    

    void UpdateHearts()
    {
        int currentHp = elegar.currentLife;
        if (currentHp == 0)
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                hearts[i].sprite = emptyHeart;
            }
        }
        else
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                if (currentHp % 2 == 0)
                {
                    if (i < currentHp / 2)
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
                    if (i < currentHp / 2)
                    {
                        hearts[i].sprite = fullHeart;
                    }
                    else if (i == currentHp / 2)
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

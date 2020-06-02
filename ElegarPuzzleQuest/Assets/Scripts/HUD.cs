using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    Player elegar;

    public int currentHealth = 999;

    [SerializeField]
    Sprite fullHeart;

    [SerializeField]
    Sprite halfHeart;

    [SerializeField]
    Sprite emptyHeart;


    [SerializeField]
    Image[] hearts;

    [SerializeField]
    Button[] spells;
    public int equippedSpellIndex;


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
        elegar.EquipSpell((ElegarSpells)(equippedSpellIndex + 1));
        if(currentHealth>elegar.maxLife)
        {
            currentHealth = elegar.maxLife;
        }
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
        
        if (currentHealth == 0)
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                hearts[i].sprite = emptyHeart;
                elegar.Die();
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

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
    Image[] spellImages;
    [SerializeField]
    Sprite[] unselectedImages;
    [SerializeField]
    Sprite[] selectedImages;
    public int equippedSpellIndex;
    int spellLevel;

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
        spellLevel = elegar.spellsUnlocked;
        //number of hearts displayed
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
        if (elegar)
        {
            UpdateHearts();
            UpdateSpells();
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
}

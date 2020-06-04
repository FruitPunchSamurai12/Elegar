using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellScroll : MonoBehaviour
{
    public int spellLevel = 0;
    [SerializeField]
    GameObject portal;

    private void Start()
    {
        if(LevelManager.Instance.playerSpellsUnlocked>=spellLevel)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Player p = collision.GetComponent<Player>();
            p.PickUpSpellBook(spellLevel);
            AudioManager.Instance.PlaySoundEffect("Item");
            if (portal)
            {
                portal.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}

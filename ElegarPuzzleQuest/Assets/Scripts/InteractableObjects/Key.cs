using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the key in level 6. 

public class Key : MonoBehaviour
{
    [SerializeField]
    float yLimit;//this is here so the player doesnt push it off screen


    [SerializeField]
    Level6 lvl;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<yLimit)
        {
            transform.position = new Vector2(transform.position.x, yLimit);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player p = collision.GetComponent<Player>();
            lvl.GotKey();
            AudioManager.Instance.PlaySoundEffect("Item");
            Destroy(gameObject);
        }
    }
}

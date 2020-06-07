using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


///Very important guy. Used as trigger colliders between levels. 
///Not only moves the camera but also calls behavior for exiting and entering levels
public class DoorTrigger : MonoBehaviour
{
    public bool horizontal = false;
    public bool positive = false;
    
    [SerializeField]
    Transform newPlayerPosition;
    [SerializeField]
    Level currentLevel;
    [SerializeField]
    Level nextLevel;

    Collider2D col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Player p = collision.GetComponent<Player>();
            if (p.PlayerAlive())
            {
                if (p.inControl)
                {
                    if (p.sliding)
                    {
                        p.sliding = false;
                    }
                    ElegarPuzzleQuestManager.Instance.ChangeRoom(horizontal, positive, newPlayerPosition.localPosition);
                    AudioManager.Instance.PlayBGMusic(nextLevel.ID);
                    currentLevel.ExitLevel(this);
                    nextLevel.EnterLevel(this);
                }
            }
        }
    }

    public void InvisibleWall(bool wall)//i use that for bosses or when fires block doors
    {
        if(wall)
        {
            Invoke("MakeInvisibleWall", 1f);//the delay is there cause when you move into a boss level the door becomes a wall before elegar passes through
        }
        else
        {
            col.isTrigger = true;
        }
    }

    void MakeInvisibleWall()
    {
        col.isTrigger = false;
    }
}

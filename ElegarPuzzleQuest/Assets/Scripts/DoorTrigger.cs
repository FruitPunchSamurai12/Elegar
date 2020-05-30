using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

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
            if (p.inControl)
            {
                //Vector2 connectingRoomCenter = new Vector2(connectingRoom.CellToWorld(connectingRoom.origin).x + connectingRoom.CellToWorld(connectingRoom.size).x / 2f, connectingRoom.CellToWorld(connectingRoom.origin).y + connectingRoom.CellToWorld(connectingRoom.size).y / 2f);
                if(p.sliding)
                {
                    p.sliding = false;
                }
                ElegarPuzzleQuestManager.Instance.ChangeRoom(horizontal,positive, newPlayerPosition.localPosition);
                currentLevel.ExitLevel(this);
                nextLevel.EnterLevel(this);
            }
        }
    }

    public void InvisibleWall(bool wall)
    {
        if(wall)
        {
            Invoke("MakeInvisibleWall", 1f);
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

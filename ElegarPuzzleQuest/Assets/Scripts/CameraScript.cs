using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraScript : MonoBehaviour
{


    [SerializeField]
    SpriteRenderer bg;

    Camera cam;

    Vector2 startPosition;
    Vector2 endPosition;
    bool lerping = false;
    float timeLerpStarted;
    public float lerpDuration = 1f;

    public float xOffset = 15f;
    public float yOffset = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
        cam = Camera.main;
        Vector3 pos = bg.transform.position;//new Vector3(startTilemap.CellToWorld(startTilemap.origin).x + startTilemap.CellToWorld(startTilemap.size).x/2f, startTilemap.CellToWorld(startTilemap.origin).y + startTilemap.CellToWorld(startTilemap.size).y/2f,-10f);
        cam.transform.position = new Vector3(pos.x, pos.y, -10f);
        startPosition = transform.position;
        endPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void LateUpdate()
    {
        if (lerping)
        {
            float timeSinceStarted = Time.time - timeLerpStarted;
            float percentageComplete = timeSinceStarted / lerpDuration;
            Vector2 newPos = Vector2.Lerp(startPosition, endPosition, percentageComplete);
            cam.transform.position = new Vector3(newPos.x, newPos.y, -10f);
            if (percentageComplete >= 1f)
            {
                lerping = false;
            }

        }
    }

    public void ChangeRoom(bool horizontal, bool positive)
    {
        int one = 1;
        if(!positive)
        {
            one = -1;
        }
        timeLerpStarted = Time.time;
        startPosition = transform.position;
        if (horizontal)
        {
            endPosition = new Vector2(transform.position.x + xOffset*one, transform.position.y);
        }
        else
        {
            endPosition = new Vector2(transform.position.x, transform.position.y + yOffset*one);
        }
        lerping = true;
    }

}

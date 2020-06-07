using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

///thats the main camera script. cameras on underground levels dont need it cause another scene loads when you exit the level
public class CameraScript : MonoBehaviour
{

   //where the camera will start. the LevelManager has that information
    public Vector2 startingPosition;

    Camera cam;
    //these are stuff for lerp
    Vector2 startPosition;
    Vector2 endPosition;
    bool lerping = false;
    float timeLerpStarted;
    public float lerpDuration = 1f;

    public float xOffset = 15f;
    public float yOffset = 10f;

    private void Awake()
    {
        ElegarPuzzleQuestManager.Instance.SetCamera(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        //set the camera to it's position
        cam = GetComponent<Camera>();
        Vector3 pos = startingPosition;
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
        if (lerping)//linear interpolation to move to the next room
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

    //player moved through a door trigger. find the camera's end position and start lerp
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

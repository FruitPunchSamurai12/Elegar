using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{

    [SerializeField]
    Rigidbody2D rb2d;

    bool isMoving = false;
    Vector2 startPosition;
    Vector2 endPosition;
    float timeLerpStarted;
    public float lerpDuration = 1f;


    public void PushPull(Vector2 endPos)
    {
        if (!isMoving)
        {
            startPosition = transform.position;
            endPosition = endPos;
            timeLerpStarted = Time.time;
            isMoving = true;
            rb2d.isKinematic = false;
        }
    }

    private void FixedUpdate()
    {
        if(isMoving)
        {
            float timeSinceStarted = Time.time - timeLerpStarted;
            float percentageComplete = timeSinceStarted / lerpDuration;
            Vector2 newPos = Vector2.Lerp(startPosition, endPosition, percentageComplete);
            rb2d.MovePosition(new Vector2(newPos.x, newPos.y));
            if (percentageComplete >= 1f)
            {
                isMoving = false;
                rb2d.isKinematic = true;
            }
        }
    }
}

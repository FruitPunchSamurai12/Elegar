using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///anything the push and pull spell affect
///it works with interpolation so when the push/pull spell hits a movable the script finds the end position then lerp the object there
public class Movable : MonoBehaviour
{
    [SerializeField]//the prefab for the tornado effect
    GameObject tornado;
    //reference to the instantiated tornado effect
    Effects tornadoEffect = null;

    [SerializeField]
    Rigidbody2D rb2d;
    [SerializeField]
    BoxCollider2D defaultCollider;
    [SerializeField]
    SpriteRenderer renderer;

    //stuff for level 9 where you push the rock underwater
    [SerializeField]
    Sprite underwaterRock;
    [SerializeField]
    string underwaterLayerName;
    [SerializeField]
    BoxCollider2D underwaterCollider1;
    [SerializeField]
    BoxCollider2D underwaterCollider2;
    bool underwater = false;

    //stuff for level 15 with the ice
    public bool onIce = false;
    public float slideSpeed = 7f;
    Vector3 slideDirection;
    [SerializeField]
    private bool isMoving = false;
    [SerializeField]
    bool isSliding = false;

    //push and pull 
    Vector2 startPosition;
    Vector2 endPosition;
    float timeLerpStarted;
    public float lerpDuration = 1f;


    public void PushPull(Vector2 endPos)
    {
        if (!isMoving && !underwater)
        {
            if(onIce)
            {
                isSliding = true;
            }
            startPosition = transform.position;
            endPosition = endPos;
            timeLerpStarted = Time.time;           
            slideDirection = (endPos - startPosition).normalized;
            isMoving = true;
            rb2d.isKinematic = false;
            rb2d.mass = 10000f;//i increase the mass otherwise elegar can move them with his body
            GameObject t = Instantiate(tornado, transform);
            t.transform.localPosition = Vector3.zero;
            tornadoEffect = t.GetComponent<Effects>();
        }
    }

    public void UnderWater()
    {
        if (!underwater)
        {
            underwater = true;
            renderer.sortingLayerName = underwaterLayerName;
            renderer.sprite = underwaterRock;
            defaultCollider.enabled = false;
            underwaterCollider1.enabled = true;
            underwaterCollider2.enabled = true;
        }
    }

    private void FixedUpdate()
    {
        if(isSliding)
        {
            rb2d.MovePosition(transform.position + slideDirection * slideSpeed * Time.fixedDeltaTime);
        }
        else if(isMoving)
        {
            if(onIce)
            {
                isSliding = true;
            }
            float timeSinceStarted = Time.time - timeLerpStarted;
            float percentageComplete = timeSinceStarted / lerpDuration;
            Vector2 newPos = Vector2.Lerp(startPosition, endPosition, percentageComplete);
            rb2d.MovePosition(new Vector2(newPos.x, newPos.y));          
            if (percentageComplete >= 1f)
            {
                isMoving = false;
                rb2d.isKinematic = true;
                if(tornadoEffect)
                {
                    tornadoEffect.DestroyEffect();
                }
            }
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isSliding )
        {
            isSliding = false;
            isMoving = false;
            rb2d.isKinematic = true;
            if (tornadoEffect)
            {
                tornadoEffect.DestroyEffect();
            }
        }

    }
}

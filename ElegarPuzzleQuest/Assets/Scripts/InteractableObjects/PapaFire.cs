using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///Flame lord fire projectiles. It works as a projectile but its also a fire so it was weird. 
///Spawns baby fires towards random directions when it lands. The baby fires use this same script but they dont spawn more fires

public class PapaFire : Fire
{
    [SerializeField]
    GameObject babyFire;
    [SerializeField]
    Collider2D collider;
    float colliderActivateLimit = 0.9f;
    public float babyFireRadius = 2.5f;

    bool initialized = false;
    bool done = false;
    bool papaFire = false;
    Vector2 startPos;
    Vector2 targetPos;
    float xOffset;
    float yOffset;
    float timeInterpolationStarted;
    public float interpolationDuration = 1f;
    // Update is called once per frame
    void Update()
    {
        if(initialized && !done)
        {
            float timeSinceStarted = Time.time - timeInterpolationStarted;
            float percentageComplete = timeSinceStarted / interpolationDuration;
            transform.position = new Vector2(startPos.x + xOffset * Easings.Linear(percentageComplete), startPos.y + yOffset * Easings.QuadraticEaseInOut(percentageComplete));
            if(percentageComplete< colliderActivateLimit)
            {
                collider.enabled = false;
            }
            else
            {
                collider.enabled = true;
            }
            if (percentageComplete >= 1f)
            {
                done = true;
                if(papaFire)
                {
                    SpawnBabyFires();
                }
            }
        }
    }

    public void Initialize(Vector2 target,bool papa)
    {
        papaFire = papa;
        if(papa)
        {
            colliderActivateLimit = 0.9f;
        }
        else
        {
            colliderActivateLimit = 0.5f;
        }
        startPos = transform.position;
        targetPos = target;      
        xOffset = targetPos.x - startPos.x;
        yOffset = targetPos.y - startPos.y;
        timeInterpolationStarted = Time.time;
        initialized = true;
    }

    public void SpawnBabyFires()
    {
        for(int i = 0;i<4;i++)
        {
            GameObject f = Instantiate(babyFire, transform.position, Quaternion.identity);
            Vector2 random = Random.insideUnitCircle;
            f.GetComponent<PapaFire>().Initialize(new Vector2(transform.position.x+random.x*babyFireRadius,transform.position.y+random.y*babyFireRadius), false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BaseAIController : BaseCharacter
{
    //How far the ai can see
    public float sightRange = 10f;

    //The AI State obviously!
    public AIState state;

    //Time elapsed in state
    public float stateTime = 0f;

    //Where we want to go
    public Transform target;

    //How close to our destination we need to be in order to change/stop
    public float nextWaypointDistance = 1.2f;

    //Used as points in the map for the ai to travel to
    public AIWaypoint aiWaypoint = null;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    [SerializeField]
    Seeker seeker;


    private void Start()
    {
        InvokeRepeating("GeneratePath", 0f, 0.5f);
    }

    protected override void Update()
    {
        state.UpdateState(this);        
        //base.Update();
        
    }

    override protected void FixedUpdate()
    {
        if(path == null)
        {
            return;
        }

        if(currentWaypoint >=path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        direction = ((Vector2)path.vectorPath[currentWaypoint] - rb2d.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb2d.AddForce(force);
        Vector2 animationDirection = ((Vector2)target.position - rb2d.position).normalized;
        animator.SetFloat("Horizontal", animationDirection.x);
        animator.SetFloat("Vertical", animationDirection.y);
        animator.SetFloat("Speed", force.sqrMagnitude);
        float distance = Vector2.Distance(rb2d.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

    }

    public void ChangeAIState(AIState s)
    {
        if (s != state)
        {
            state = s;
            stateTime = 0f;
        }
    }

    void GeneratePath()
    {
        if (seeker.IsDone() && target)
        {
            seeker.StartPath(rb2d.position, target.position, OnPathComplete);
        }
    }
    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }




 
}

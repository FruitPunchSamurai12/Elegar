using UnityEngine;
using Pathfinding;

public class BaseAIController : BaseCharacter
{
    

    //How far the ai can see
    public float sightRange = 10f;

    //How far the ai can hear
    public float hearRange = 5f;

    //Force applied to the player if he collides with this ai
    public float forcePower = 500f;

    //Damage to player hp
    public int damage = 1;

    //The AI State obviously!
    public AIState state;

    //Time elapsed in state
    public float stateTime = 0f;

    //Where we want to go
    public Vector2 target;
    //do we have somewhere to go?
    bool lookTowardsDestination = true;

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
        stateTime += Time.deltaTime;
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
        Vector2 animationDirection = (target - rb2d.position).normalized;
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
       if (seeker.IsDone())
        {
            seeker.StartPath(rb2d.position, target, OnPathComplete);
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

    public void RandomMovement(float minX,float maxX,float minY,float maxY)
    {       
        if (stateTime > state.TimeLimit)
        {
            stateTime = 0f;
            float xValue = Random.Range(minX, maxX);
            float yValue = Random.Range(minY, maxY);
            target = new Vector2(xValue, yValue);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(damage == 0)
        {
            return;
        }
        if (collision.collider.tag == "Player")
        {
            Player p = collision.collider.GetComponent<Player>();
            if (!p.isInvulnerable)
            {
                Vector2 forceDirection = (collision.rigidbody.position - collision.contacts[0].point).normalized;
                collision.rigidbody.AddForceAtPosition(forceDirection * forcePower, collision.contacts[0].point);
                p.TakeDamage(damage);
                p.isInvulnerable = true;
            }
        }
    }

}

using UnityEngine;
using Pathfinding;


///all AI use this
public class BaseAIController : BaseCharacter
{
    public Collider2D col;

    //where is the ai eyes
    public Transform eyesPos;

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

    //dialogue box for talking npcs
    public AIDialogueBox dialogue;
    public GameObject dialogueBox;


    //These are stuff for the Pathfinding system
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    [SerializeField]
    Seeker seeker;


    private void Start()
    {
        InvokeRepeating("GeneratePath", 0f, 0.5f);//pathfinding
    }

    protected override void Update()
    {
        state.UpdateState(this);//this is where the magic happens!
        stateTime += Time.deltaTime;
        //base.Update();
        
    }

    override protected void FixedUpdate()
    {
        if(path == null)//pathfinding stuff
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
        }//pathfinding stuff

        direction = ((Vector2)path.vectorPath[currentWaypoint] - rb2d.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb2d.AddForce(force);    //i move them with add force to make them accelerate and deaccelerate when changing directions   
        Vector2 animationDirection = (target - rb2d.position).normalized;
        animator.SetFloat("Horizontal", animationDirection.x);
        animator.SetFloat("Vertical", animationDirection.y);       
        animator.SetFloat("Speed", force.sqrMagnitude);//this is not really used
        float distance = Vector2.Distance(rb2d.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)//pathfinding stuff
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

    void GeneratePath()//pathfindind stuff
    {
       if (seeker.IsDone())
        {
            seeker.StartPath(rb2d.position, target, OnPathComplete);
        }
    }
    void OnPathComplete(Path p)//pathfindind stuff
    {
        if(!p.error)
       {
            path = p;
            currentWaypoint = 0;
       }
    }

    //this is for the bats. I either had to put it here or create different ai random movement action assets for each bat or else they would all choose the same position
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

    private void OnCollisionEnter2D(Collision2D collision)//do damage and knock player back on collision
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

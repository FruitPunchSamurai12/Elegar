using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public enum ElegarSpells
{
    noSpell,
    Push,
    Pull,
    Water,
    Light,
    Reflect,
    enumEND
}

public class Player : BaseCharacter
{
    public int currentLife = 3;
    public int maxLife = 3;
    bool isDead = false;
    public bool isInvulnerable = false;
    [SerializeField]
    SpriteRenderer renderer;
    float InvulnerabilityDuration = 3f;
    float InvulnerabilityTimer = 0f;

    public bool sliding = false;
    Vector3 slidingDirection;
    private float noMovementThreshold = 0.0001f;
    private const int noMovementFrames = 2;
    Vector3[] previousLocations = new Vector3[noMovementFrames];



    public bool inControl = true;
    [SerializeField]
    private ElegarSpells spell = ElegarSpells.noSpell;
    public float pushPullRange = 3f;
    public float waterAOE = 1f;
    [SerializeField]
    GameObject lightEffect;
    bool isLightOn = false;
    public float lightAOE = 2.5f;


    public Transform groundCheck;

    Vector2 startPosition;
    Vector2 endPosition;
    float timeLerpStarted;
    public float lerpDuration = 1f;
    void Awake()
    {
        //For good measure, set the previous locations
        for (int i = 0; i < previousLocations.Length; i++)
        {
            previousLocations[i] = Vector3.zero;
        }
    }


    override protected void Update()
    {
        if (!isDead)
        {
            if (!sliding)
            {
                if (Input.GetKeyDown(KeyCode.Space) && spell != ElegarSpells.noSpell)
                {
                    animator.SetTrigger("Spell");
                }
                direction.x = Input.GetAxisRaw("Horizontal");
                direction.y = Input.GetAxisRaw("Vertical");
                base.Update();
            }           
        }
        if(isInvulnerable)
        {
            Blink();
        }
    }

    // Update is called once per frame
    override protected void FixedUpdate()
    {
        if (!isDead)
        {
            //Store the newest vector at the end of the list of vectors
            for (int i = 0; i < previousLocations.Length - 1; i++)
            {
                previousLocations[i] = previousLocations[i + 1];
            }
            previousLocations[previousLocations.Length - 1] = transform.position;

            if (sliding)
            {
                Slide();
                //Check the distances between the points in your previous locations
                //If for the past several updates, there are no movements smaller than the threshold,
                //you can most likely assume that the object is not moving
                for (int i = 0; i < previousLocations.Length - 1; i++)
                {
                    if (Vector3.Distance(previousLocations[i], previousLocations[i + 1]) >= noMovementThreshold)
                    {
                        //The minimum movement has been detected between frames
                        sliding = true;
                        break;
                    }
                    else
                    {
                        StopSliding();
                    }
                }
            }
            else if (inControl)
            {
                MoveCharacter();              
            }
            else
            {
                LerpPlayer();
            }
        }
    }

    //Called as an animation event
    public void CastSpell()
    {
        switch(spell)
        {
            case ElegarSpells.Pull:
                Pull();
                break;
            case ElegarSpells.Push:
                Push();
                break;
            case ElegarSpells.Water:
                Water();
                break;
            case ElegarSpells.Light:
                Light();
                break;
            case ElegarSpells.Reflect:
                //reflect
                break;
            default:
                //do nothing
                break;
        }
    }

    public void EquipSpell(ElegarSpells s)
    {
        spell = s;
    }

    void LerpPlayer()
    {
        float timeSinceStarted = Time.time - timeLerpStarted;
        float percentageComplete = timeSinceStarted / lerpDuration;
        Vector2 newPos = Vector2.Lerp(startPosition, endPosition, percentageComplete);
        rb2d.MovePosition(new Vector2(newPos.x, newPos.y));
        if (percentageComplete >= 1f)
        {
            inControl = true;
        }
    }

    public void ChangeRoom(Vector2 offset)
    {
        timeLerpStarted = Time.time;
        startPosition = transform.position;
        endPosition = new Vector2(transform.position.x + offset.x,transform.position.y + offset.y);
        inControl = false;
    }

    void Push()
    {
        int layerMask = 1 << LayerMask.NameToLayer("Interactable");
        Vector2 castDirection = new Vector2(animator.GetFloat("Horizontal"), animator.GetFloat("Vertical"));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, castDirection, pushPullRange,layerMask);
        if (hit.collider != null)
        {
            Movable m = hit.collider.GetComponent<Movable>();
            if (m)
            {
                m.PushPull(new Vector2(m.transform.position.x + castDirection.x * m.transform.localScale.x, m.transform.position.y + castDirection.y * m.transform.localScale.y));
            }
        }
    }

    void Pull()
    {
        int layerMask = 1 << LayerMask.NameToLayer("Interactable");
        Vector2 castDirection = new Vector2(animator.GetFloat("Horizontal"), animator.GetFloat("Vertical"));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, castDirection, pushPullRange, layerMask);
        if (hit.collider != null)
        {
            Movable m = hit.collider.GetComponent<Movable>();
            if (m)
            {
                m.PushPull(new Vector2(m.transform.position.x - castDirection.x * m.transform.localScale.x, m.transform.position.y - castDirection.y * m.transform.localScale.y));
            }
        }
    }

    void Water()
    {
        int layerMask = 1 << LayerMask.NameToLayer("Interactable");
        Vector2 castDirection = new Vector2(animator.GetFloat("Horizontal"), animator.GetFloat("Vertical"));
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, waterAOE, castDirection, 0f, layerMask);
        foreach(RaycastHit2D hit in hits)
        {
            Waterable m = hit.collider.GetComponent<Waterable>();
            if (m)
            {
                m.Watered();
            }
        }
    }


    void Light()
    {
        isLightOn = true;
        lightEffect.SetActive(true);
        int layerMask = 1 << LayerMask.NameToLayer("Interactable");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, lightAOE,layerMask);
        foreach(Collider2D col in colliders)
        {
            Lightable l = col.GetComponent<Lightable>();
            if(l)
            {
                l.Light();
            }
        }
    }

    public void FallToDeath()
    {
        if (!isDead)
        {
            animator.SetTrigger("FallDeath");
            rb2d.position = groundCheck.position;
            isDead = true;
        }
    }

    void Blink()//toggle the renderer on and off to blink
    {
        if (InvulnerabilityTimer < InvulnerabilityDuration)
        {
            renderer.enabled = !renderer.enabled;
            InvulnerabilityTimer += Time.deltaTime;
        }
        else
        {
            renderer.enabled = true;
            InvulnerabilityTimer = 0;
            isInvulnerable = false;
        }
    }

    void Slide()
    {
        rb2d.MovePosition(transform.position + slidingDirection * speed * Time.fixedDeltaTime);
    }

    public void StartSliding()
    {
        if (sliding || direction == Vector3.zero)
        {
            return;
        }
        sliding = true;
        Vector2 temp = new Vector2(direction.x, direction.y);
        if (temp == Vector2.down || temp == Vector2.up || temp == Vector2.left || temp == Vector2.right)
        {
            slidingDirection = direction;
        }
        else
        {
            if(temp.x>temp.y)
            {
                slidingDirection = new Vector3(temp.x, 0f, 0f);
            }
            else if (temp.y > temp.x)
            {
                slidingDirection = new Vector3(0f, temp.y, 0f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(sliding)
        {
           // sliding = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (sliding)
        {
           // Invoke("StopSliding", 0.5f);
        }
    }

    void StopSliding()
    {
        if (sliding)
        {
            sliding = false;
            direction = Vector3.zero;
        }
    }


    public void TakeDamage(int damageValue)
    {
        currentLife -= damageValue;
    }
}

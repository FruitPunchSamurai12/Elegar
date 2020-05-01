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
    public bool inControl = true;
    [SerializeField]
    private ElegarSpells spell = ElegarSpells.noSpell;
    public float pushPullRange = 3f;



    Vector2 startPosition;
    Vector2 endPosition;
    float timeLerpStarted;
    public float lerpDuration = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }


    override protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && spell!= ElegarSpells.noSpell)
        {
            animator.SetTrigger("Spell");
        }
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        base.Update();
    }

    // Update is called once per frame
    override protected void FixedUpdate()
    {
        if (inControl)
        {
            MoveCharacter();                        
        }
        else
        {
            LerpPlayer();
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
                //water
                break;
            case ElegarSpells.Light:
                //light
                break;
            case ElegarSpells.Reflect:
                //reflect
                break;
            default:
                //do nothing
                break;
        }
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
        int layerMask = 1 << LayerMask.NameToLayer("Movable");
        Vector2 castDirection = new Vector2(animator.GetFloat("Horizontal"), animator.GetFloat("Vertical"));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, castDirection, pushPullRange,layerMask);
        if (hit.collider != null)
        {
            Movable m = hit.collider.GetComponent<Movable>();
            m.PushPull(new Vector2(m.transform.position.x + castDirection.x * m.transform.localScale.x, m.transform.position.y + castDirection.y * m.transform.localScale.y));
        }
    }

    void Pull()
    {
        int layerMask = 1 << LayerMask.NameToLayer("Movable");
        Vector2 castDirection = new Vector2(animator.GetFloat("Horizontal"), animator.GetFloat("Vertical"));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, castDirection, pushPullRange, layerMask);
        if (hit.collider != null)
        {
            Movable m = hit.collider.GetComponent<Movable>();
            m.PushPull(new Vector2(m.transform.position.x - castDirection.x * m.transform.localScale.x, m.transform.position.y - castDirection.y * m.transform.localScale.y));
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///every character inherits from this
///tbh the player doesnt share a lot in common with ai so this basecharacter might as well not exist
public class BaseCharacter : MonoBehaviour
{
    protected Vector3 direction = Vector3.down;
    [SerializeField]
    protected Animator animator;
    [SerializeField]
    protected Rigidbody2D rb2d;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (direction != Vector3.zero)
        {
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
        }
        animator.SetFloat("Speed", direction.sqrMagnitude);//the player uses that to change to move animation but not the ai
    }

    protected virtual void FixedUpdate()
    {
        MoveCharacter();
    }

    protected void MoveCharacter()
    {
        rb2d.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }

    public Vector2 CharacterDirection()
    {
        if(direction == Vector3.zero)
        {
            return Vector2.down;
        }
        return direction;
    }


    public void SetAnimatorTrigger(string triggerName)//used with ai actions to trigger an animation
    {
        animator.SetTrigger(triggerName);
    }

    public void ToggleFreezeMovement(bool freeze)//used with ai actions
    {
        if(freeze)
        {
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            rb2d.constraints = RigidbodyConstraints2D.None;
            rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

}
